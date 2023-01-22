using System.Collections.Generic;

namespace ProiectDaw.Models.Entities
{
    public class QATester
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<VehicleTester> VehicleTesters { get; set; }

    }
}
