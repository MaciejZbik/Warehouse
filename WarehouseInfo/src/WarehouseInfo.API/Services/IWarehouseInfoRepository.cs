using WarehouseInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInfo.API.Services
{
    public interface IWarehouseInfoRepository
    {
        bool WarehouseExists(int cityId);
        IEnumerable<Warehouse> GetItem();
        Warehouse GetWarehouse(int cityId, bool includePointsOfInterest);
        IEnumerable<PointOfInterest> GetPointsOfInterestForWarehouse(int cityId);
        PointOfInterest GetPointOfInterestForWarehouse(int cityId, int pointOfInterestId);
        void AddPointOfInterestForWarehouse(int cityId, PointOfInterest pointOfInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        bool Save();
    }
}
