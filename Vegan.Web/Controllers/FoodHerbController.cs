using System.Web.Mvc;
using Vegan.Database;
using Vegan.Services;

namespace Vegan.Web.Controllers
{
    public class FoodHerbController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        // GET: FoodHerb
     // [Authorize(Roles = "Admins, Supervisors")]
        public ActionResult Index()
        {
            return View(unitOfWork.FoodHerbs.GetAll());
        }
        // GET: FoodHerb
        public ActionResult IndexUser()
        {
            return View(unitOfWork.FoodHerbs.GetAll());
        }

        public ActionResult Details(int productId)
        {
            return View(unitOfWork.FoodHerbs.GetById(productId));
        }
    }
}