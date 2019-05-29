using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace WarehouseInfo.API.Services
{
    public class WarehouseInfoRepository : IWarehouseInfoRepository
    {
        private WarehouseInfoContext _context;
        public WarehouseInfoRepository(WarehouseInfoContext context)
        {
            _context = context;
        }

        public void AddPointOfInterestForWarehouse(int warehouseId, PointOfInterest pointOfInterest)
        {
            var warehouse = GetWarehouse(warehouseId, false);
            warehouse.PointsOfInterest.Add(pointOfInterest);
        }

        public bool WarehouseExists(int warehouseId)
        {
            return _context.Item.Any(c => c.Id == warehouseId);
        }

        public IEnumerable<Warehouse> GetItem()
        {
            return _context.Item.OrderBy(c => c.Name).ToList();
        }

        public Warehouse GetWarehouse(int warehouseId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Item.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == warehouseId).FirstOrDefault();
            }

            return _context.Item.Where(c => c.Id == warehouseId).FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestForWarehouse(int warehouseId, int pointOfInterestId)
        {
            return _context.PointsOfInterest
               .Where(p => p.WarehouseId == warehouseId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForWarehouse(int warehouseId)
        {
            return _context.PointsOfInterest
                           .Where(p => p.WarehouseId == warehouseId).ToList();
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
