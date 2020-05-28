﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PayPal.Api;
using Vegan.Services;
using Vegan.Database;
using Vegan.Entities.Library;
using Vegan.Entities;
using Vegan.Entities.DomainClasses.Sales;
using Vegan.Web.Models.ECommerce;

namespace Vegan.Web.Controllers
{
    public class ECommerceController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());
        //private MyDatabase _dbContext => HttpContext.GetOwinContext().Get<MyDatabase>();
        //private MyDatabase _dbContext => HttpContext.GetOwinContext().Get<MyDatabase>();

    //    public ActionResult Index()
    //    {
    //        var model = new IndexVm()
    //        {
    //            Products = _dbContext.Products.ToList();

    //    };

    //        return View(model);
    //}

    public ActionResult Cart()
        {
            var cart = CreateOrGetCart();

            return View(cart);
        }

        [HttpPost]
        public ActionResult Add(int ProductId, string quant="1")
        {
            //var product = _dbContext.Products.FirstOrDefault(x => x.Id == ProductId);
            //var productList = _dbContext.Products;
            //var product = productList.Find(x => x.Id == ProductId);
            var product = unitOfWork.Products.GetById(ProductId);
            var quantity = Convert.ToInt32(quant);
            var cart = CreateOrGetCart();
            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == product.Id);
            if (Session["Price"] == null)
                Session["Price"] = 0m;
            if (existingItem != null)
            {
                existingItem.Quantity = quantity;
                Session["Price"] = cart.Sum();//(decimal)Session["Price"] + existingItem.Price;
            }
            else
            {
                cart.CartItems.Add(new CartItem()
                {
                    ProductId = product.Id,
                    Name = product.Title,
                    Price = product.Price,
                    Quantity = quantity
                });

                Session["Price"] = cart.Sum();//(decimal)Session["Price"] + (product.Price*quantity);
            }
            

            SaveCart(cart);

            //return RedirectToAction("Cart", "ECommerce");
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        public ActionResult Delete(int ProductId)
        {
            //var product = _dbContext.Products.FirstOrDefault(x => x.Id == ProductId);
            var product = unitOfWork.Products.GetById(ProductId);
            var cart = CreateOrGetCart();
            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == product.Id);

            if (existingItem != null)
            {
                
                cart.CartItems.Remove(existingItem);
            }
            if (!cart.CartItems.Any())
            {
                @Session["Price"] = 0m;
            }

            SaveCart(cart);
            Session["Price"] = cart.Sum();//(decimal)Session["Price"] - (existingItem.Price*existingItem.Quantity);
            return RedirectToAction("Cart", "ECommerce");
        }


        public ActionResult EmptyViewCart()
        {
            return View();
        }
        //private MyDatabase _dbContext2 => HttpContext.GetOwinContext().Get<MyDatabase>();

        public ActionResult Checkout()
        {
            var cart = CreateOrGetCart();

            if (cart.CartItems.Any())
            {
                // Flat rate shipping
                int shipping = 500;

                // Flat rate tax 10%
                var taxRate = 0.1M;

                var subtotal = cart.CartItems.Sum(x => x.Price * x.Quantity);
                var tax = Convert.ToInt32((subtotal + shipping) * taxRate);
                var total = subtotal + shipping + tax;

                // Create an Order object to store info about the shopping cart
                var order = new Entities.Order()
                {
                    OrderStamp = DateTime.UtcNow,
                    Subtotal = subtotal,
                    Shipping = shipping,
                    Tax = tax,
                    Total = total,
                    OrderItems = cart.CartItems.Select(x => new OrderItem()
                    {
                        Name = x.Name,
                        Price = x.Price,
                        Quantity = x.Quantity
                    }).ToList()
                };
                //_dbContext.Orders.Add(order);
                //_dbContext.SaveChanges();
                unitOfWork.Orders.Add(order);

                // Get PayPal API Context using configuration from web.config
                var apiContext = GetApiContext();

                // Create a new payment object
                var payment = new Payment
                {
                    intent = "sale",
                    payer = new Payer
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            description = $"BeerPal Brewery Shopping Cart Purchase",
                            amount = new Amount
                            {
                                currency = "USD",
                                total = (order.Total).ToString(), // PayPal expects string amounts, eg. "20.00",
                                details = new Details()
                                {
                                    subtotal = (order.Subtotal).ToString(),
                                    shipping = (order.Shipping).ToString(),
                                    tax = (order.Tax).ToString()
                                }
                            },
                            item_list = new ItemList()
                            {
                                items =
                                    order.OrderItems.Select(x => new Item()
                                    {
                                        description = x.Name,
                                        currency = "USD",
                                        quantity = x.Quantity.ToString(),
                                        price = (x.Price).ToString(), // PayPal expects string amounts, eg. "20.00"
                                    }).ToList()
                            }
                        }
                    },
                    redirect_urls = new RedirectUrls
                    {
                        return_url = Url.Action("Return", "ECommerce", null, Request.Url.Scheme),
                        cancel_url = Url.Action("Cancel", "ECommerce", null, Request.Url.Scheme)
                    }
                };

                // Send the payment to PayPal
                var createdPayment = payment.Create(apiContext);

                // Save a reference to the paypal payment
                order.PayPalReference = createdPayment.id;

                //_dbContext.SaveChanges();

                // Find the Approval URL to send our user to
                var approvalUrl =
                    createdPayment.links.FirstOrDefault(
                        x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

                // Send the user to PayPal to approve the payment
                return Redirect(approvalUrl.href);
            }

            return RedirectToAction("Cart");
        }

        public ActionResult Return(string payerId, string paymentId)
        {
            // Fetch the existing order
            //var order = _dbContext.Orders.FirstOrDefault(x => x.PayPalReference == paymentId);
            var order = unitOfWork.Orders.Find(x => x.PayPalReference == paymentId);

            // Get PayPal API Context using configuration from web.config
            var apiContext = GetApiContext();

            // Set the payer for the payment
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            // Identify the payment to execute
            var payment = new Payment()
            {
                id = paymentId
            };

            // Execute the Payment
            var executedPayment = payment.Execute(apiContext, paymentExecution);

            ClearCart();

            return RedirectToAction("Thankyou");
        }

        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        private Cart CreateOrGetCart()
        {
            var cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                SaveCart(cart);
            }

            return cart;
        }

        private void ClearCart()
        {
            var cart = new Cart();
            SaveCart(cart);
        }

        private void SaveCart(Cart cart)
        {
            Session["Cart"] = cart;
        }

        private APIContext GetApiContext()
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            return apiContext;
        }
    }
}