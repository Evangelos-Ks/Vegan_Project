//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Vegan.Database;
//using Vegan.Entities;
//using Vegan.Services;
//using System.ComponentModel.DataAnnotations;

//namespace Vegan.Web.Controllers.TestControllers
//{
//    public class TestUProductController : Controller
//    {
//        //===================================== Fields =====================================================================
//        private UnitOfWork<MyDatabase> unitOfWork = new UnitOfWork<MyDatabase>();
//        private GenericRepository<Product> repository;

//        //===================================== Constructor ================================================================
//        public TestUProductController()
//        {
//            repository = new GenericRepository<Product>(unitOfWork);
//        }

//        //===================================== Methods ====================================================================
//        [HttpGet]
//        public ActionResult Index()
//        {
//            var products = repository.GetAll();
//            return View(products);
//        }

//        [HttpGet]
//        public ActionResult AddProduct()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult AddProduct(Product model)
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
//                    return RedirectToAction("Index", "TestUProduct");
//                }
//            }
//            catch (Exception ex)
//            {
//                //Log the exception and rollback the transaction
//                unitOfWork.Rollback();
//            }
//            return View();
//        }

//        public ActionResult DetailsProduct(int productId)
//        {
//            Product productModel = repository.GetByID(productId);
//            return View(productModel);
//        }

//        [HttpGet]
//        public ActionResult EditProduct(int productId)
//        {
//            Product productModel = repository.GetByID(productId);
//            return View(productModel);
//        }

//        [HttpPost]
//        public ActionResult EditProduct(Product model)
//        {
//            if (ModelState.IsValid)
//            {
//                repository.Update(model);
//                unitOfWork.Save();
//                return RedirectToAction("Index", "TestUProduct");
//            }
//            else
//            {
//                return View(model);
//            }
//        }

//        [HttpGet]
//        public ActionResult DeleteProduct(int productId)
//        {
//            Product product = repository.GetByID(productId);
//            return View(product);
//        }

//        [HttpPost, ActionName("DeleteProduct")]
//        public ActionResult Delete(int productId)
//        {
//            Product product = repository.GetByID(productId);
//            repository.Delete(product);
//            unitOfWork.Save();
//            return RedirectToAction("Index", "TestUProduct");
//        }
//    }
//}