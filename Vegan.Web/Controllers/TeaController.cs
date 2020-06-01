using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class TeaController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.Teas.GetAll());
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.Teas.GetAll());
        }

        [HttpGet]
        public ActionResult AddTea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTea(Tea model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Teas.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Tea");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsTea(int productId)
        {
            return View(unitOfWork.Teas.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditTea(int productId)
        {
            return View(unitOfWork.Teas.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditTea(Tea model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Teas.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Tea");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteTea(int productId)
        {
            return View(unitOfWork.Teas.GetById(productId));
        }

        [HttpPost, ActionName("DeleteTea")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Teas.GetById(productId);
            unitOfWork.Teas.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Tea");
        }
    }
}