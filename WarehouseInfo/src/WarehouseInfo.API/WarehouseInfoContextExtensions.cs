using WarehouseInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInfo.API
{
    public static class WarehouseInfoExtensions
    {
        public static void EnsureSeedDataForContext(this WarehouseInfoContext context)
        {
            if (context.Item.Any())
            {
                return;
            }

            // init seed data
            var item = new List<Warehouse>()
            {
                new Warehouse()
                {
                     Name = "Janusz",
                     Description = "Zamowienie",
                     PointsOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest() {
                             Name = "Plecak",
                             Description = "Czarny skórzany " 
                         },
                          new PointOfInterest() {
                             Name = "Portfel ",
                             Description = "Materiałowy"
                          },
                     }
                },
                new Warehouse()
                {
                    Name = "Maciej",
                    Description = "Przechowanie",
                    PointsOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest() {
                             Name = "Meble",
                             Description = "Stoł + 4 krzesła obite białe."
                         },
                          new PointOfInterest() {
                             Name = "Narzędzia",
                             Description = "Młotek"
                          },
                     }
                },
                new Warehouse()
                {
                    Name = "Agnieszka",
                    Description = "Zamowienie.",
                    PointsOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest() {
                             Name = "Meble",
                             Description = "Szafa czarna."
                         },
                          new PointOfInterest() {
                             Name = "Biorko",
                             Description = "Z regulacją wysokości"
                          },
                     }
                }
            };

            context.Item.AddRange(item);
            context.SaveChanges();
        }
    }
}
