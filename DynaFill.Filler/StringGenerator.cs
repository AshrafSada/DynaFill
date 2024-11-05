using System;
using System.Linq;

namespace DynaFill.Filler
{
    internal static class StringGenerator
    {
        internal const string Mnemonic = "Auto-Generated Mnemonic String";

        internal static readonly Random rand = new Random();

        internal static string GenerateCompanyName()
        {
            var names = PreSetData.GetCompanyNames();
            return names[rand.Next(0, names.Length)];
        }

        internal static string GenerateDepartmentName()
        {
            var names = PreSetData.GetDepartmentNames();

            return names[rand.Next(0, names.Length)];
        }

        internal static string GenerateRandomName()
        {
            var names = PreSetData.GetHumanNames();

            return names[rand.Next(0, names.Length)];
        }

        internal static string GenerateRandomJobTitle()
        {
            var names = PreSetData.GetJobTitleNames();
            return names[rand.Next(0, names.Length)];
        }

        internal static string GenerateRandomPassword()
        {
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@$_";
            var password = new string(Enumerable
                .Repeat(str, 8)
                    .Select(s => s[rand.Next(s.Length)])
                        .ToArray());

            return password.ToCamelCase();
        }

        internal static string GenerateRandomEmail()
        {
            var names = PreSetData.GetHumanNames();
            var domains = PreSetData.GetEmailDomains();

            return $"{names[rand.Next(0, names.Length)]}@{domains[rand.Next(0, domains.Length)]}";
        }

        internal static string GenerateRandomPhoneNumber()
        {
            var areaCode = rand.Next(100, 999);
            var prefix = rand.Next(100, 999);
            var lineNumber = rand.Next(1000, 9999);

            return $"({areaCode}) {prefix}-{lineNumber}";
        }
    }
}
