using System;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Services;

namespace Vegan.Web.Controllers
{
    public class HomeVeganController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        // GET: Care
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.Homes.GetAll());
        } 

        public ActionResult IndexUser()
        {
            return View(unitOfWork.Homes.GetAll());
        }


        [HttpGet]
        public ActionResult AddHomeVegan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHomeVegan(Home model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Homes.Add(model);
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    return RedirectToAction("Index", "HomeVegan");
                }
            }
            catch (Exception ex)
            {
                //TODO: We want to show an error message
                return View();
            }
            return View();
        }


        public ActionResult DetailsHomeVegan(int productId)
        {
            return View(unitOfWork.Homes.GetById(productId));
        }

        [HttpGet]
        public ActionResult EditHomeVegan(int productId)
        {
            return View(unitOfWork.Homes.GetById(productId));
        }

        [HttpPost]
        public ActionResult EditHomeVegan(Candle model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Homes.Edit(model);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return RedirectToAction("Index", "HomeVegan");
            }
            else
            {
                return View(model);
            }
        }

      

        [HttpGet]
        public ActionResult DeleteHomeVegan(int productId)
        {
            return View(unitOfWork.Homes.GetById(productId));
        }

        [HttpPost, ActionName("DeleteHomeVegan")]
        public ActionResult Delete(int productId)
        {

            var product = unitOfWork.Homes.GetById(productId);
            unitOfWork.Homes.Delete(product);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return RedirectToAction("Index", "HomeVegan");
        }

    }
}


