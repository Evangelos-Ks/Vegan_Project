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
    public class SaltController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Salts.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all salt products
            IEnumerable<Salt> salts = unitOfWork.Salts.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                salts = salts.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                salts = salts.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    salts = salts.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    salts = salts.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    salts = salts.OrderByDescending(c => c.Price);
                    break;
                default:
                    salts = salts.OrderBy(c => c.Title);
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

            return View(salts.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        public ActionResult AddSalt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSalt(Salt model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Salts.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Salt");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsSalt(int productId)
        {
            return View(unitOfWork.Salts.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditSalt(int productId)
        {
            return View(unitOfWork.Salts.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditSalt(Salt model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Salts.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Salt");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteSalt(int productId)
        {
            return View(unitOfWork.Salts.GetById(productId));
        }

        [HttpPost, ActionName("DeleteSalt")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Salts.GetById(productId);
            unitOfWork.Salts.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Salt");
        }
    }
}