using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DealDouble.Entities
{
    public class DealDoubleUser :IdentityUser
    {
        public int Age { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DealDoubleUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
