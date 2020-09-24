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
    public class PowerHealthController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.PowerHealths.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all PowerHealth products
            IEnumerable<PowerHealth> powerHealths = unitOfWork.PowerHealths.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                powerHealths = powerHealths.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                powerHealths = powerHealths.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    powerHealths = powerHealths.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    powerHealths = powerHealths.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    powerHealths = powerHealths.OrderByDescending(c => c.Price);
                    break;
                default:
                    powerHealths = powerHealths.OrderBy(c => c.Title);
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

            return View(powerHealths.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        public ActionResult AddPowerHealth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPowerHealth(PowerHealth model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.PowerHealths.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "PowerHealth");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsPowerHealth(int productId)
        {
            return View(unitOfWork.PowerHealths.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditPowerHealth(int productId)
        {
            return View(unitOfWork.PowerHealths.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditPowerHealth(PowerHealth model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PowerHealths.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "PowerHealth");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeletePowerHealth(int productId)
        {
            return View(unitOfWork.PowerHealths.GetById(productId));
        }

        [HttpPost, ActionName("DeletePowerHealth")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.PowerHealths.GetById(productId);
            unitOfWork.PowerHealths.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "PowerHealth");
        }
    }
}