using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class LotionController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.Lotions.GetAll());
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.Lotions.GetAll());
        }

        [HttpGet]
        public ActionResult AddLotion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLotion(Lotion model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Lotions.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Lotion");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsLotion(int productId)
        {
            return View(unitOfWork.Lotions.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditLotion(int productId)
        {
            return View(unitOfWork.Lotions.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditLotion(Lotion model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Lotions.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Lotion");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteLotion(int productId)
        {
            return View(unitOfWork.Lotions.GetById(productId));
        }

        [HttpPost, ActionName("DeleteLotion")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Lotions.GetById(productId);
            unitOfWork.Lotions.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Lotion");
        }
    }
}