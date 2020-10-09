using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class SproutingSeedController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            return View(unitOfWork.SproutingSeeds.GetAll());
        }

        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all SproutingSeed products
            IEnumerable<SproutingSeed> sproutingSeeds = unitOfWork.SproutingSeeds.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                sproutingSeeds = sproutingSeeds.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                sproutingSeeds = sproutingSeeds.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    sproutingSeeds = sproutingSeeds.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    sproutingSeeds = sproutingSeeds.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    sproutingSeeds = sproutingSeeds.OrderByDescending(c => c.Price);
                    break;
                default:
                    sproutingSeeds = sproutingSeeds.OrderBy(c => c.Title);
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

            return View(sproutingSeeds.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult AddSproutingSeed()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult AddSproutingSeed(SproutingSeed model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.SproutingSeeds.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "SproutingSeed");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult DetailsSproutingSeed(int productId)
        {
            return View(unitOfWork.SproutingSeeds.GetById(productId));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult EditSproutingSeed(int productId)
        {
            return View(unitOfWork.SproutingSeeds.GetById(productId));
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult EditSproutingSeed(SproutingSeed model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SproutingSeeds.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "SproutingSeed");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteSproutingSeed(int productId)
        {
            return View(unitOfWork.SproutingSeeds.GetById(productId));
        }

        [HttpPost, ActionName("DeleteSproutingSeed")]
        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.SproutingSeeds.GetById(productId);
            unitOfWork.SproutingSeeds.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "SproutingSeed");
        }
    }
}