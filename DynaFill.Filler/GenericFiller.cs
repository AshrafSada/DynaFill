using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DynaFill.Filler
{
    public class GenericFiller<T> where T : class
    {
        private const string Mneumonic = "Auto-Generated String";
        private static readonly string pathToNames = Path.Combine(Directory.GetCurrentDirectory(), "DataFiles", "names.json");
        private static readonly string pathToDepartments = Path.Combine(Directory.GetCurrentDirectory(), "DataFiles", "departments.json");
        private static readonly string pathToCompanies = Path.Combine(Directory.GetCurrentDirectory(), "DataFiles", "companies.json");
        private static readonly string pathToJobTitles = Path.Combine(Directory.GetCurrentDirectory(), "DataFiles", "jobTitles.json");

        private static readonly Random rand = new Random();

        public bool AttributesFilled { get; private set; }

        public T Fill(T obj)
        {
            var baseType = typeof(T);
            var properties = baseType.GetProperties();

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;

                switch (propertyType.Name)
                {
                    case "Int64":
                        property.SetValue(obj, rand.Next(Int32.MaxValue));
                        break;

                    case "Byte":
                        property.SetValue(obj, (byte)rand.Next(255));
                        break;

                    case "Byte[]":
                        property.SetValue(obj, new byte[] { (byte)rand.Next(255) });
                        break;

                    case "Guid":
                        property.SetValue(obj, Guid.NewGuid());
                        break;

                    case "Boolean":
                        property.SetValue(obj, true);
                        break;

                    case "Char":
                        property.SetValue(obj, '\u2649');
                        break;

                    case "String":
                        if (property.Name == "FirstName" || property.Name == "LastName")
                        {
                            property.SetValue(obj, GenerateRandomName());
                        }
                        else if (property.Name.Contains("Company"))
                        {
                            property.SetValue(obj, GenerateCompanyName());
                        }
                        else if (property.Name.Contains("Department"))
                        {
                            property.SetValue(obj, GenerateDepartmentName());
                        }
                        else if (property.Name.Contains("JobTitle"))
                        {
                            property.SetValue(obj, GenerateRandomJobTitle());
                        }
                        else
                        {
                            property.SetValue(obj, Mneumonic);
                        }
                        break;

                    case "DateTime":
                        property.SetValue(obj, DateTime.Now);
                        break;

                    case "DateTimeOffset":
                        property.SetValue(obj, DateTimeOffset.UtcNow);
                        break;

                    case "Decimal":
                        property.SetValue(obj, (decimal)rand.NextDouble());
                        break;

                    case "Double":
                        property.SetValue(obj, rand.NextDouble());
                        break;

                    case "Single":
                        property.SetValue(obj, (float)rand.NextDouble());
                        break;

                    case "SByte":
                        property.SetValue(obj, (sbyte)rand.Next(255));
                        break;

                    case "UInt16":
                        property.SetValue(obj, (ushort)rand.Next(65535));
                        break;

                    case "UInt32":
                        property.SetValue(obj, (uint)rand.Next(65535));
                        break;

                    case "UInt64":
                        property.SetValue(obj, (ulong)rand.Next(65535));
                        break;

                    case "Int16":
                        property.SetValue(obj, (short)rand.Next(65535));
                        break;

                    case "Int32":
                        property.SetValue(obj, rand.Next(65535));
                        break;

                    case "Enum":
                        var enumValues = Enum.GetValues(propertyType);
                        var enumValue = enumValues.GetValue(rand.Next(enumValues.Length));
                        property.SetValue(obj, enumValue);
                        break;
                }
            }

            AttributesFilled = properties.Any(p => p is not null);

            return obj;
        }

        private static string GenerateCompanyName()
        {
            var json = File.ReadAllText(pathToCompanies);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            string[] names = JsonConvert.DeserializeObject<string[]>(json, settings);

            return names[rand.Next(0, names.Length)];
        }

        private static string GenerateDepartmentName()
        {
            var json = File.ReadAllText(pathToDepartments);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            string[] names = JsonConvert.DeserializeObject<string[]>(json, settings);

            return names[rand.Next(0, names.Length)];
        }

        private static string GenerateRandomName()
        {
            var json = File.ReadAllText(pathToNames);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            string[] names = JsonConvert.DeserializeObject<string[]>(json, settings);

            return names[rand.Next(0, names.Length)];
        }

        private static string GenerateRandomJobTitle()
        {
            var json = File.ReadAllText(pathToJobTitles);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            string[] names = JsonConvert.DeserializeObject<string[]>(json, settings);

            return names[rand.Next(0, names.Length)];
        }
    }
}
