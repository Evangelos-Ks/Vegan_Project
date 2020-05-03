using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;
using System.ComponentModel.DataAnnotations;
using Vegan.Entities.Care;
using Vegan.Entities.Supplement;

namespace Vegan.Web.Controllers
{
    public class PowerHealthController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork<MyDatabase> unitOfWork = new UnitOfWork<MyDatabase>();
        private GenericRepository<PowerHealth> repository;

        //===================================== Constructor ================================================================
        public PowerHealthController()
        {
            repository = new GenericRepository<PowerHealth>(unitOfWork);
        }

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            var products = repository.GetAll();
            return View(products);
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
                unitOfWork.CreateTransaction();
                if (ModelState.IsValid)
                {
                    repository.Insert(model);
                    unitOfWork.Save();
                    //Do Some Other Task with the Database
                    //If everything is working then commit the transaction else rollback the transaction
                    unitOfWork.Commit();
                    return RedirectToAction("Index", "PowerHealth");
                }
            }
            catch (Exception ex)
            {
                //Log the exception and rollback the transaction
                unitOfWork.Rollback();
            }
            return View();
        }

        public ActionResult DetailsPowerHealth(int productId)
        {
            Product productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpGet]
        public ActionResult EditPowerHealth(int productId)
        {
            PowerHealth productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpPost]
        public ActionResult EditPowerHealth(PowerHealth model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                unitOfWork.Save();
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
            PowerHealth product = repository.GetByID(productId);
            return View(product);
        }

        [HttpPost, ActionName("DeletePowerHealth")]
        public ActionResult Delete(int productId)
        {
            PowerHealth product = repository.GetByID(productId);
            repository.Delete(product);
            unitOfWork.Save();
            return RedirectToAction("Index", "PowerHealth");
        }
    }
}