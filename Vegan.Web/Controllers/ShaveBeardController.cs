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
    public class ShaveBeardController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Action Methods =============================================================
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            return View(unitOfWork.ShaveBeards.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all shaveBeards products
            IEnumerable<ShaveBeard> shaveBeards = unitOfWork.ShaveBeards.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                shaveBeards = shaveBeards.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                shaveBeards = shaveBeards.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    shaveBeards = shaveBeards.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    shaveBeards = shaveBeards.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    shaveBeards = shaveBeards.OrderByDescending(c => c.Price);
                    break;
                default:
                    shaveBeards = shaveBeards.OrderBy(c => c.Title);
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

            return View(shaveBeards.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult AddShaveBeard()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult AddShaveBeard(ShaveBeard model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.ShaveBeards.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "ShaveBeard");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult DetailsShaveBeard(int productId)
        {
            return View(unitOfWork.ShaveBeards.GetById(productId));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult EditShaveBeard(int productId)
        {
            return View(unitOfWork.ShaveBeards.GetById(productId));
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult EditShaveBeard(ShaveBeard model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ShaveBeards.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "ShaveBeard");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteShaveBeard(int productId)
        {
            return View(unitOfWork.ShaveBeards.GetById(productId));
        }

        [HttpPost, ActionName("DeleteShaveBeard")]
        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.ShaveBeards.GetById(productId);
            unitOfWork.ShaveBeards.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "ShaveBeard");
        }
    }
}