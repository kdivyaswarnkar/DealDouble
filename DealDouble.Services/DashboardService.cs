using DealDouble.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{

    public class DashboardService
    {


        public int GetUserCount()
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Users.Count();
        }
        public int GetAuctionCount()
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Auctions.Count();
        }
        public int GetBidsCount()
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Bids.Count();
        }
    }
}
