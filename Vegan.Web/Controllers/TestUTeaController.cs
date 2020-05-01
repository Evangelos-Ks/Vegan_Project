using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;
using System.ComponentModel.DataAnnotations;
using Vegan.Entities.FoodHerb;

namespace Vegan.Web.Controllers.TestControllers
{
    public class TestUTeaController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork<MyDatabase> unitOfWork = new UnitOfWork<MyDatabase>();
        private GenericRepository<Tea> repository;

        //===================================== Constructor ================================================================
        public TestUTeaController()
        {
            repository = new GenericRepository<Tea>(unitOfWork);
        }

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            var products = repository.GetAll();
            return View(products);
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
                unitOfWork.CreateTransaction();
                if (ModelState.IsValid)
                {
                    repository.Insert(model);
                    unitOfWork.Save();
                    //Do Some Other Task with the Database
                    //If everything is working then commit the transaction else rollback the transaction
                    unitOfWork.Commit();
                    return RedirectToAction("Index", "TestUTea");
                }
            }
            catch (Exception ex)
            {
                //Log the exception and rollback the transaction
                unitOfWork.Rollback();
            }
            return View();
        }

        public ActionResult DetailsTea(int productId)
        {
            Tea productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpGet]
        public ActionResult EditTea(int productId)
        {
            Tea productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpPost]
        public ActionResult EditTea(Tea model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                unitOfWork.Save();
                return RedirectToAction("Index", "TestUTea");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteTea(int productId)
        {
            Tea product = repository.GetByID(productId);
            return View(product);
        }

        [HttpPost, ActionName("DeleteTea")]
        public ActionResult Delete(int productId)
        {
            Tea product = repository.GetByID(productId);
            repository.Delete(product);
            unitOfWork.Save();
            return RedirectToAction("Index", "TestUTea");
        }
    }
}