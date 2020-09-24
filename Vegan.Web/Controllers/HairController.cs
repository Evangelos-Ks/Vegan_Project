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
    public class HairController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Action Methods =============================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Hairs.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all hair products
            IEnumerable<Hair> hairs = unitOfWork.Hairs.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                hairs = hairs.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                hairs = hairs.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    hairs = hairs.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    hairs = hairs.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    hairs = hairs.OrderByDescending(c => c.Price);
                    break;
                default:
                    hairs = hairs.OrderBy(c => c.Title);
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

            return View(hairs.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        public ActionResult AddHair()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHair(Hair model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Hairs.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Hair");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsHair(int productId)
        {
            return View(unitOfWork.Hairs.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditHair(int productId)
        {
            return View(unitOfWork.Hairs.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditHair(Hair model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Hairs.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Hair");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteHair(int productId)
        {
            return View(unitOfWork.Hairs.GetById(productId));
        }

        [HttpPost, ActionName("DeleteHair")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Hairs.GetById(productId);
            unitOfWork.Hairs.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Hair");
        }
    }
}