using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using Microsoft.VisualBasic;
using ProiectDaw.Models.DTOs;
using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.ManufacturerRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository _repo;

        public ManufacturerController(IManufacturerRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet("veh")]
        public async Task<IActionResult> GetAllManufacturersWithVehicles()
        {
            Dictionary<string,string> dict = new Dictionary<string,string>();
            dict = await _repo.GetAllManufacturersWithVehicles();

            return Ok(dict);
        }
        
        [HttpGet("stock")]
        public async Task<IActionResult> GetAllManufacturersWithNumberOfVehicles()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict = await _repo.GetAllManufacturersWithNOVehicles();

            return Ok(dict);
        }
        
        
        [HttpGet]

        public async Task<IActionResult> GetAllManufacturers()
        {
            var manufacturers = await _repo.GetAllManufacturersWithLocation();

            var manufacturersToReturn = new List<ManufacturerDTO>();

            foreach (var manufacturer in manufacturers)
            {
                manufacturersToReturn.Add(new ManufacturerDTO(manufacturer));
            }

            return Ok(manufacturersToReturn);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var manufacturer = await _repo.GetByIdWithLocation(id);

            return Ok(new ManufacturerDTO(manufacturer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturerById(int id)
        {
            var manufacturer = await _repo.GetByIdWithLocation(id);

            if (manufacturer == null) 
            {
                return NotFound("There is no manufacturer with given id");
            }

            _repo.Delete(manufacturer);

            await _repo.SaveAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> CreateManufacturer(CreateManufacturerDTO dto)
        {
            Manufacturer newManufacturer = new Manufacturer();

            newManufacturer.Name = dto.Name;
            newManufacturer.Location = dto.Location;

            _repo.Create(newManufacturer);
            
            await _repo.SaveAsync();
        
            return Ok(new ManufacturerDTO(newManufacturer));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<Manufacturer> manufacturer)
        {
            if (manufacturer != null)
            {
                var manufacturerForUpdate = await _repo.GetByIdAsync(id);
                manufacturer.ApplyTo(manufacturerForUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _repo.SaveAsync();
                return Ok(new ManufacturerDTO(manufacturerForUpdate));
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
