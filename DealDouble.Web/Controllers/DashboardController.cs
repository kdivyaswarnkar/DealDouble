using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }
    }
}