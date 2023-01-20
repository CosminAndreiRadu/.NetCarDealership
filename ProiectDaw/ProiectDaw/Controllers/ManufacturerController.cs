﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ProiectDaw.Entities;
using ProiectDaw.Entities.DTOs;
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

    }
}