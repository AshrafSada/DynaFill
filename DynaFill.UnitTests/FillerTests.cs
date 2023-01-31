using DynaFill.Filler;
using DynaFill.UnitTests.DemoModels;
using Xunit;

namespace DynaFill.UnitTests
{
    public class FillerTests
    {
        [Fact]
        public void Dynafill_Should_Create_Vehicle_With_Properties()
        {
            // Prepare
            var vehicle = new Vehicle();

            // Invoke
            var vehicleWithProperties = DynaFiller.CreateTargetInstance(vehicle, false);

            // Verify
            Assert.True(vehicleWithProperties.GetType() == typeof(Vehicle));
            Assert.True(vehicleWithProperties.GetType().IsClass);
            Assert.NotNull(vehicleWithProperties);
        }

        [Fact]
        public void Dynafill_Should_Create_Car_With_Inherited_Properties()
        {
            // Prepare
            var car = new Car();

            // Invoke
            var carCreatedWithProperties = DynaFiller.CreateTargetInstance(car, true);

            // Verify
            Assert.True(carCreatedWithProperties.GetType() == typeof(Car));
            Assert.True(carCreatedWithProperties.GetType().IsClass);
            Assert.NotNull(carCreatedWithProperties);
        }
    }
}