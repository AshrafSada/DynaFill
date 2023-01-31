using System;

namespace DynaFill.UnitTests.DemoModels
{
    /// <summary>
    /// Base class for all vehicles
    /// </summary>
    public class Vehicle
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public long SerialNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short Year { get; set; }
    }
}