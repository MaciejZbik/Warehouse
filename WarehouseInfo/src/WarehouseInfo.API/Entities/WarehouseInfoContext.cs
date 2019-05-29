using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInfo.API.Entities
{
    public class WarehouseInfoContext : DbContext
    {
        public WarehouseInfoContext(DbContextOptions<WarehouseInfoContext> options)
           : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Warehouse> Item { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
