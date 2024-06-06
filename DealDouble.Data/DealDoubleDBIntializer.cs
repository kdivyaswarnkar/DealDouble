using DealDouble.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;


namespace DealDouble.Data
{
    public class DealDoubleDBIntializer : CreateDatabaseIfNotExists<DealDoubleContext>
    {
        protected override void Seed(DealDoubleContext context)
        {
            // context.Auctions.Add(new Entities.Auction() { Title = "Default" });
            // base.Seed(context);
            SeedRoles(context);
            seedUsers(context);
        }

        public void SeedRoles(DealDoubleContext context)
        {
            List<IdentityRole> rolesInDealDouble = new List<IdentityRole>();
            rolesInDealDouble.Add(new IdentityRole() { Name = "Administrator" });
            rolesInDealDouble.Add(new IdentityRole() { Name = "Moderator" });
            rolesInDealDouble.Add(new IdentityRole() { Name="User"});
            var rolesStore = new RoleStore<IdentityRole>(context);
            var rolesManager = new RoleManager<IdentityRole>(rolesStore);

            foreach (IdentityRole role in rolesInDealDouble)
            {
                if(!rolesManager.RoleExists(role.Name))
                {
                    var result = rolesManager.Create(role);
                    if (result.Succeeded) continue;
                }
            }
        }

        public void seedUsers(DealDoubleContext context)
        {
            var userStore = new UserStore<DealDoubleUser>(context);
            var usersManager = new UserManager<DealDoubleUser>(userStore);

            DealDoubleUser admin = new DealDoubleUser();
            admin.Email = "admin@email.com";
            admin.UserName = "admin";
            var password = "admin123";

            if(usersManager.FindByEmail(admin.Email)==null)
            {
                var result = usersManager.Create(admin,password);
                if(result.Succeeded)
                {
                    //add necessary roles to admin
                    usersManager.AddToRole(admin.Id,"Administrator");
                    usersManager.AddToRole(admin.Id, "Moderator");
                    usersManager.AddToRole(admin.Id,"User");
                }
            }

        }
    }
}
