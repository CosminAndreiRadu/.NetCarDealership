using System.Collections.Generic;
using System.Net;
using ProiectDaw.Models.Entities;

namespace ProiectDaw.Models.DTOs
{
    public class ManufacturerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Location Location { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public ManufacturerDTO(Manufacturer manufacturer)
        {
            Id = manufacturer.Id;
            Name = manufacturer.Name;
            Country = manufacturer.Country;
            Location = manufacturer.Location;
            Vehicles = new List<Vehicle>();
        }

    }
}
