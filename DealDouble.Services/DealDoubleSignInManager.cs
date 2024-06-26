﻿using DealDouble.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class DealDoubleSignInManager : SignInManager<DealDoubleUser, string>
    {
        public DealDoubleSignInManager(DealDoubleUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(DealDoubleUser user)
        {
            return user.GenerateUserIdentityAsync((DealDoubleUserManager)UserManager);
        }

        public static DealDoubleSignInManager Create(IdentityFactoryOptions<DealDoubleSignInManager> options, IOwinContext context)
        {
            return new DealDoubleSignInManager(context.GetUserManager<DealDoubleUserManager>(), context.Authentication);
        }
    }
}
