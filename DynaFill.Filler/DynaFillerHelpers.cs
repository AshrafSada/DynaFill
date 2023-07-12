using System;

namespace DynaFill.Filler;

internal static class DynaFillerHelpers
{
   /// <summary>
   /// Generate a random name from a list of names
   /// </summary>
   /// <returns></returns>
   internal static string GenerateRandomName()
   {
      var names = new String[]
      {
            "Aleksandar",
            "Branden",
            "Cameron",
            "Dylan",
            "Ethan",
            "Felix",
            "Gavin",
            "Hector",
            "Isaac",
            "Jacob",
            "Kaden",
            "Liam",
            "Mason",
            "Nathan",
            "Owen",
            "Parker",
            "Quinn",
            "Ryan",
            "Samuel",
            "Tristan",
            "Ulysses",
            "Victor",
            "Wyatt",
            "Xavier",
            "Yosef",
            "Zachary"
      };

      var rand = new Random();
      var randName = names[rand.Next(0, names.Length)];
      return randName;
   }

   internal static string GenerateDepartmentName()
   {
      var departments = new String[]
      {
         "Accounting", "Human Resources", "Information Technology", "Marketing", "Sales"
      };

      var rand = new Random();
      var randName = departments[rand.Next(0, departments.Length)];
      return randName;
   }
}
