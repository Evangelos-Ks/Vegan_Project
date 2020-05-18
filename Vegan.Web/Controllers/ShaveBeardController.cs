using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Services;
using System.ComponentModel.DataAnnotations;

namespace Vegan.Web.Controllers.TestControllers
{
    public class ShaveBeardController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());


        //private GenericRepository<ShaveBeard> repository;

        //===================================== Constructor ================================================================
        //public ShaveBeardController()
        //{
        //    repository = new GenericRepository<ShaveBeard>(unitOfWork);
        //}

        //===================================== Methods ====================================================================
        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.ShaveBeards.GetAll());
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.ShaveBeards.GetAll());
        }

        [HttpGet]
        public ActionResult AddShaveBeard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShaveBeard(ShaveBeard model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.ShaveBeards.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "ShaveBeard");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsShaveBeard(int productId)
        {
            return View(unitOfWork.ShaveBeards.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditShaveBeard(int productId)
        {
            return View(unitOfWork.ShaveBeards.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditShaveBeard(ShaveBeard model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ShaveBeards.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "ShaveBeard");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteShaveBeard(int productId)
        {
            return View(unitOfWork.ShaveBeards.GetById(productId));
        }

        [HttpPost, ActionName("DeleteShaveBeard")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.ShaveBeards.GetById(productId);
            unitOfWork.ShaveBeards.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "ShaveBeard");
        }
    }
}