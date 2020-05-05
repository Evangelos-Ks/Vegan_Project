//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Vegan.Database;
//using Vegan.Entities;
//using Vegan.Services;
//using System.ComponentModel.DataAnnotations;
//using Vegan.Entities.Care;
//using Vegan.Entities.FoodHerb;

//namespace Vegan.Web.Controllers
//{
//    public class SproutingSeedController : Controller
//    {
//        //===================================== Fields =====================================================================
//        private UnitOfWork<MyDatabase> unitOfWork = new UnitOfWork<MyDatabase>();
//        private GenericRepository<SproutingSeed> repository;

//        //===================================== Constructor ================================================================
//        public SproutingSeedController()
//        {
//            repository = new GenericRepository<SproutingSeed>(unitOfWork);
//        }

//        //===================================== Methods ====================================================================
//        [HttpGet]
//        public ActionResult Index()
//        {
//            var products = repository.GetAll();
//            return View(products);
//        }

//        [HttpGet]
//        public ActionResult AddSproutingSeed()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult AddSproutingSeed(SproutingSeed model)
//        {
//            try
//            {
//                unitOfWork.CreateTransaction();
//                if (ModelState.IsValid)
//                {
//                    repository.Insert(model);
//                    unitOfWork.Save();
//                    //Do Some Other Task with the Database
//                    //If everything is working then commit the transaction else rollback the transaction
//                    unitOfWork.Commit();
//                    return RedirectToAction("Index", "SproutingSeed");
//                }
//            }
//            catch (Exception ex)
//            {
//                //Log the exception and rollback the transaction
//                unitOfWork.Rollback();
//            }
//            return View();
//        }

//        public ActionResult DetailsSproutingSeed(int productId)
//        {
//            Product productModel = repository.GetByID(productId);
//            return View(productModel);
//        }

//        [HttpGet]
//        public ActionResult EditSproutingSeed(int productId)
//        {
//            SproutingSeed productModel = repository.GetByID(productId);
//            return View(productModel);
//        }

//        [HttpPost]
//        public ActionResult EditSproutingSeed(SproutingSeed model)
//        {
//            if (ModelState.IsValid)
//            {
//                repository.Update(model);
//                unitOfWork.Save();
//                return RedirectToAction("Index", "SproutingSeed");
//            }
//            else
//            {
//                return View(model);
//            }
//        }

//        [HttpGet]
//        public ActionResult DeleteSproutingSeed(int productId)
//        {
//            SproutingSeed product = repository.GetByID(productId);
//            return View(product);
//        }

//        [HttpPost, ActionName("DeleteSproutingSeed")]
//        public ActionResult Delete(int productId)
//        {
//            SproutingSeed product = repository.GetByID(productId);
//            repository.Delete(product);
//            unitOfWork.Save();
//            return RedirectToAction("Index", "SproutingSeed");
//        }
//    }
//}