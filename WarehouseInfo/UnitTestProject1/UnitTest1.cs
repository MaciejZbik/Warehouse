using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        string Zmienna1 = "Testowa Nazwa";
        String Zmienna2 = "Testowa Zmiana";
        [TestMethod]
        public void TestMethod1()
        {
            [HttpPost("{warehouseId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int warehouseId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
             var createdPointOfInterestToReturn = Mapper.Map<Models.PointOfInterestDto>(finalPointOfInterest);
            return CreatedAtRoute("GetPointOfInterest", new
            { warehouseId = zmienna1, id = createdPointOfInterestToReturn.Id }, createdPointOfInterestToReturn);
        };
        
        [TestMethod]
        public void TestMethod2()
        {
        [HttpPatch("{warehouseId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int warehouseId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            var pointOfInterestToPatch = Mapper.Map<PointOfInterestForUpdateDto>(pointOfInterestEntity);

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState=Zmienna2);
            Mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);



    }
        [TestMethod]
        public void TestMethod3()
        {
            [HttpDelete("{warehouseId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int warehouseId, int id)
        {

            _mailService.Send("Point of interest deleted.",
                    $"Point of interest {pointOfInterestEntity.Name} with id {pointOfInterestEntity.Id} was deleted.");

            return NoContent();
        }

    }
    }
}
