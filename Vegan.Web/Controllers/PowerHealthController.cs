using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Supplement;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class PowerHealthController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]

        public ActionResult Index()
        {
            return View(unitOfWork.PowerHealths.GetAll());
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.PowerHealths.GetAll());
        }

        [HttpGet]
        public ActionResult AddPowerHealth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPowerHealth(PowerHealth model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.PowerHealths.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "PowerHealth");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsPowerHealth(int productId)
        {
            return View(unitOfWork.PowerHealths.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditPowerHealth(int productId)
        {
            return View(unitOfWork.PowerHealths.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditPowerHealth(PowerHealth model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PowerHealths.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "PowerHealth");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeletePowerHealth(int productId)
        {
            return View(unitOfWork.PowerHealths.GetById(productId));
        }

        [HttpPost, ActionName("DeletePowerHealth")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.PowerHealths.GetById(productId);
            unitOfWork.PowerHealths.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "PowerHealth");
        }
    }
}