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
    public class TestUFaceCreamController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork<MyDatabase> unitOfWork = new UnitOfWork<MyDatabase>();
        private GenericRepository<FaceCream> repository;

        //===================================== Constructor ================================================================
        public TestUFaceCreamController()
        {
            repository = new GenericRepository<FaceCream>(unitOfWork);
        }

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            var products = repository.GetAll();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddFaceCream()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFaceCream(FaceCream model)
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
                    return RedirectToAction("Index", "TestUFaceCream");
                }
            }
            catch (Exception ex)
            {
                //Log the exception and rollback the transaction
                unitOfWork.Rollback();
            }
            return View();
        }

        public ActionResult DetailsFaceCream(int productId)
        {
            FaceCream productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpGet]
        public ActionResult EditFaceCream(int productId)
        {
            FaceCream productModel = repository.GetByID(productId);
            return View(productModel);
        }

        [HttpPost]
        public ActionResult EditFaceCream(FaceCream model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                unitOfWork.Save();
                return RedirectToAction("Index", "TestUFaceCream");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteFaceCream(int productId)
        {
            FaceCream product = repository.GetByID(productId);
            return View(product);
        }

        [HttpPost, ActionName("DeleteFaceCream")]
        public ActionResult Delete(int productId)
        {
            FaceCream product = repository.GetByID(productId);
            repository.Delete(product);
            unitOfWork.Save();
            return RedirectToAction("Index", "TestUFaceCream");
        }
    }
}