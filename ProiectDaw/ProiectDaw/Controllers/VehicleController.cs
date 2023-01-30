using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProiectDaw.Models.DTOs;
using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.VehicleRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        public readonly IVehicleRepository _repo;

        public VehicleController(IVehicleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _repo.GetAllVehiclesWithManufacturers();

            var vehiclesToReturn = new List<VehicleDTO>();

            foreach (var vehicle in vehicles)
            {
                vehiclesToReturn.Add(new VehicleDTO(vehicle));
            }

            return Ok(vehiclesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await _repo.GetByIdWithManufacturer(id);

            return Ok(new VehicleDTO(vehicle));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleById(int id)
        {
            var vehicle = await _repo.GetByIdAsync(id);

            if (vehicle == null)
            {
                return NotFound("Vehicle does not exist!");
            }

            _repo.Delete(vehicle);
            await _repo.SaveAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleDTO dto)
        {
            Vehicle newVehicle = new Vehicle();

            newVehicle.Name = dto.Name;
            newVehicle.Power = dto.Power; 
            newVehicle.Manufacturer = dto.Manufacturer;
            
            _repo.Create(newVehicle);

            await _repo.SaveAsync();

            return Ok(new VehicleDTO(newVehicle));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch (int id, JsonPatchDocument<Vehicle> vehicle)
        {
            if (vehicle != null)
            {
                var vehicleForUpdate = await _repo.GetByIdAsync(id);
                vehicle.ApplyTo(vehicleForUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _repo.SaveAsync();
                return Ok(new VehicleDTO(vehicleForUpdate));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicle)
        {
            var vehicleForUpdate = await _repo.GetByIdAsync(id);
            vehicleForUpdate.Name = vehicle.Name;
            vehicleForUpdate.Power = vehicle.Power;

            await _repo.SaveAsync();

            return Ok(new VehicleDTO(vehicleForUpdate));
        }
    }
}
