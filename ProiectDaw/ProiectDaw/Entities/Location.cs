namespace ProiectDaw.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }    
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }



    }
}
