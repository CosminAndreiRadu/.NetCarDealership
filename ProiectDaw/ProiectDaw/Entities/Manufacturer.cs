using System.Collections.Generic;

namespace ProiectDaw.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Location Location { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        

        
    }
}
