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

namespace Vegan.Web.Controllers
{
    public class TestUCareController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork<MyDatabase> unitOfWork = new UnitOfWork<MyDatabase>();
        private GenericRepository<Care> repository;

        //===================================== Constructor ================================================================
        public TestUCareController()
        {
            repository = new GenericRepository<Care>(unitOfWork);
        }

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            var products = repository.GetAll();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddCare()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCare(Care model)
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
                    return RedirectToAction("Index", "Care");
                }
            }
            catch (Exception ex)
            {
                //Log the exception and rollback the transaction
                unitOfWork.Rollback();
            }
            return View();
        }

        public ActionResult DetailsCare(int productId)
        {
            Care productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpGet]
        public ActionResult EditCare(int productId)
        {
            Care productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpPost]
        public ActionResult EditCare(Care model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                unitOfWork.Save();
                return RedirectToAction("Index", "Care");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteCare(int productId)
        {
            Care product = repository.GetByID(productId);
            return View(product);
        }

        [HttpPost, ActionName("DeleteCare")]
        public ActionResult Delete(int productId)
        {
            Care product = repository.GetByID(productId);
            repository.Delete(product);
            unitOfWork.Save();
            return RedirectToAction("Index", "Care");
        }
    }
}