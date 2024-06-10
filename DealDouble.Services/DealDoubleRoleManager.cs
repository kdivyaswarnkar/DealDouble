using DealDouble.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DealDouble.Services
{
    public class DealDoubleRoleManager : RoleManager<IdentityRole>
    {
        public DealDoubleRoleManager(IRoleStore<IdentityRole,string> roleStore): base(roleStore)
        {

        }

        public static DealDoubleRoleManager Create(IdentityFactoryOptions<DealDoubleRoleManager> options, IOwinContext context)
        {
            return new DealDoubleRoleManager(new RoleStore<IdentityRole>(context.Get<DealDoubleContext>()));
        }
    }   
}
