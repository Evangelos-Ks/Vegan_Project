using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Supplement;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class SuperFoodController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.SuperFoods.GetAll());
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.SuperFoods.GetAll());
        }

        [HttpGet]
        public ActionResult AddSuperFood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSuperFood(SuperFood model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.SuperFoods.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "SuperFood");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult DetailsSuperFood(int productId)
        {
            return View(unitOfWork.SuperFoods.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditSuperFood(int productId)
        {
            return View(unitOfWork.SuperFoods.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditSuperFood(SuperFood model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SuperFoods.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "SuperFood");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteSuperFood(int productId)
        {
            return View(unitOfWork.SuperFoods.GetById(productId));
        }

        [HttpPost, ActionName("DeleteSuperFood")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.SuperFoods.GetById(productId);
            unitOfWork.SuperFoods.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "SuperFood");
        }
    }
}