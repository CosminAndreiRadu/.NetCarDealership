using ProiectDaw.Models.Entities;

namespace ProiectDaw.Models.DTOs
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public LocationDTO(Location loc) 
        {
            this.Id = loc.Id;
            this.City = loc.City;
            this.Street = loc.Street;
            this.ZipCode = loc.ZipCode;
            this.ManufacturerId = loc.ManufacturerId;
            this.Manufacturer = loc.Manufacturer;
        }

    }
}
