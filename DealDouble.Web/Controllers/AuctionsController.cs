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
        SharedService sharedService = new SharedService();
        public ActionResult Index(int? categoryID, string searchTerm,int? pageNo)
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel();

            model.PageTitle = "Auctions";
            model.PageDescriptions = "Auction Listing Page";

            model.Auctions = auctionService.GetAllAuctions();
            model.CategoryID = categoryID;
            model.SearchTerm = searchTerm;
            model.PageNo = pageNo;
            model.Categories = categoriesService.GetAllCategories();
            return View(model);
            
        }

        public ActionResult Listing(int? categoryID,string searchTerm, int? pageNo)
        {
            var pageSize = 1;
            AuctionsListingViewModel model= new AuctionsListingViewModel();

         // model.Auctions = auctionService.GetAllAuctions();
            model.Auctions = auctionService.SearchAuctions(categoryID,searchTerm,pageNo,pageSize);

            var totalAuctions = auctionService.GetAuctionCount(categoryID, searchTerm);
            model.Pager = new Pager(totalAuctions,pageNo,pageSize);
            
         // pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
        //  model.PageNo = pageNo ?? 1;
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
        public JsonResult Create(CreateAuctionViewModel model)
        {
            JsonResult result = new JsonResult();
            if (ModelState.IsValid)
            {
                Auction auction = new Auction();

                auction.Title = model.Title;
                auction.CategoryID = model.CategoryID;
                auction.Description = model.Description;
                auction.ActualAmount = model.ActualAmount;
                auction.StartingTime = model.StartingTime;
                auction.EndingTime = model.EndingTime;


                if (!string.IsNullOrEmpty(model.AuctionPictures))
                {


                    var pictureIDs = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();
                    auction.AuctionPictures = new List<AuctionPicture>();

                    auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }).ToList());
                }
                //foreach (var picID in pictureIDs)
                //{
                //    var auctionPicture = new AuctionPicture();
                //    auctionPicture.PictureID = picID;
                //    auction.AuctionPictures.Add(auctionPicture);
                //}

                auctionService.SaveAuction(auction);

                // return RedirectToAction("Listing");
                result.Data = new { Success = true };
            }
            else
            {
                //return PartialView(model);
                result.Data = new { Success = false, Error = "Unable to save Auction. Please Enter Valid value" };
            }
            return result;
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {

            CreateAuctionViewModel model = new CreateAuctionViewModel();

            var auction = auctionService.GetAuctionByID(ID);

            model.ID = auction.ID;
            model.Title = auction.Title;
            model.CategoryID = auction.CategoryID;
            model.Description = auction.Description;
            model.ActualAmount = auction.ActualAmount;
            model.StartingTime = auction.StartingTime;
            model.EndingTime = auction.EndingTime;
            model.Categories = categoriesService.GetAllCategories();
            model.AuctionPictureList = auction.AuctionPictures;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(CreateAuctionViewModel model)
        {
            Auction auction = new Auction();
            auction.ID = model.ID;
            auction.Title = model.Title;
            auction.CategoryID = model.CategoryID;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndingTime = model.EndingTime;

            if (!string.IsNullOrEmpty(model.AuctionPictures))
            {           
            var pictureIDs = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();
            auction.AuctionPictures = new List<AuctionPicture>();
            auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() {AuctionID=auction.ID, PictureID = x }).ToList());
            }
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
            model.EntityID = (int)EntityEnum.Auction;
            model.Auction = auctionService.GetAuctionByID(ID);
            model.BidsAmount = model.Auction.ActualAmount + model.Auction.Bids.Sum(x => x.BidAmount);
            var latestBidder = model.Auction.Bids.OrderByDescending(x => x.TimeStamp).FirstOrDefault();
            model.LatestBidder = latestBidder !=null? latestBidder.User :null;

            model.Comments = sharedService.GetComments((int)EntityEnum.Auction, model.Auction.ID);
            model.PageTitle = "Auction Details:" + model.Auction.Title;
            model.PageDescriptions = model.Auction.Description.Substring(0,10);

            return View(model);
        }



    }
}