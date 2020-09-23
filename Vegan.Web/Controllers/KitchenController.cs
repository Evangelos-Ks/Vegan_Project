using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class KitchenController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Kitchens.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all Candles
            IEnumerable<Kitchen> kitchens = unitOfWork.Kitchens.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                kitchens = kitchens.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                kitchens = kitchens.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    kitchens = kitchens.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    kitchens = kitchens.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    kitchens = kitchens.OrderByDescending(c => c.Price);
                    break;
                default:
                    kitchens = kitchens.OrderBy(c => c.Title);
                    break;
            }

            //Paging
            ViewBag.CurrentSort = sortOrder;

            int pSize = pageSize ?? 3;
            int pageNumber = page ?? 1;

            ViewBag.PageSize = new List<SelectListItem>()
            {
             new SelectListItem() { Value="3", Text= "3" },
             new SelectListItem() { Value="6", Text= "6" },
             new SelectListItem() { Value="12", Text= "12" },
             new SelectListItem() { Value="24", Text= "24" },
             new SelectListItem() { Value="10000000", Text= "All" },
            };

            ViewBag.CurrentPageSize = pSize;

            return View(kitchens.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        public ActionResult AddKitchen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddKitchen(Kitchen model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Kitchens.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Kitchen");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsKitchen(int productId)
        {
            return View(unitOfWork.Kitchens.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditKitchen(int productId)
        {
            return View(unitOfWork.Kitchens.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditKitchen(Kitchen model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Kitchens.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Kitchen");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteKitchen(int productId)
        {
            return View(unitOfWork.Kitchens.GetById(productId));
        }

        [HttpPost, ActionName("DeleteKitchen")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Kitchens.GetById(productId);
            unitOfWork.Kitchens.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Kitchen");
        }
    }
}