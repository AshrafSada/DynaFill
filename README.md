# DynaFill Dynamic Object Filler

DynaFill is a dynamic object filler that can be used to fill objects with dynamic data. It can be used to fill objects with random data, for mocking, testing, and more.

## Usage Example

```csharp
using DynaFill.Filler;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsMarried { get; set; }
    public Address Address { get; set; }
    public List<string> PhoneNumbers { get; set; }
}

public class Address
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
}

// using XUnit
public class PersonTests
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
```
