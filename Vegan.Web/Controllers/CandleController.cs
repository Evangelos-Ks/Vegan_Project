using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Services;


namespace Vegan.Web.Controllers
{
    public class CandleController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
     // [Authorize(Roles = "Admins, Supervisors")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Candles.GetAll());
        }
        public ActionResult IndexUser(string sortOrder, string searchTitle, int? searchminPrice, int? searchmaxPrice, int? page, int? pSize)
        {
            //================================== Viewbags ====================================
            ViewBag.CurrentTitle = searchTitle;
            ViewBag.CurrentMinPrice = searchminPrice;
            ViewBag.CurrentMaxPrice = searchmaxPrice;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;


            //ViewBag.CurrentPage = page;

            //Viebag that holds the sorting
            ViewBag.TitleSortParam = String.IsNullOrWhiteSpace(sortOrder) ? "TitleDesc" : "";
            ViewBag.PriceSortParam = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";

            ViewBag.TitleView = "badge badge-light";
            ViewBag.PriceView = "badge badge-light";

            var candles = unitOfWork.Candles.GetAll();

            //================================== Sorting ====================================


            //Sorting by title & price
            switch (sortOrder)
            {
                case "TitleDesc": candles = candles.OrderByDescending(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
                case "TitleAsc": candles = candles.OrderBy(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
                case "PriceDesc": candles = candles.OrderByDescending(x => x.Price); ViewBag.PriceView = "badge badge-secondary"; break;
                case "PriceAsc": candles = candles.OrderBy(x => x.Price); ViewBag.PriceView = "badge badge-secondary"; break;
                default: candles = candles.OrderBy(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
            }
            //Pagination
            int pageSize = pSize ?? 3;
            int pageNumber = page ?? 1;


            //================================== Filters ====================================

            //------Filtering  Title-----
            if (!(string.IsNullOrWhiteSpace(searchTitle)))
            {
                candles = candles.Where(x => x.Title.ToUpper().Contains(searchTitle.ToUpper()));
            }
            //-----Filtering  Price------
            //Filtering  Minimum
            if (!(searchminPrice is null))
            {
                candles = candles.Where(x => x.Price >= searchminPrice);
            }
            //Filtering  Maximum
            if (!(searchmaxPrice is null))
            {
                candles = candles.Where(x => x.Price <= searchmaxPrice);
            }
           

            // Assign the sorting - searching to the viewModel
            candles = candles.ToPagedList(pageNumber, pageSize);

            return View(candles);


        }



        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddCandle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCandle(Candle model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Candles.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Candle");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsCandle(int productId)
        {

            return View(unitOfWork.Candles.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditCandle(int productId)
        {

            return View(unitOfWork.Candles.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditCandle(Candle model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Candles.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Candle");
            }
            else
            {
                return View(model);
            }
        }

    

        [HttpGet]
        public ActionResult DeleteCandle(int productId)
        {
            return View(unitOfWork.Candles.GetById(productId));
        }

        [HttpPost, ActionName("DeleteCandle")]
        public ActionResult DeletePost(int productId)
        {

            var product = unitOfWork.Candles.GetById(productId);
            unitOfWork.Candles.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Candle");
        }
    }
}