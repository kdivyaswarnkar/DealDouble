using DealDouble.Entities;
using DealDouble.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class AuctionsController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            AuctionsService service = new AuctionsService();
            var auctions = service.GetAllAuctions();
            return View(auctions);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            AuctionsService service = new AuctionsService();
            service.SaveAuction(auction);

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            AuctionsService service = new AuctionsService();
            var auction = service.GetAuctionByID(ID);

            return View(auction);
        }

        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            AuctionsService service = new AuctionsService();
            service.UpdateAuction(auction);

            return View(auction);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AuctionsService service = new AuctionsService();
            var auction = service.GetAuctionByID(ID);

            return View(auction);
        }
        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            AuctionsService service = new AuctionsService();
            service.DeleteAuction(auction);

            return RedirectToAction("Index");
        }



    }
}