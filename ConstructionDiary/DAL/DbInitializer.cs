using ConstructionDiary.DAL;
using DataLayer.Models;
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

            context.Set<ConstructionSiteManager>().Add(new ConstructionSiteManager()
            {
                User = new User()
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                }
            });

            var equipment = new Equipment[]
            {
                new Equipment() {Name = "Čekić", PurchaseDate = DateTime.Now, SerialNumber = "A7687"},
                new Equipment() {Name = "Mješalica", PurchaseDate = DateTime.Now, SerialNumber = "C7689"},
                new Equipment() {Name = "Bager", PurchaseDate = DateTime.Now, SerialNumber = "Z6573"},
            };
            context.Equipment.AddRange(equipment);

            context.SaveChanges();
        }
    }
}