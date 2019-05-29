using AutoMapper;
using WarehouseInfo.API.Models;
using WarehouseInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInfo.API.Controllers
{
    [Route("api/item")]
    public class ItemController : Controller
    {
        private IWarehouseInfoRepository _warehouseInfoRepository;

        public ItemController(IWarehouseInfoRepository warehouseInfoRepository)
        {
            _warehouseInfoRepository = warehouseInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetItem()
        {
            var warehouseEntities = _warehouseInfoRepository.GetItem();
            var results = Mapper.Map<IEnumerable<WarehouseWithoutPointsOfInterestDto>>(warehouseEntities);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetWarehouse(int id, bool includePointsOfInterest = false)
        {
            var warehouse = _warehouseInfoRepository.GetWarehouse(id, includePointsOfInterest);

            if (warehouse == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var warehouseResult = Mapper.Map<WarehouseDto>(warehouse);
                return Ok(warehouseResult);
            }

            var warehouseWithoutPointsOfInterestResult = Mapper.Map<WarehouseWithoutPointsOfInterestDto>(warehouse);
            return Ok(warehouseWithoutPointsOfInterestResult);
        }
    }
}
