using ProiectDaw.Models.Entities;

namespace ProiectDaw.Models.DTOs
{
    public class CreateLocationDTO
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public int ManufacturerId { get; set; }

    }
}
