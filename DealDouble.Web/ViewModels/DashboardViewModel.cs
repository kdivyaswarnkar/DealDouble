using DealDouble.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class DashboardViewModel :PageViewModel
    {
        public int UserCount { get; internal set; }
        public int AuctionsCount { get; internal set; }
        public int BidsCount { get; internal set; }
    }
    public class UsersViewModel : PageViewModel
    {
        public string RoleID { get; set; }
        public string SearchTerm { get; set; }
        public List<IdentityRole> Roles { get; internal set; }
        public int? PageNo { get; internal set; }
    }

    public class UsersListingViewModel : PageViewModel
    {
        internal string searchTerm;

        public List<DealDoubleUser> Users { get; internal set; }
        public Pager Pager { get; set; }
        public string RoleID { get; internal set; }
        public string SearchTerm { get; internal set; }
    }
    public class RolesListingViewModel : PageViewModel
    {
        internal string searchTerm;

        public List<DealDoubleUser> Users { get; internal set; }
        public Pager Pager { get; set; }
       
        public string SearchTerm { get; internal set; }
        public object Roles { get; internal set; }
    }
}