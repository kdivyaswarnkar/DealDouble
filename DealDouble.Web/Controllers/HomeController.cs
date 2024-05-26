using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class HomeController : Controller
    {
        AuctionsService service = new AuctionsService();
        public ActionResult Index()
        {
            AuctionsViewModel vModel = new AuctionsViewModel();
            vModel.PageTitle = "Home Page";
            vModel.PageDescriptions = "This is Home Page";
            vModel.AllAuctions = service.GetAllAuctions();
            vModel.PromotedAuctions = service.GetPromotedAuctions();
            
            return View(vModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}