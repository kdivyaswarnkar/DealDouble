using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class AuctionsService
    {
        public void SaveAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Auctions.Add(auction);
            context.SaveChanges();
        }

        public List<Auction> GetAllAuctions()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Auctions.ToList();
        }

        public List<Auction> GetPromotedAuctions()
        {

            DealDoubleContext context = new DealDoubleContext();

            return context.Auctions.Take(4).ToList();
        }

        public Auction GetAuctionByID(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Auctions.Find(ID);
        }

        public void UpdateAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Entry(auction).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Entry(auction).State = System.Data.Entity.EntityState.Deleted;

           // context.Auctions.Remove(auction);
            context.SaveChanges();
        }

        public List<Auction> SearchAuctions(int? categoryID, string searchTerm, int? pageNo,int pageSize)
        {
         
            DealDoubleContext context = new DealDoubleContext();
            var auctions = context.Auctions.AsQueryable();
            if (categoryID.HasValue && categoryID.Value >0)
            {
               auctions = auctions.Where(x=>x.CategoryID==categoryID.Value);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }
            pageNo = pageNo ?? 1; //pageNo=pageNo.HasValue?pageNo.Value:1;

            var skipCount = (pageNo.Value - 1) * pageSize;
            return auctions.OrderByDescending(x=>x.CategoryID).Skip(skipCount).Take(pageSize).ToList();


        }
        public int GetAuctionCount()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Auctions.Count();
            //if (!string.IsNullOrEmpty(search))
            //    {
            //        return context.Categories.Where(category => category.Name != null &&
            //             category.Name.ToLower().Contains(search.ToLower())).Count();
            //    }
            //    else
            //    {
            //        return context.Categories.Count();
            //    }
            
        }
    }
}
