﻿using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class AuctionsDetailsViewModel : PageViewModel
    {
       public Auction Auction { get; set; }
    }

    public class AuctionsListingViewModel : PageViewModel
    {
        public List<Auction> Auctions { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
        public int? CategoryID { get; set; }
        public int? PageNo { get; set; }

        public List<Category> Categories { get; set; }
    }
    public class AuctionsViewModel : PageViewModel
    {
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> PromotedAuctions { get; set; }
    }

    public class CreateAuctionViewModel : PageViewModel
    {
        public int CategoryID { get; set; }
        [Required]
        [MinLength(15, ErrorMessage = "Minimum length should be 15 characters..")]
        [MaxLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(100, 10000000, ErrorMessage = "Actual Amount must be within 100-10000000.")]
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }
        public string AuctionPictures { get; set; }
        public List<Category> Categories { get; set; }
        public int ID { get; set; }
        public List<AuctionPicture> AuctionPictureList { get; set; }
    }
}