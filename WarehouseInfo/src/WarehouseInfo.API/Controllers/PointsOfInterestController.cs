using AutoMapper;
using WarehouseInfo.API.Models;
using WarehouseInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInfo.API.Controllers
{
    [Route("api/item")]
    public class PointsOfInterestController : Controller
    {
        private ILogger<PointsOfInterestController> _logger;
        private IMailService _mailService;
        private IWarehouseInfoRepository _warehouseInfoRepository;


        public PointsOfInterestController(ILogger<PointsOfInterestController> logger,
            IMailService mailService,
            IWarehouseInfoRepository warehouseInfoRepository)
        {
            _logger = logger;
            _mailService = mailService;
            _warehouseInfoRepository = warehouseInfoRepository;
        }

        [HttpGet("{warehouseId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int warehouseId)
        {
            try
            {
                if (!_warehouseInfoRepository.WarehouseExists(warehouseId))
                {
                    _logger.LogInformation($"Warehouse with id {warehouseId} wasn't found when accessing points of interest.");
                    return NotFound();
                }

                var pointsOfInterestForWarehouse = _warehouseInfoRepository.GetPointsOfInterestForWarehouse(warehouseId);
                var pointsOfInterestForWarehouseResults =
                                   Mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForWarehouse);

                return Ok(pointsOfInterestForWarehouseResults);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for warehouse with id {warehouseId}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{warehouseId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int warehouseId, int id)
        {
            if (!_warehouseInfoRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var pointOfInterest = _warehouseInfoRepository.GetPointOfInterestForWarehouse(warehouseId, id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            var pointOfInterestResult = Mapper.Map<PointOfInterestDto>(pointOfInterest);
            return Ok(pointOfInterestResult);
        }

        [HttpPost("{warehouseId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int warehouseId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_warehouseInfoRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var finalPointOfInterest = Mapper.Map<Entities.PointOfInterest>(pointOfInterest);

            _warehouseInfoRepository.AddPointOfInterestForWarehouse(warehouseId, finalPointOfInterest);

            if (!_warehouseInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var createdPointOfInterestToReturn = Mapper.Map<Models.PointOfInterestDto>(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new
            { warehouseId = warehouseId, id = createdPointOfInterestToReturn.Id }, createdPointOfInterestToReturn);
        }

        [HttpPut("{warehouseId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int warehouseId, int id,
            [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_warehouseInfoRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = _warehouseInfoRepository.GetPointOfInterestForWarehouse(warehouseId, id);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            Mapper.Map(pointOfInterest, pointOfInterestEntity);

            if (!_warehouseInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }


        [HttpPatch("{warehouseId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int warehouseId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            if (!_warehouseInfoRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = _warehouseInfoRepository.GetPointOfInterestForWarehouse(warehouseId, id);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = Mapper.Map<PointOfInterestForUpdateDto>(pointOfInterestEntity);

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }

            TryValidateModel(pointOfInterestToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);

            if (!_warehouseInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete("{warehouseId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int warehouseId, int id)
        {
            if (!_warehouseInfoRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = _warehouseInfoRepository.GetPointOfInterestForWarehouse(warehouseId, id);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _warehouseInfoRepository.DeletePointOfInterest(pointOfInterestEntity);

            if (!_warehouseInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            _mailService.Send("Point of interest deleted.",
                    $"Point of interest {pointOfInterestEntity.Name} with id {pointOfInterestEntity.Id} was deleted.");

            return NoContent();
        }
    }
}
