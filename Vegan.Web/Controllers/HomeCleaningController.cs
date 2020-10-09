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
    public class HomeCleaningController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            return View(unitOfWork.HomeCleanings.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all homeCleanings
            IEnumerable<HomeCleaning> homeCleanings = unitOfWork.HomeCleanings.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                homeCleanings = homeCleanings.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                homeCleanings = homeCleanings.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    homeCleanings = homeCleanings.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    homeCleanings = homeCleanings.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    homeCleanings = homeCleanings.OrderByDescending(c => c.Price);
                    break;
                default:
                    homeCleanings = homeCleanings.OrderBy(c => c.Title);
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

            return View(homeCleanings.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult AddHomeCleaning()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult AddHomeCleaning(HomeCleaning model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.HomeCleanings.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "HomeCleaning");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsHomeCleaning(int productId)
        {
            return View(unitOfWork.HomeCleanings.GetById(productId));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult EditHomeCleaning(int productId)
        {
            return View(unitOfWork.HomeCleanings.GetById(productId));
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult EditHomeCleaning(HomeCleaning model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HomeCleanings.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "HomeCleaning");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteHomeCleaning(int productId)
        {
            return View(unitOfWork.HomeCleanings.GetById(productId));
        }

        [HttpPost, ActionName("DeleteHomeCleaning")]
        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.HomeCleanings.GetById(productId);
            unitOfWork.HomeCleanings.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "HomeCleaning");
        }
    }
}