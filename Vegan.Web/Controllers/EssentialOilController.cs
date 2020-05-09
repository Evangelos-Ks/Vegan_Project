using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Services;
using System.ComponentModel.DataAnnotations;

namespace Vegan.Web.Controllers.TestControllers
{
    public class EssentialOilController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.EssentialOils.GetAll());
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
                if (ModelState.IsValid)
                {
                    unitOfWork.EssentialOils.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "EssentialOil");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsEssentialOil(int productId)
        {
            return View(unitOfWork.EssentialOils.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditEssentialOil(int productId)
        {
            return View(unitOfWork.EssentialOils.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditEssentialOil(EssentialOil model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EssentialOils.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "EssentialOil");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteEssentialOil(int productId)
        {
            return View(unitOfWork.EssentialOils.GetById(productId));
        }

        [HttpPost, ActionName("DeleteEssentialOil")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.EssentialOils.GetById(productId);
            unitOfWork.EssentialOils.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "EssentialOil");
        }
    }
}
