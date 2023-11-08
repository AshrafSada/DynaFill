using DynaFill.Filler;

namespace DynaFill.Tests
{
    public class FillerTests
    {
        [Fact]
        public void DynaFillShouldCreateAndFillDepartmentClass()
        {
            // Arrange
            var department = new Department();

            // Act
            var filledDepartment = new GenericFiller<Department>().Fill(department);
            filledDepartment.Employees = new List<Employee>()
            {
                new GenericFiller<Employee>().Fill(new Employee()),
            };

            // Assert
            Assert.NotNull(filledDepartment);
            Assert.NotEqual(0, filledDepartment.Id);
            Assert.NotEmpty(filledDepartment.DepartmentName);
            Assert.NotEmpty(filledDepartment.CompanyName);
            Assert.NotNull(filledDepartment.Employees);
        }

        [Fact]
        public void DynaFillShouldCreateAndFillEmployeeClass()
        {
            // Arrange
            var employee = new Employee();

            // Act
            var filledEmployee = new GenericFiller<Employee>().Fill(employee);
            filledEmployee.Department = new GenericFiller<Department>().Fill(new Department());

            // Assert
            Assert.NotNull(filledEmployee);
            Assert.NotEqual(0, filledEmployee.Id);
            Assert.NotEmpty(filledEmployee.FirstName);
            Assert.NotEmpty(filledEmployee.LastName);
            Assert.NotEmpty(filledEmployee.Email);
            Assert.NotEmpty(filledEmployee.PhoneNumber);
            Assert.NotEqual(0, filledEmployee.Salary);
            Assert.NotEqual(0, filledEmployee.DailyHours);
            Assert.True(filledEmployee.IsActive);
            Assert.NotNull(filledEmployee.Department);
            Assert.NotEqual(0, filledEmployee.Department.Id);
            Assert.NotEmpty(filledEmployee.Department.DepartmentName);
            Assert.NotEmpty(filledEmployee.Department.CompanyName);
        }
    }
}
