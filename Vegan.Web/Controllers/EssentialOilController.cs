using PagedList;
using System;
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
        // [Authorize(Roles = "Admins, Supervisors")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.EssentialOils.GetAll());
        }

        [HttpGet]

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

            var essentialOils = unitOfWork.EssentialOils.GetAll();

            //================================== Sorting ====================================


            //Sorting by title & price
            switch (sortOrder)
            {
                case "TitleDesc": essentialOils = essentialOils.OrderByDescending(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
                case "TitleAsc": essentialOils = essentialOils.OrderBy(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
                case "PriceDesc": essentialOils = essentialOils.OrderByDescending(x => x.Price); ViewBag.PriceView = "badge badge-secondary"; break;
                case "PriceAsc": essentialOils = essentialOils.OrderBy(x => x.Price); ViewBag.PriceView = "badge badge-secondary"; break;
                default: essentialOils = essentialOils.OrderBy(x => x.Title).ThenBy(x => x.Price); ViewBag.TitleView = "badge badge-secondary"; break;
            }
            //Pagination
            int pageSize = pSize ?? 3;
            int pageNumber = page ?? 1;


            //================================== Filters ====================================

            //------Filtering  Title-----
            if (searchTitle == null)
            {
                essentialOils = unitOfWork.EssentialOils.GetAll();

            }
            else if (!(string.IsNullOrWhiteSpace(searchTitle)))
            {
                essentialOils = essentialOils.Where(x => x.Title.ToUpper().Contains(searchTitle.ToUpper()));
            }
            //-----Filtering  Price------
            //Filtering  Minimum
            if (!(searchminPrice is null))
            {
                essentialOils = essentialOils.Where(x => x.Price >= searchminPrice);
            }
            //Filtering  Maximum
            if (!(searchmaxPrice is null))
            {
                essentialOils = essentialOils.Where(x => x.Price <= searchmaxPrice);
            }


            // Assign the sorting - searching to the viewModel
            essentialOils = essentialOils.ToPagedList(pageNumber, pageSize);

            return View(essentialOils);



        }


        [HttpGet]
        public ActionResult AddEssentialOil()
        {
            return View();
        }

        [HttpPost]
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
        public ActionResult EditEssentialOil(int productId)
        {
            return View(unitOfWork.EssentialOils.GetById(productId));
        }

        [HttpPost]
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
        public ActionResult DeleteEssentialOil(int productId)
        {
            return View(unitOfWork.EssentialOils.GetById(productId));
        }

        [HttpPost, ActionName("DeleteEssentialOil")]
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
