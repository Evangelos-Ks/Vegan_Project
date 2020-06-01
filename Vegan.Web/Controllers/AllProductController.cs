using PagedList;
using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Services;
using Vegan.Web.Models;

namespace Vegan.Web.Controllers
{
    public class AllProductController : Controller
    {
        // GET: Default
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        public ActionResult IndexUser(string sortOrder, string searchTitle, int? searchminPrice, int? searchmaxPrice, int? page, int? pSize)
        {
            //================================== Viewbags ====================================
            ViewBag.CurrentTitle = searchTitle;
            ViewBag.CurrentMinPrice = searchminPrice;
            ViewBag.CurrentMaxPrice = searchmaxPrice;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;

            //Viebag that holds the sorting
            ViewBag.TitleSortParam = String.IsNullOrWhiteSpace(sortOrder) ? "TitleDesc" : "";
            ViewBag.PriceSortParam = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";

            ViewBag.TitleView = "badge badge-light";
            ViewBag.PriceView = "badge badge-light";

            AllProductViewModel allProductVM = new AllProductViewModel();

            //============================  Get all the eshop categories ====================
            var homes = unitOfWork.Homes.GetAll();
            var cares = unitOfWork.Cares.GetAll();
            var foodHerbs = unitOfWork.FoodHerbs.GetAll();
            var supplements = unitOfWork.Supplements.GetAll();

            //================================== Sorting ====================================


            //Pagination
            int pageSize = pSize ?? 3;
            int pageNumber = page ?? 1;


            // Assign the sorting - searching to the viewModel
            allProductVM.HomeProducts = homes.ToPagedList(pageNumber, pageSize);
            allProductVM.CareProducts = cares.ToPagedList(pageNumber, pageSize);
            allProductVM.FoodHerbProducts = foodHerbs.ToPagedList(pageNumber, pageSize);
            allProductVM.SupplementProducts = supplements.ToPagedList(pageNumber, pageSize);

            return View(allProductVM);
        }
    }
}