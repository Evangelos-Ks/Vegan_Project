using System.Web.Mvc;
using Vegan.Database;
using Vegan.Services;

namespace Vegan.Web.Controllers
{
    public class SupplementController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        [HttpGet]
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.Supplements.GetAll());
        }
        
        // GET: Supplement
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