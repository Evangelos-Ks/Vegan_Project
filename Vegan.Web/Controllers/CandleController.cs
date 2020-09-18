using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Services;


namespace Vegan.Web.Controllers
{
    public class CandleController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        // [Authorize(Roles = "Admins, Supervisors")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Candles.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice)
        {
            //Get all Candles
            IEnumerable<Candle> candles = unitOfWork.Candles.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                candles = candles.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                candles = candles.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    candles = candles.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    candles = candles.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    candles = candles.OrderByDescending(c => c.Price);
                    break;
                default:
                    candles = candles.OrderBy(c => c.Title);
                    break;
            }

            return View(candles);
        }



        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddCandle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCandle(Candle model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Candles.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Candle");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsCandle(int productId)
        {

            return View(unitOfWork.Candles.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditCandle(int productId)
        {

            return View(unitOfWork.Candles.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditCandle(Candle model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Candles.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Candle");
            }
            else
            {
                return View(model);
            }
        }



        [HttpGet]
        public ActionResult DeleteCandle(int productId)
        {
            return View(unitOfWork.Candles.GetById(productId));
        }

        [HttpPost, ActionName("DeleteCandle")]
        public ActionResult DeletePost(int productId)
        {

            var product = unitOfWork.Candles.GetById(productId);
            unitOfWork.Candles.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Candle");
        }
    }
}