using DealDouble.Data;
using DealDouble.Entities;


namespace DealDouble.Services
{
    public class BidsService
    {
        public bool AddBid(Bid bid)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Bids.Add(bid);
            return context.SaveChanges() > 0;
        }
    }
}
