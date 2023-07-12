// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using DynaFill.Filler;

internal static class Program
{
   private static void Main(string[] args)
   {
      var p = new Person();
      var pGenerated = (Person)DynaFiller.Fill(p, true, false);
      pGenerated.Department = (Department)DynaFiller.Fill(new Department(), false, true);

      Console.WriteLine($"Person Guid: {pGenerated.Guid}");
      Console.WriteLine($"Person Id: {pGenerated.Id}");
      Console.WriteLine($"Person FirstName: {pGenerated.FirstName}");
      Console.WriteLine($"Person LastName: {pGenerated.LastName}");
      Console.WriteLine($"Person ByteData: {pGenerated.ByteData}");
      for (int i = 0; i < pGenerated.ByteDataArray.Length; i++)
      {
         Console.WriteLine($"Person ByteDataArray[{i}]: {pGenerated.ByteDataArray[i]}");
      }
      Console.WriteLine($"Person Salary: {pGenerated.Salary}");
      Console.WriteLine($"Person Rank: {pGenerated.Rank}");
      Console.WriteLine($"Person NationalNo: {pGenerated.NationalNo}");

      Console.WriteLine("related entities:\n");
      Console.WriteLine($"Person Department Id: {pGenerated.Department.Id}");
      Console.WriteLine($"Person Department Name: {pGenerated.Department.Name}");
   }
}
