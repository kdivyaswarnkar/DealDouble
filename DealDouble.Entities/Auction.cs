using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealDouble.Entities
{
    public class Auction : BaseEntity
    {
        //for Foreign key
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }

        public virtual List<AuctionPicture> AuctionPictures { get; set; }
    }
}
