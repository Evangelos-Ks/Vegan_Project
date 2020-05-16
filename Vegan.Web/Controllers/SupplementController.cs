using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegan.Services;
using Vegan.Database;

namespace Vegan.Web.Controllers
{
    public class SupplementController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        [HttpGet]
        [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.Supplements.GetAll());
        }
        
        // GET: Care
        public ActionResult IndexUSer()
        {
            return View(unitOfWork.Supplements.GetAll());
        }

        public ActionResult Details(int productId)
        {
            return View(unitOfWork.Supplements.GetById(productId));
        }
    }
}