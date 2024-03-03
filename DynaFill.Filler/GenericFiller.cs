using System;
using System.Linq;

namespace DynaFill.Filler
{
    /// <summary>
    /// Generic Filler class to fill the properties of the object with random values
    /// </summary>
    /// <typeparam name="T">Object Name</typeparam>
    public class GenericFiller<T> where T : class
    {
        public bool AttributesFilled { get; private set; }

        /// <summary>
        /// Fills the properties of the object with random values
        /// </summary>
        /// <param name="obj">Object instance</param>
        /// <returns>Filled object instance</returns>
        public T Fill(T obj)
        {
            var baseType = typeof(T);
            var properties = baseType.GetProperties();

            // check if base type is inheriting from any other object
            var isSubClass = baseType.BaseType != typeof(object);
            if (isSubClass)
            {
                // add properties from base class to the array
                properties = properties.Concat(baseType.BaseType.GetProperties()).ToArray();
            }

            // check if base type is nested class
            if (baseType.IsNested)
            {
                // add properties from parent class to the array
                properties = properties.Concat(baseType.DeclaringType.GetProperties()).ToArray();
            }

            // check if base type is a generic class
            if (baseType.IsGenericType)
            {
                // add properties from generic class to the array
                properties = properties.Concat(baseType.GetGenericArguments().First().GetProperties()).ToArray();
            }

            // check if base type is a user-defined class
            if (baseType.IsClass)
            {
                // add properties from user-defined class to the array
                properties = properties.Concat(baseType.GetProperties()).ToArray();
            }

            // check if base type is an has collection properties
            if (baseType.IsArray)
            {
                // add properties from collection class to the array
                properties = properties.Concat(baseType.GetElementType().GetProperties()).ToArray();
            }

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;

                switch (propertyType.Name)
                {
                    case "Int64":
                        property.SetValue(obj, StringGenerator.rand.Next(Int32.MaxValue));
                        break;

                    case "Byte":
                        property.SetValue(obj, (byte)StringGenerator.rand.Next(255));
                        break;

                    case "Byte[]":
                        property.SetValue(obj, new byte[] { (byte)StringGenerator.rand.Next(255) });
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
                            property.SetValue(obj, StringGenerator.GenerateRandomName());
                        }
                        else if (property.Name.Contains("Company"))
                        {
                            property.SetValue(obj, StringGenerator.GenerateCompanyName());
                        }
                        else if (property.Name.Contains("Department"))
                        {
                            property.SetValue(obj, StringGenerator.GenerateDepartmentName());
                        }
                        else if (property.Name.Contains("JobTitle"))
                        {
                            property.SetValue(obj, StringGenerator.GenerateRandomJobTitle());
                        }
                        else if (property.Name.Contains("UserName", StringComparison.OrdinalIgnoreCase)
                            || property.Name.Contains("Email", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(obj, StringGenerator.GenerateRandomEmail());
                        }
                        else if (property.Name.Contains("Password", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(obj, StringGenerator.GenerateRandomPassword());
                        }
                        else if (property.Name.Contains("CreatedBy", StringComparison.OrdinalIgnoreCase)
                            || property.Name.Contains("ModifiedBy", StringComparison.OrdinalIgnoreCase)
                            || property.Name.Contains("UpdatedBy", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(obj, StringGenerator.GenerateRandomName());
                        }
                        else if (property.Name.Contains("PhoneNumber", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(obj, StringGenerator.GenerateRandomPhoneNumber());
                        }
                        else
                        {
                            property.SetValue(obj, StringGenerator.Mneumonic);
                        }
                        break;

                    case "DateTime":
                        property.SetValue(obj, DateTime.Now);
                        break;

                    case "DateTimeOffset":
                        property.SetValue(obj, DateTimeOffset.UtcNow);
                        break;

                    case "Decimal":
                        property.SetValue(obj, (decimal)StringGenerator.rand.NextDouble());
                        break;

                    case "Double":
                        property.SetValue(obj, StringGenerator.rand.NextDouble());
                        break;

                    case "Single":
                        property.SetValue(obj, (float)StringGenerator.rand.NextDouble());
                        break;

                    case "SByte":
                        property.SetValue(obj, (sbyte)StringGenerator.rand.Next(255));
                        break;

                    case "UInt16":
                        property.SetValue(obj, (ushort)StringGenerator.rand.Next(65535));
                        break;

                    case "UInt32":
                        property.SetValue(obj, (uint)StringGenerator.rand.Next(65535));
                        break;

                    case "UInt64":
                        property.SetValue(obj, (ulong)StringGenerator.rand.Next(65535));
                        break;

                    case "Int16":
                        property.SetValue(obj, (short)StringGenerator.rand.Next(65535));
                        break;

                    case "Int32":
                        property.SetValue(obj, StringGenerator.rand.Next(65535));
                        break;

                    case "Enum":
                        var enumValues = Enum.GetValues(propertyType);
                        var enumValue = enumValues.GetValue(StringGenerator.rand.Next(enumValues.Length));
                        property.SetValue(obj, enumValue);
                        break;

                    case "Object":
                        property.SetValue(obj, new object());
                        break;
                }
            }

            AttributesFilled = properties.Any(p => p is not null);

            return obj;
        }
    }
}
