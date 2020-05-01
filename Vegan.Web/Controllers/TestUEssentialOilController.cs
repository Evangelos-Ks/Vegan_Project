using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;
using System.ComponentModel.DataAnnotations;
using Vegan.Entities.Home;

namespace Vegan.Web.Controllers.TestControllers
{
    public class TestUEssentialOilController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork<MyDatabase> unitOfWork = new UnitOfWork<MyDatabase>();
        private GenericRepository<EssentialOil> repository;

        //===================================== Constructor ================================================================
        public TestUEssentialOilController()
        {
            repository = new GenericRepository<EssentialOil>(unitOfWork);
        }

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            var products = repository.GetAll();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddEssentialOil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEssentialOil(EssentialOil model)
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
                    return RedirectToAction("Index", "TestUEssentialOil");
                }
            }
            catch (Exception ex)
            {
                //Log the exception and rollback the transaction
                unitOfWork.Rollback();
            }
            return View();
        }

        public ActionResult DetailsEssentialOil(int productId)
        {
            EssentialOil productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpGet]
        public ActionResult EditEssentialOil(int productId)
        {
            EssentialOil productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpPost]
        public ActionResult EditEssentialOil(EssentialOil model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                unitOfWork.Save();
                return RedirectToAction("Index", "TestUEssentialOil");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteEssentialOil(int productId)
        {
            EssentialOil product = repository.GetByID(productId);
            return View(product);
        }

        [HttpPost, ActionName("DeleteEssentialOil")]
        public ActionResult Delete(int productId)
        {
            EssentialOil product = repository.GetByID(productId);
            repository.Delete(product);
            unitOfWork.Save();
            return RedirectToAction("Index", "TestUEssentialOil");
        }
    }
}