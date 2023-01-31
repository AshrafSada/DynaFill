

namespace DynaFill.UnitTests.DemoModels
{
    public class Car : Vehicle
    {
        public int Doors { get; set; }
        public bool IsSUV { get; set; }
        public decimal EstimatedValue { get; set; }
        public float Milage { get; set; }
        public decimal EngineCapacity { get; set; }

        public int ColorId { get; set; }
        public VehicleColor Color { get; set; }
    }
}