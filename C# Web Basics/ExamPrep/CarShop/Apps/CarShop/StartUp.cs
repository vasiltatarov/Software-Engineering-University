﻿namespace CarShop
{
    using System.Collections.Generic;

    using CarShop.Data;
    using CarShop.Services;

    using SUS.HTTP;
    using SUS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
            }
            //new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICarsService, CarsService>();
            serviceCollection.Add<IIssuesService, IssuesService>();
        }
    }
}
