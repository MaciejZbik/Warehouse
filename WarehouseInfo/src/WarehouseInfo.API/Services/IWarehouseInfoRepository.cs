using WarehouseInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInfo.API.Services
{
    public interface IWarehouseInfoRepository
    {
        bool WarehouseExists(int warehouseId);
        IEnumerable<Warehouse> GetItem();
        Warehouse GetWarehouse(int warehouseId, bool includePointsOfInterest);
        IEnumerable<PointOfInterest> GetPointsOfInterestForWarehouse(int warehouseId);
        PointOfInterest GetPointOfInterestForWarehouse(int warehouseId, int pointOfInterestId);
        void AddPointOfInterestForWarehouse(int warehouseId, PointOfInterest pointOfInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        bool Save();
    }
}
