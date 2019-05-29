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
                     Name = "Maciej Żbikowski",
                     Description = "Zamowienie",
                     PointsOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest() {
                             Name = "Łóżko 2x2",
                             Description = "Froma+materac."
                         },
                          new PointOfInterest() {
                             Name = "Krzesło",
                             Description = "Czarne skórzane."
                          },
                     }
                },
                new Warehouse()
                {
                    Name = "Dawid Kowalczyk",
                    Description = "Przechowanie",
                    PointsOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest() {
                             Name = "Biurko ",
                             Description = "Drewniane."
                         },
                          new PointOfInterest() {
                             Name = "Stoł",
                             Description = "Szknaly z drewnianą formą."
                          },
                     }
                },
                new Warehouse()
                {
                    Name = "Mariusz Przekrętka",
                    Description = "Zawmowienie.",
                    PointsOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest() {
                             Name = "Zestaw ogrodowy",
                             Description =  "Stoł + 4 krzesła drewniane ze skorzanym obiciem."
                         },
                          new PointOfInterest() {
                             Name = "Fotel",
                             Description = "Materiałowy."
                          },
                     }
                }
            };

            context.Item.AddRange(item);
            context.SaveChanges();
        }
    }
}
