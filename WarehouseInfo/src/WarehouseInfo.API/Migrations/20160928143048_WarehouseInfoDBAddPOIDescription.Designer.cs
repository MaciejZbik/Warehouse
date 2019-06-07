using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WarehouseInfo.API.Entities;

namespace WarehouseInfo.API.Migrations
{
    [DbContext(typeof(WarehouseInfoContext))]
    [Migration("20160928143048_WarehouseInfoDBAddPOIDescription")]
    partial class WarehouseInfoDBAddPOIDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WarehouseInfo.API.Entities.Warehouse", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Description")
                    .HasAnnotation("MaxLength", 200);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 50);

                b.HasKey("Id");

                b.ToTable("Item");
            });

            modelBuilder.Entity("WarehouseInfo.API.Entities.PointOfInterest", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("WarehouseId");

                b.Property<string>("Description")
                    .HasAnnotation("MaxLength", 200);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 50);

                b.HasKey("Id");

                b.HasIndex("WarehouseId");

                b.ToTable("PointsOfInterest");
            });

            modelBuilder.Entity("WarehouseInfo.API.Entities.PointOfInterest", b =>
            {
                b.HasOne("WarehouseInfo.API.Entities.Warehouse", "Warehouse")
                    .WithMany("PointsOfInterest")
                    .HasForeignKey("WarehouseId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
