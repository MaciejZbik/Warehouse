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
                     Name = "Janusz",
                     Description = "Zamowienie",
                     PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Id = 1,
                             Name = "Plecak",
                             Description = "Czarny skórzany " },
                          new PointOfInterestDto() {
                             Id = 2,
                             Name = "Portfel ",
                             Description = "Materiałowy" },
                     }
                },
                new WarehouseDto()
                {
                    Id = 2,
                    Name = "Maciej",
                    Description = "Przechowanie",
                    PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Id = 3,
                             Name = "Meble",
                             Description = "Stoł + 4 krzesła obite białe." },
                          new PointOfInterestDto() {
                             Id = 4,
                             Name = "Narzędzia",
                             Description = "Młotek" },
                     }
                },
                new WarehouseDto()
                {
                    Id= 3,
                    Name = "Agnieszka",
                    Description = "Zamowienie.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Id = 5,
                             Name = "Meble",
                             Description = "Szafa czarna." },
                          new PointOfInterestDto() {
                             Id = 6,
                             Name = "Biorko",
                             Description = "Z regulacją wysokości" },
                     }
                }
            };

        }
    }
}
