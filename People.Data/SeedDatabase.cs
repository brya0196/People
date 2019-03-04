using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace People.Data
{
    public class SeedDatabase
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<PeopleDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "test@email.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "test"
                };

                userManager.CreateAsync(user, "Password@123");
            }
        }
    }
}
