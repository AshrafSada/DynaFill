using DynaFill.Filler;
using DynaFill.XUnitTests.SampleModels;

namespace DynaFill.XUnitTests
{
    public class DynamicFillerTests
    {
        [Fact]
        public void Should_Fill_Department_And_Related_Collections()
        {
            // Arrange
            var department = new Department();
            var filler = new GenericFiller<Department>();

            // Act
            var filledDepartment = filler.Fill(department);
            filledDepartment.Employees = new List<Employee>()
            {
                new GenericFiller<Employee>().Fill(new Employee()),
            };

            // Assert
            Assert.NotNull(filledDepartment);
            Assert.NotEqual(0, filledDepartment.Id);
            Assert.NotNull(filledDepartment.DepartmentName);
            Assert.NotNull(filledDepartment.CompanyName);
            Assert.NotEmpty(filledDepartment.Employees);
        }

        [Fact]
        public void Should_Fill_Employee_And_Related_Models()
        {
            // Arrange
            var employeeObj = new Employee();
            var filler = new GenericFiller<Employee>();
            var employee = filler.Fill(employeeObj);
            employee.Department = new GenericFiller<Department>().Fill(new Department());

            // Act
            var filledEmployee = filler.Fill(employee);

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

        [Fact]
        public void Should_Fill_User_With_Guid()
        {
            // Arrange
            var user = new User();
            var filler = new GenericFiller<User>();

            // Act
            var filledUser = filler.Fill(user);

            // Assert
            Assert.NotNull(filledUser);
            Assert.NotEqual(Guid.Empty, filledUser.Id);
            Assert.NotEmpty(filledUser.FirstName);
            Assert.NotEmpty(filledUser.LastName);
            Assert.NotEmpty(filledUser.Email);
            Assert.NotEmpty(filledUser.PhoneNumber);
            Assert.NotEmpty(filledUser.Password);
        }

        [Fact]
        public void Should_Fill_Person_With_Related_Data()
        {
            // Arrange
            var personObj = new Person();
            var filler = new GenericFiller<Person>();

            // Act
            var person = filler.Fill(personObj);
            person.Address = new GenericFiller<Address>().Fill(new Address());
            person.PhoneNumbers = new List<string>() { "123-456-7890", "123-456-7888" };

            // Assert
            Assert.NotNull(person);
            Assert.NotEqual(0, person.Id);
            Assert.NotEmpty(person.Name);
            Assert.NotEmpty(person.LastName);
            Assert.NotEmpty(person.Email);
            Assert.NotEmpty(person.PhoneNumbers);
            Assert.NotEqual(DateTime.MinValue, person.BirthDate);
            Assert.True(person.IsActive);
            Assert.NotNull(person.Address);
            Assert.NotEmpty(person.Address.Street);
            Assert.NotEmpty(person.Address.City);
            Assert.NotEmpty(person.Address.State);
            Assert.NotEmpty(person.Address.ZipCode);
        }
    }
}
