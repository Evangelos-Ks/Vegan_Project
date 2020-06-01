using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Services;

namespace Vegan.Web.Controllers.TestControllers
{
    public class FaceCreamsController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        //===================================== Methods ====================================================================
     // [Authorize(Roles = "Admins, Supervisors")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitOfWork.FaceCreams.GetAll());
        } 
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View(unitOfWork.FaceCreams.GetAll());
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
                if (ModelState.IsValid)
                {
                    unitOfWork.FaceCreams.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "FaceCreams");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }

        public ActionResult DetailsFaceCream(int productId)
        {
            return View(unitOfWork.FaceCreams.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditFaceCream(int productId)
        {
            return View(unitOfWork.FaceCreams.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditFaceCream(FaceCream model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FaceCreams.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "FaceCreams");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteFaceCream(int productId)
        {
            return View(unitOfWork.FaceCreams.GetById(productId));
        }

        [HttpPost, ActionName("DeleteFaceCream")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.FaceCreams.GetById(productId);
            unitOfWork.FaceCreams.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "FaceCreams");
        }
    }
}