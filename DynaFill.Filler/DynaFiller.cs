using System;
using System.Reflection;
using DynaFill.Filler.Helpers;

namespace DynaFill.Filler
{
    public static class DynaFiller
    {
        private static Random _rand = new Random();

        // Step 3: Create new instance of target object
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

        // Step 2: Fill target model attributes
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
                        propInfo.SetValue(target, decimal.MaxValue - 1);
                        break;

                    case "Int16":
                        propInfo.SetValue(target, (Int16)_rand.Next(Int16.MaxValue - 1));
                        break;

                    case "Int32":
                        propInfo.SetValue(target, _rand.Next(Int32.MaxValue - 1));
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