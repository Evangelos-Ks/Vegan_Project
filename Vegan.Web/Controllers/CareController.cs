using System.Web.Mvc;
using Vegan.Database;
using Vegan.Services;

namespace Vegan.Web.Controllers.CareVegan
{
    public class CareController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        // GET: Care
        // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View( unitOfWork.Cares.GetAll());
        } 
        
        // GET: Care for all users
        public ActionResult IndexUser()
        {
            return View( unitOfWork.Cares.GetAll());
        }


        public ActionResult Details(int productId)
        {
            return View(unitOfWork.Cares.GetById(productId));
        }

    }
}