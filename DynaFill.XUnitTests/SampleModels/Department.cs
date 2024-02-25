namespace DynaFill.XUnitTests.SampleModels
{
    public class Department
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public List<Employee> Employees { get; set; } = null!;
    }
}
