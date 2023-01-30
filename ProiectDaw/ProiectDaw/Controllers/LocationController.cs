using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProiectDaw.Models.DTOs;
using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.LocationRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _repository;

        public LocationController(ILocationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _repository.GetAllLocations();
            var locationsToReturn = new List<LocationDTO>();

            foreach (var location in locations)
            {
                locationsToReturn.Add(new LocationDTO(location));
            }

            return Ok(locationsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDTO dto)
        {
            Location newLocation = new Location();

            newLocation.Street = dto.Street;
            newLocation.City = dto.City;
            newLocation.ZipCode= dto.ZipCode;

            _repository.Create(newLocation);

            await _repository.SaveAsync();

            return Ok(new LocationDTO(newLocation));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationById(int id)
        {
            var location = await _repository.GetByIdAsync(id);

            if (location == null)
            {
                return NotFound("Location does not exist!");
            }

            _repository.Delete(location);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<Location> location)
        {
            if(location != null)
            {
                var locationForUpdate = await _repository.GetByIdAsync(id);
                location.ApplyTo(locationForUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _repository.SaveAsync();
                return Ok(new LocationDTO(locationForUpdate));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
