namespace DynaFill.XUnitTests.SampleModels
{
    public class Employee
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public Department Department { get; set; } = null!;
        public decimal Salary { get; set; }
        public byte[] Image { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTimeOffset LastModied { get; set; }
        public float DailyHours { get; set; }
    }
}
