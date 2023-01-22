namespace ProiectDaw.Models.Entities
{
    public class VehicleTester
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int QATesterId { get; set; }
        public QATester QATester { get; set; }


    }
}
