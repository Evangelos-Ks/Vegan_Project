using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Supplement;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class SuperFoodController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Action Methods =============================================================
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            return View(unitOfWork.SuperFoods.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all superfood products
            IEnumerable<SuperFood> superfoods = unitOfWork.SuperFoods.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                superfoods = superfoods.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                superfoods = superfoods.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    superfoods = superfoods.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    superfoods = superfoods.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    superfoods = superfoods.OrderByDescending(c => c.Price);
                    break;
                default:
                    superfoods = superfoods.OrderBy(c => c.Title);
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

            return View(superfoods.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult AddSuperFood()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult AddSuperFood(SuperFood model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.SuperFoods.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "SuperFood");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult DetailsSuperFood(int productId)
        {
            return View(unitOfWork.SuperFoods.GetById(productId));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult EditSuperFood(int productId)
        {
            return View(unitOfWork.SuperFoods.GetById(productId));
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult EditSuperFood(SuperFood model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SuperFoods.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "SuperFood");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteSuperFood(int productId)
        {
            return View(unitOfWork.SuperFoods.GetById(productId));
        }

        [HttpPost, ActionName("DeleteSuperFood")]
        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.SuperFoods.GetById(productId);
            unitOfWork.SuperFoods.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "SuperFood");
        }
    }
}