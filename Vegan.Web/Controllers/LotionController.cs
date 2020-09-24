using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class LotionController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Action Methods =============================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Lotions.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all hair products
            IEnumerable<Lotion> lotions = unitOfWork.Lotions.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                lotions = lotions.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                lotions = lotions.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    lotions = lotions.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    lotions = lotions.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    lotions = lotions.OrderByDescending(c => c.Price);
                    break;
                default:
                    lotions = lotions.OrderBy(c => c.Title);
                    break;
            }

            //Paging
            ViewBag.CurrentSort = sortOrder;

            int pSize = pageSize ?? 6;
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

            return View(lotions.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        public ActionResult AddLotion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLotion(Lotion model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Lotions.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Lotion");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsLotion(int productId)
        {
            return View(unitOfWork.Lotions.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditLotion(int productId)
        {
            return View(unitOfWork.Lotions.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditLotion(Lotion model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Lotions.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Lotion");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteLotion(int productId)
        {
            return View(unitOfWork.Lotions.GetById(productId));
        }

        [HttpPost, ActionName("DeleteLotion")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Lotions.GetById(productId);
            unitOfWork.Lotions.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Lotion");
        }
    }
}