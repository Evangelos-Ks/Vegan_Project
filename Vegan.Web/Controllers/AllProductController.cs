using PagedList;
using System;
using System.Linq;
using System.Web;
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


            //Sorting by title & price
            switch (sortOrder)
            {
                case "TitleDesc": homes = homes.OrderByDescending(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
                case "TitleAsc": homes = homes.OrderBy(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
                case "PriceDesc": homes = homes.OrderByDescending(x => x.Price); ViewBag.PriceView = "badge badge-secondary"; break;
                case "PriceAsc": homes = homes.OrderBy(x => x.Price); ViewBag.PriceView = "badge badge-secondary"; break;
                default: homes = homes.OrderBy(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
            }
            //Pagination
            int pageSize = pSize ?? 3;
            int pageNumber = page ?? 1;


            //================================== Filters ====================================

            //Filtering  Title
            if (!string.IsNullOrWhiteSpace(searchTitle))
            {
                homes = homes.Where(x => x.Title.ToUpper().Contains(searchTitle.ToUpper()));
            }
            //Filtering  Price
            //Filtering  Minimum
            if (!(searchminPrice is null))
            {
                homes = homes.Where(x => x.Price >= searchminPrice);
            }
            //Filtering  Maximum
            if (!(searchmaxPrice is null))
            {
                homes = homes.Where(x => x.Price <= searchmaxPrice);
            }

            // Assign the sorting - searching to the viewModel
            allProductVM.HomeProducts = homes.ToPagedList(pageNumber, pageSize);
            allProductVM.CareProducts = cares.ToPagedList(pageNumber, pageSize);
            allProductVM.FoodHerbProducts = foodHerbs.ToPagedList(pageNumber, pageSize);
            allProductVM.SupplementProducts = supplements.ToPagedList(pageNumber, pageSize);

            return View(allProductVM);
        }



    }
}