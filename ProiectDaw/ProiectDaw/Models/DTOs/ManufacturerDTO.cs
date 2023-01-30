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
            this.Id = manufacturer.Id;
            this.Name = manufacturer.Name;
            this.Country = manufacturer.Country;
            this.Location = manufacturer.Location;
            this.Vehicles = new List<Vehicle>();
        }

    }
}
