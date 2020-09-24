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
    public class SpiceController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Action Methods =============================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Spices.GetAll());
        }

        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all spice products
            IEnumerable<Spice> spices = unitOfWork.Spices.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                spices = spices.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                spices = spices.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    spices = spices.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    spices = spices.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    spices = spices.OrderByDescending(c => c.Price);
                    break;
                default:
                    spices = spices.OrderBy(c => c.Title);
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

            return View(spices.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        public ActionResult AddSpice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSpice(Spice model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Spices.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Spice");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsSpice(int productId)
        {
            return View(unitOfWork.Spices.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditSpice(int productId)
        {
            return View(unitOfWork.Spices.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditSpice(Spice model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Spices.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Spice");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteSpice(int productId)
        {
            return View(unitOfWork.Spices.GetById(productId));
        }

        [HttpPost, ActionName("DeleteSpice")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Spices.GetById(productId);
            unitOfWork.Spices.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Spice");
        }
    }
}