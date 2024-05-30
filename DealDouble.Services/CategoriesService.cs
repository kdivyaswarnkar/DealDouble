using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class CategoriesService
    {
     
        public List<Category> GetAllCategories()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Categories.ToList();
        }
        public void SaveCategory(Category category)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Categories.Add(category);
            context.SaveChanges();
        }
        public Category GetCategoryByID(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Categories.Find(ID);
        }
        public void UpdateCategory(Category category)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

            // context.Auctions.Remove(category);
            context.SaveChanges();
        }

    }
}
