using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class HairController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
     // [Authorize(Roles = "Admins, Supervisors")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.Hairs.GetAll());
        }   
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.Hairs.GetAll());
        }

        [HttpGet]
        public ActionResult AddHair()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHair(Hair model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Hairs.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Hair");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsHair(int productId)
        {
            return View(unitOfWork.Hairs.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditHair(int productId)
        {
            return View(unitOfWork.Hairs.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditHair(Hair model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Hairs.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Hair");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteHair(int productId)
        {
            return View(unitOfWork.Hairs.GetById(productId));
        }

        [HttpPost, ActionName("DeleteHair")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Hairs.GetById(productId);
            unitOfWork.Hairs.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Hair");
        }
    }
}