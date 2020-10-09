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
    public class EssentialOilController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            return View(unitOfWork.EssentialOils.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all essentialOils
            IEnumerable<EssentialOil> essentialOils = unitOfWork.EssentialOils.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                essentialOils = essentialOils.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                essentialOils = essentialOils.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    essentialOils = essentialOils.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    essentialOils = essentialOils.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    essentialOils = essentialOils.OrderByDescending(c => c.Price);
                    break;
                default:
                    essentialOils = essentialOils.OrderBy(c => c.Title);
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

            return View(essentialOils.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult AddEssentialOil()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult AddEssentialOil(EssentialOil model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.EssentialOils.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "EssentialOil");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsEssentialOil(int productId)
        {
            return View(unitOfWork.EssentialOils.GetById(productId));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult EditEssentialOil(int productId)
        {
            return View(unitOfWork.EssentialOils.GetById(productId));
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult EditEssentialOil(EssentialOil model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EssentialOils.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "EssentialOil");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteEssentialOil(int productId)
        {
            return View(unitOfWork.EssentialOils.GetById(productId));
        }

        [HttpPost, ActionName("DeleteEssentialOil")]
        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.EssentialOils.GetById(productId);
            unitOfWork.EssentialOils.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "EssentialOil");
        }
    }
}
