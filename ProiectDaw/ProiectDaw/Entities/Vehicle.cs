using System.Collections.Generic;

namespace ProiectDaw.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Power { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; } 

        public ICollection<VehicleTester> VehicleTesters{ get; set; }

    }
}
