using ProiectDaw.Models.Entities;
using System.Collections.Generic;

namespace ProiectDaw.Models.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public List<VehicleTester> VehicleTesters { get; set; }

        public VehicleDTO(Vehicle vehicle)
        {
            this.Id = vehicle.Id;
            this.Name = vehicle.Name;   
            this.Power = vehicle.Power;
            this.Manufacturer = vehicle.Manufacturer;
            this.VehicleTesters = new List<VehicleTester>();
        }
    }
}
