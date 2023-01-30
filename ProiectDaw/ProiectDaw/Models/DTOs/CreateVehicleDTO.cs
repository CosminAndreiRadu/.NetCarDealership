using ProiectDaw.Models.Entities;

namespace ProiectDaw.Models.DTOs
{
    public class CreateVehicleDTO
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public Manufacturer Manufacturer { get; set; }

    }
}
