﻿using DealDouble.Data;
using DealDouble.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace DealDouble.Services
{
    public class DealDoubleUserManager : UserManager<DealDoubleUser>
    {
        public DealDoubleUserManager(IUserStore<DealDoubleUser> store)
            : base(store)
        {
        }

        public static DealDoubleUserManager Create(IdentityFactoryOptions<DealDoubleUserManager> options, IOwinContext context)
        {
            var manager = new DealDoubleUserManager(new UserStore<DealDoubleUser>(context.Get<DealDoubleContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<DealDoubleUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<DealDoubleUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<DealDoubleUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

           // manager.EmailService = new EmailService();
           // manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<DealDoubleUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
