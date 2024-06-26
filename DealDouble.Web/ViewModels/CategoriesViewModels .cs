﻿using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class CategoryDetailsViewModel : PageViewModel
    {
       public Category Category { get; set; }
    }

    public class CategoriesListingViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }
    }
    public class CategoriesViewModel : PageViewModel
    {
        public List<Category> Allcategories { get; set; }
        public List<Category> PromotedCategories { get; set; }

    }

    public class CategoryViewModel : PageViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Auction> Auctions { get; set; }
    }
}