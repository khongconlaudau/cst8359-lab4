using lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3.Data
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Database.IsSqlite())
            {
                context.Database.EnsureCreated();
            }
            else
            {
                context.Database.Migrate();
            }

            if (context.Rsvps.Any()) 
            {
                return;
            }

            context.Rsvps.AddRange(
                new Rsvp
                {
                    FullName = "Patrice Nangga",
                    WorkshopTitle = "Routing Basics",
                    NeedsAccommodation = false
                },
                new Rsvp
                {
                    FullName = "Orlando Reily",
                    WorkshopTitle = "EF Core Intro",
                    NeedsAccommodation = true
                },
                new Rsvp
                {
                    FullName = "Grace Hopper",
                    WorkshopTitle = "Razor Essentials",
                    NeedsAccommodation = false
                }
                );

            context.SaveChanges();
        }
    }
}
