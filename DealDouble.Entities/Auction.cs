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
        [Required]
        [MinLength(15,ErrorMessage ="Minimum length should be 15 characters..")]
        [MaxLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(100,10000000, ErrorMessage = "Actual Amount must be within 100-10000000.")]
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public Nullable<DateTime> EndingTime { get; set; }

        public virtual List<AuctionPicture> AuctionPictures { get; set; }

        public virtual List<Bid> Bids { get; set; }

    }
}
