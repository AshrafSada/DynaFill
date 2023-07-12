namespace ConsoleApp1;

public class Person
{
   public Guid Guid { get; private set; }
   public int Id { get; private set; }

   public string FirstName { get; private set; }
   public string LastName { get; private set; }

   public byte ByteData { get; private set; }
   public byte[] ByteDataArray { get; private set; }
   public decimal Salary { get; private set; }
   public short Rank { get; private set; }
   public long NationalNo { get; private set; }

   public Department Department { get; set; } = null!;
}

public class Department
{
   public int Id { get; set; }
   public string? Name { get; set; }

   public List<Person> Persons { get; set; } = null!;
}
