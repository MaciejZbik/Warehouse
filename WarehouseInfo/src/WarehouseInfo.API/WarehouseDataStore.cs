using WarehouseInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInfo.API
{
    public class ItemDataStore
    {
        public static ItemDataStore Current { get; } = new ItemDataStore();
        public List<WarehouseDto> Item { get; set; }

        public ItemDataStore()
        {
            // init dummy data
            Item = new List<WarehouseDto>()
            {
                new WarehouseDto()
                {
                     Id = 1,
                     Name = "Maciej Żbikowski",
                     Description = "Zamowienie",
                     PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Id = 1,
                             Name = "Łóżko 2x2",
                             Description = "Froma+materac."},
                          new PointOfInterestDto() {
                             Id = 2,
                             Name = "Krzesło",
                             Description = "Czarne skórzane."
                     }
                },
                new WarehouseDto()
                {
                    Id = 2,
                    Name = "Dawid Kowalczyk",
                    Description = "Przechowanie",
                    PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Id = 3,
                             Name = "Biurko ",
                             Description = "Drewniane."},
                          new PointOfInterestDto() {
                             Id = 4,
                             Name = "Stoł",
                             Description = "Szknaly z drewnianą formą." },
                     }
                },
                new WarehouseDto()
                {
                    Id= 3,
                    Name = "Mariusz Przekrętka",
                    Description = "Zawmowienie.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Id = 5,
                             Name = "Zestaw ogrodowy",
                             Description =  "Stoł + 4 krzesła drewniane ze skorzanym obiciem."" },
                          new PointOfInterestDto() {
                             Id = 6,
                             Name = "Fotel",
                             Description = "Materiałowy."
                          },
                     }
                }
            };

        }
    }
}
