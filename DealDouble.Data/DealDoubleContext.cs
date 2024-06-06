using DealDouble.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DealDouble.Data
{
    public class DealDoubleContext : IdentityDbContext<DealDoubleUser>
    {
        public DealDoubleContext() : base("name=DealDoubleConnectionString")
        {
            Database.SetInitializer<DealDoubleContext>(new DealDoubleDBIntializer());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<AuctionPicture> AuctionPictures { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public static DealDoubleContext Create()
        {
            return new DealDoubleContext();
        }





        /* Database Intializers Strategy */

        //CreateDataBaseIfNotExist ---Default
        //CreateDatabaseIfModelChanges
        //DropCreateDatabaseAlways
    }
}
