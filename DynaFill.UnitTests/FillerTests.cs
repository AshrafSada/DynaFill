using DynaFill.Filler;
using Xunit;

namespace DynaFill.UnitTests
{
    public class FillerTests
    {
        [Fact]
        public void Should_Create_Class_Object_Type_And_Fill_Object()
        {
            // Prepare
            var fakeModel = new FakeModel();

            // Invoke
            var createdInstance = DynaFiller.CreateTargetInstance(fakeModel);

            // Verify
            Assert.True(createdInstance.GetType().IsClass);
            Assert.NotNull(createdInstance);
        }
    }
}
