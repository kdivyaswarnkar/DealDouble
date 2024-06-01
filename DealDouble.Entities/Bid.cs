using System;

namespace DealDouble.Entities
{
    public class Bid :BaseEntity
    {
        public int AuctionID { get; set; }
        public virtual Auction Auction { get; set; }
        public string UserID { get; set; }
        public virtual DealDoubleUser User { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
