using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class SpiceController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.Spices.GetAll());
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.Spices.GetAll());
        }

        [HttpGet]
        public ActionResult AddSpice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSpice(Spice model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Spices.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Spice");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsSpice(int productId)
        {
            return View(unitOfWork.Spices.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditSpice(int productId)
        {
            return View(unitOfWork.Spices.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditSpice(Spice model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Spices.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Spice");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteSpice(int productId)
        {
            return View(unitOfWork.Spices.GetById(productId));
        }

        [HttpPost, ActionName("DeleteSpice")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Spices.GetById(productId);
            unitOfWork.Spices.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Spice");
        }
    }
}