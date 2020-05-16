using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Services;

namespace Vegan.Web.Controllers
{
    public class HomeVeganController : Controller
    {
        //===================================== Fields =====================================================================
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        // GET: Care
        [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.Homes.GetAll());
        } 

        public ActionResult IndexUser()
        {
            return View(unitOfWork.Homes.GetAll());
        }

        public ActionResult Details(int productId)
        {
            return View(unitOfWork.Homes.GetById(productId));
        }
    }
}