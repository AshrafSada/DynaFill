using System;

namespace DynaFill.Filler
{
    public static class StringGenerator
    {
        public const string Mneumonic = "Auto-Generated String";

        public static readonly Random rand = new Random();

        public static string GenerateCompanyName()
        {
            var names = PreSetData.GetCompanyNames();
            return names[rand.Next(0, names.Length)];
        }

        public static string GenerateDepartmentName()
        {
            var names = PreSetData.GetDepartmentNames();

            return names[rand.Next(0, names.Length)];
        }

        public static string GenerateRandomName()
        {
            var names = PreSetData.GetHumanNames();

            return names[rand.Next(0, names.Length)];
        }

        public static string GenerateRandomJobTitle()
        {
            var names = PreSetData.GetJobTitleNames();
            return names[rand.Next(0, names.Length)];
        }
    }
}
