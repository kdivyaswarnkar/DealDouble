using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class AuctionsController : Controller
    {
        AuctionsService auctionService = new AuctionsService();
        CategoriesService categoriesService = new CategoriesService();

        [HttpGet]
        public ActionResult Index()
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel();

            model.PageTitle = "Auctions";
            model.PageDescriptions = "Auction Listing Page";

            model.Auctions = auctionService.GetAllAuctions();
           
            return View(model);
            
        }


        public ActionResult Listing()
        {
            AuctionsListingViewModel model= new AuctionsListingViewModel();

            model.Auctions = auctionService.GetAllAuctions();

            return PartialView(model);
            
         
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();

            model.Categories = categoriesService.GetAllCategories();
            return PartialView(model);
            
        }

        [HttpPost]
        public ActionResult Create(CreateAuctionViewModel model)
        {
            Auction auction = new Auction();
          
            auction.Title = model.Title;
            auction.CategoryID = model.CategoryID;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndingTime = model.EndingTime;
            
            var pictureIDs = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();
            auction.AuctionPictures = new List<AuctionPicture>();

            auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }).ToList());

            //foreach (var picID in pictureIDs)
            //{
            //    var auctionPicture = new AuctionPicture();
            //    auctionPicture.PictureID = picID;
            //    auction.AuctionPictures.Add(auctionPicture);
            //}
            
            auctionService.SaveAuction(auction);

            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {   
            var auction = auctionService.GetAuctionByID(ID);

            return PartialView(auction);
        }

        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            auctionService.UpdateAuction(auction);

            return RedirectToAction("Listing");
        }

        [HttpPost]
        public ActionResult Delete(Auction auction)
        {         
            auctionService.DeleteAuction(auction);

            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {           
            AuctionsDetailsViewModel model = new AuctionsDetailsViewModel();
            model.Auction = auctionService.GetAuctionByID(ID);
            model.PageTitle = "Auction Details:" + model.Auction.Title;
            model.PageDescriptions = model.Auction.Description.Substring(0,10);

            return View(model);
        }



    }
}