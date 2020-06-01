using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class HomeCleaningController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
     // [Authorize(Roles = "Admins, Supervisors")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.HomeCleanings.GetAll());
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.HomeCleanings.GetAll());
        }

        [HttpGet]
        public ActionResult AddHomeCleaning()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHomeCleaning(HomeCleaning model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.HomeCleanings.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "HomeCleaning");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsHomeCleaning(int productId)
        {
            return View(unitOfWork.HomeCleanings.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditHomeCleaning(int productId)
        {
            return View(unitOfWork.HomeCleanings.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditHomeCleaning(HomeCleaning model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HomeCleanings.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "HomeCleaning");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteHomeCleaning(int productId)
        {
            return View(unitOfWork.HomeCleanings.GetById(productId));
        }

        [HttpPost, ActionName("DeleteHomeCleaning")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.HomeCleanings.GetById(productId);
            unitOfWork.HomeCleanings.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "HomeCleaning");
        }
    }
}