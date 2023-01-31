using System;
using System.Reflection;
using DynaFill.Filler.Helpers;

namespace DynaFill.Filler
{
    public static class DynaFiller
    {
        private static readonly Random _rand = new Random();

        /// <summary>
        /// Create Target instance of an Object from user object type to process properties
        /// </summary>
        /// <param name="target">User Object instance</param>
        /// <param name="fillStringWithNames">True generate names for string property type</param>
        /// <returns>Object Instance</returns>
        public static object CreateTargetInstance(object target, bool fillStringWithNames)
        {
            var targetType = target.GetType();
            var instance = Activator.CreateInstance(targetType);
            if (instance != null)
            {
                _ = FillAttributes(instance, fillStringWithNames);
            }
            return instance;
        }

        /// <summary>
        /// Fill the target object attributes with values per property type
        /// </summary>
        /// <param name="target">Target Object</param>
        /// <param name="generateNames">True generate names for string property type</param>
        /// <returns>True if the attributes are filled, False if not all attributes fills</returns>
        private static bool FillAttributes(object target, bool generateNames)
        {
            var targetProperties = target.GetType().GetProperties();

            foreach (PropertyInfo propInfo in targetProperties)
            {
                switch (propInfo.PropertyType.Name)
                {
                    case "Boolean":
                        propInfo.SetValue(target, true);
                        break;

                    case "Char":
                        propInfo.SetValue(target, '\u2649');
                        break;

                    case "DateTime":
                        propInfo.SetValue(target, DateTime.Now);
                        break;

                    case "DateTimeOffset":
                        propInfo.SetValue(target, DateTimeOffset.UtcNow);
                        break;

                    case "Decimal":
                        propInfo.SetValue(target, decimal.MaxValue / 4);
                        break;

                    case "Int16":
                        propInfo.SetValue(target, (Int16)_rand.Next(Int16.MaxValue / 2));
                        break;

                    case "Int32":
                        propInfo.SetValue(target, _rand.Next(Int32.MaxValue / 4));
                        break;

                    case "Object":
                        propInfo.SetValue(target, new object());
                        break;

                    case "String":
                        if (generateNames)
                        { string randName = StringHelpers.GenerateRandomName(); propInfo.SetValue(target, randName); break; }
                        propInfo.SetValue(target, "Mnemonic Test Text");
                        break;
                }
            }

            bool attributesFilled = false;

            foreach (var attr in target.GetType().GetCustomAttributes())
            {
                if (attr != null)
                {
                    attributesFilled = true;
                }
            }

            return attributesFilled;
        }
    }
}