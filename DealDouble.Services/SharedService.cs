using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class SharedService
    {
        public int SavePicture(Picture picture)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Pictures.Add(picture);
            context.SaveChanges();
            return picture.ID;
        }

        public bool LeaveComment(Comment comment)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Comments.Add(comment);
            return context.SaveChanges() > 0;
            
        }

        public  List<Comment> GetComments(int entityId, int recordID)
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Comments.Where(x=>x.EntityID==entityId && x.RecordID==recordID).ToList();
        }
    }
}
