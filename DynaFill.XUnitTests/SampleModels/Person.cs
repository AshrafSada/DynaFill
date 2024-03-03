namespace DynaFill.XUnitTests.SampleModels
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<string> PhoneNumbers { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public Address Address { get; set; } = null!;
        public Gender Gender { get; set; }
    }

    public class Address
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
    }
}
