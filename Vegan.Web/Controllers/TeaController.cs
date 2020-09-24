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
    public class TeaController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Teas.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all Tea products
            IEnumerable<Tea> teas = unitOfWork.Teas.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                teas = teas.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                teas = teas.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    teas = teas.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    teas = teas.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    teas = teas.OrderByDescending(c => c.Price);
                    break;
                default:
                    teas = teas.OrderBy(c => c.Title);
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

            return View(teas.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        public ActionResult AddTea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTea(Tea model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Teas.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Tea");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsTea(int productId)
        {
            return View(unitOfWork.Teas.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditTea(int productId)
        {
            return View(unitOfWork.Teas.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditTea(Tea model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Teas.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Tea");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteTea(int productId)
        {
            return View(unitOfWork.Teas.GetById(productId));
        }

        [HttpPost, ActionName("DeleteTea")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Teas.GetById(productId);
            unitOfWork.Teas.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Tea");
        }
    }
}