using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Entities.Care;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class ProductController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            return View(unitOfWork.Products.GetAll());
        }

        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.Products.GetAll());
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult AddProduct(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Products.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "Product");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult DetailsProduct(int productId)
        {
            string actionMethod = "Details";
            if (unitOfWork.Candles.GetById(productId) != null)
            {
                var product = unitOfWork.Candles.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.EssentialOils.GetById(productId) != null)
            {
                var product = unitOfWork.EssentialOils.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.HomeCleanings.GetById(productId) != null)
            {
                var product = unitOfWork.HomeCleanings.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.Kitchens.GetById(productId) != null)
            {
                var product = unitOfWork.Kitchens.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.Salts.GetById(productId) != null)
            {
                var product = unitOfWork.Salts.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.Spices.GetById(productId) != null)
            {
                var product = unitOfWork.Spices.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.SproutingSeeds.GetById(productId) != null)
            {
                var product = unitOfWork.SproutingSeeds.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.Teas.GetById(productId) != null)
            {
                var product = unitOfWork.Teas.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.PowerHealths.GetById(productId) != null)
            {
                var product = unitOfWork.PowerHealths.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.SuperFoods.GetById(productId) != null)
            {
                var product = unitOfWork.SuperFoods.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.FaceCreams.GetById(productId) != null)
            {
                var product = unitOfWork.FaceCreams.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory + "s", new { productId });
            }
            if (unitOfWork.Hairs.GetById(productId) != null)
            {
                var product = unitOfWork.Hairs.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.Lotions.GetById(productId) != null)
            {
                var product = unitOfWork.Lotions.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }
            if (unitOfWork.ShaveBeards.GetById(productId) != null)
            {
                var product = unitOfWork.ShaveBeards.GetById(productId);
                actionMethod = actionMethod + product.SubCategory;
                return RedirectToAction(actionMethod, product.SubCategory, new { productId });
            }


            return View(unitOfWork.Products.GetById(productId));
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult EditProduct(int productId)
        {
            return View(unitOfWork.Products.GetById(productId));
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Products.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteProduct(int productId)
        {
            return View(unitOfWork.Products.GetById(productId));
        }

        [HttpPost, ActionName("DeleteProduct")]
        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Products.GetById(productId);
            unitOfWork.Products.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "Product");
        }
    }
}