using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class ProductController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
       
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            return View(unitOfWork.Products.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.Products.GetAll());
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult AddProduct(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Products.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Product");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult DetailsProduct(int productId)
        {
            return View(unitOfWork.Products.GetById(productId));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult EditProduct(int productId)
        {
            return View(unitOfWork.Products.GetById(productId));
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Products.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteProduct(int productId)
        {
            return View(unitOfWork.Products.GetById(productId));
        }

        [HttpPost, ActionName("DeleteProduct")]
        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Products.GetById(productId);
            unitOfWork.Products.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Product");
        }
    }
}