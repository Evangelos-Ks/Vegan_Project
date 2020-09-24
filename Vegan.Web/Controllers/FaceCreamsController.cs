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
    public class FaceCreamsController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Action Method ==============================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.FaceCreams.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser(string sortOrder, int? minPrice, int? maxPrice, int? page, int? pageSize)
        {
            //Get all faceCream products
            IEnumerable<FaceCream> faceCreams = unitOfWork.FaceCreams.GetAll().ToList();
            unitOfWork.Dispose();

            //Filter
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            if (minPrice != null)
            {
                faceCreams = faceCreams.Where(c => c.Price >= minPrice);
            }

            if (maxPrice != null)
            {
                faceCreams = faceCreams.Where(c => c.Price <= maxPrice);
            }

            //Sorting
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            switch (sortOrder)
            {
                case "title_desc":
                    faceCreams = faceCreams.OrderByDescending(c => c.Title);
                    break;
                case "price_asc":
                    faceCreams = faceCreams.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    faceCreams = faceCreams.OrderByDescending(c => c.Price);
                    break;
                default:
                    faceCreams = faceCreams.OrderBy(c => c.Title);
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

            return View(faceCreams.ToPagedList(pageNumber, pSize));
        }

        [HttpGet]
        public ActionResult AddFaceCream()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFaceCream(FaceCream model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.FaceCreams.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "FaceCreams");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsFaceCream(int productId)
        {
            return View(unitOfWork.FaceCreams.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditFaceCream(int productId)
        {
            return View(unitOfWork.FaceCreams.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditFaceCream(FaceCream model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FaceCreams.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "FaceCreams");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteFaceCream(int productId)
        {
            return View(unitOfWork.FaceCreams.GetById(productId));
        }

        [HttpPost, ActionName("DeleteFaceCream")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.FaceCreams.GetById(productId);
            unitOfWork.FaceCreams.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "FaceCreams");
        }
    }
}