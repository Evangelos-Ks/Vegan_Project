using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class SproutingSeedController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.SproutingSeeds.GetAll());
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.SproutingSeeds.GetAll());
        }

        [HttpGet]
        public ActionResult AddSproutingSeed()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSproutingSeed(SproutingSeed model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.SproutingSeeds.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "SproutingSeed");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult DetailsSproutingSeed(int productId)
        {
            return View(unitOfWork.SproutingSeeds.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditSproutingSeed(int productId)
        {
            return View(unitOfWork.SproutingSeeds.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditSproutingSeed(SproutingSeed model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SproutingSeeds.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "SproutingSeed");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteSproutingSeed(int productId)
        {
            return View(unitOfWork.SproutingSeeds.GetById(productId));
        }

        [HttpPost, ActionName("DeleteSproutingSeed")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.SproutingSeeds.GetById(productId);
            unitOfWork.SproutingSeeds.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "SproutingSeed");
        }
    }
}