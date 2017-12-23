using ConstructionDiary.DAL;
using ConstructionDiary.Models;
using System;
using System.Linq;

namespace ConstructionDiary.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ConstructionCompanyContext context)
        {
            context.Database.EnsureCreated();

            // Look for any cities.
            if (context.City.Any())
            {
                return;   // DB has been seeded
            }

            var cities = new City[]
            {
            new City{Name="Mostar", Country="Bosnia and Herzegovina"},
            new City{Name="Sarajevo", Country="Bosnia and Herzegovina"},
            new City{Name="Travnik", Country="Bosnia and Herzegovina"},
            new City{Name="Zepce", Country="Bosnia and Herzegovina"},
            new City{Name="Houston", Country="Texax"},
            };
            foreach (City c in cities)
            {
                context.City.Add(c);
            }
            context.SaveChanges();
        }
    }
}