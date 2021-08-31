namespace TheRecrutmentTool.Web.Infrastructures
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Data;
    using Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            MigrateDatabase(services);
            SeedRecruiter(services);

            return app;
        }

        private static void SeedRecruiter(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Recruiters.Any())
            {
                return;
            }

            data.Recruiters.AddRange(new Recruiter[]
            {
                new Recruiter
                {
                    FirstName = "Vanko1",
                    LastName = "Vankov",
                    Email = "Vanko1@abv.bg",
                    Country = "Paris",
                },
                new Recruiter
                {
                    FirstName = "Azis",
                    LastName = "Azisov",
                    Email = "Azis@abv.bg",
                    Country = "London",
                },
                new Recruiter
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    Email = "Pesho@abv.bg",
                    Country = "Bulgaria",
                },
                new Recruiter
                {
                    FirstName = "Sergey",
                    LastName = "Sergeyiev",
                    Email = "Sergey@abv.bg",
                    Country = "Russia",
                },
            });

            data.SaveChanges();
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();
            data.Database.Migrate();
        }
    }
}
