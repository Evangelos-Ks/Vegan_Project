using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;

namespace Vegan.Web.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }
        
        // Map
        public ActionResult Map()
        {
            return View();
        }
        
        // Live Chat
        public ActionResult Chat()
        {
            return View();
        }
    }
}