using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {
        DashboardService service = new DashboardService();

        private DealDoubleUserManager _userManager;
        private DealDoubleRoleManager _roleManager;

        public DashboardController()
        {
        }

        public DashboardController(DealDoubleUserManager userManager,DealDoubleRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

       
        public DealDoubleUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<DealDoubleUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public DealDoubleRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<DealDoubleRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }


        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();

          //  model.Page = Pages.dashboard;
            model.UserCount = service.GetUserCount();
            model.AuctionsCount = service.GetAuctionCount();
            model.BidsCount = service.GetBidsCount();

             return View(model);
          //  return View();
        }


        public ActionResult Users(string roleID, string searchTerm, int? pageNo)
        {
            UsersViewModel model = new UsersViewModel();
            model.PageTitle = "Users";
            model.PageDescriptions = "Users Listing Page";
            model.RoleID = roleID;
            model.SearchTerm = searchTerm;
            model.PageNo = pageNo;

            model.Roles = RoleManager.Roles.ToList();

            return View(model);
        }

        public ActionResult UsersListing(string roleID, string searchTerm, int? pageNo)
        {
            var pageSize = 3;
            UsersListingViewModel model = new UsersListingViewModel();
            model.RoleID = roleID;
            model.SearchTerm = searchTerm;
            model.Users = UserManager.Users.ToList();


            var users = UserManager.Users;
            if (!string.IsNullOrEmpty(roleID))
            {
                users = users.Where(x=>x.Roles.FirstOrDefault(y=>y.RoleId==roleID) != null);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(x => x.Email.ToLower().Contains(searchTerm.ToLower()));
            }
            pageNo = pageNo ?? 1; //pageNo=pageNo.HasValue?pageNo.Value:1;

            var skipCount = (pageNo.Value - 1) * pageSize;
            model.Users= users.OrderBy(x=>x.Email).Skip(skipCount).Take(pageSize).ToList();

            model.Pager = new Pager(users.Count(), pageNo, pageSize);
            return PartialView(model);
        }


        public ActionResult RolesListing(string searchTerm, int? pageNo)
        {
            var pageSize = 3;
            RolesListingViewModel model = new RolesListingViewModel();
           
            model.SearchTerm = searchTerm;
           

            var roles =RoleManager.Roles;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                roles = roles.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }
          
            pageNo = pageNo ?? 1; //pageNo=pageNo.HasValue?pageNo.Value:1;

            var skipCount = (pageNo.Value - 1) * pageSize;
            model.Roles = roles.OrderBy(x => x.Name).Skip(skipCount).Take(pageSize).ToList();

            model.Pager = new Pager(roles.Count(), pageNo, pageSize);
            return PartialView(model);
        }


    }
}