using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class SaltController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.Salts.GetAll());
        } 
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.Salts.GetAll());
        }

        [HttpGet]
        public ActionResult AddSalt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSalt(Salt model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Salts.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Salt");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsSalt(int productId)
        {
            return View(unitOfWork.Salts.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditSalt(int productId)
        {
            return View(unitOfWork.Salts.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditSalt(Salt model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Salts.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Salt");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteSalt(int productId)
        {
            return View(unitOfWork.Salts.GetById(productId));
        }

        [HttpPost, ActionName("DeleteSalt")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Salts.GetById(productId);
            unitOfWork.Salts.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Salt");
        }
    }
}