using System;
using System.Reflection;

namespace DynaFill.Filler
{
    public class DynaFiller
    {
        // Step 3: Create new instance of target object
        public static object CreateTargetInstance(object target)
        {
            var targetType = target.GetType();
            var instance = Activator.CreateInstance(targetType);
            if (instance != null)
            {
                _ = FillAttributes(instance);
            }
            return instance;
        }

        // Step 2: Fill target model attributes
        private static bool FillAttributes(object target)
        {
            var targetProperties = target.GetType().GetProperties();

            foreach (PropertyInfo info in targetProperties)
            {
                switch (info.PropertyType.Name)
                {
                    case "Int32":
                        info.SetValue(target, 1073741823);

                        break;

                    case "String":
                        info.SetValue(target, "Mnemonic Test Text");

                        break;

                    case "Char":
                        info.SetValue(target, '\u2649');
                        break;

                    case "DateTime":
                        info.SetValue(target, DateTime.Now);
                        break;

                    case "DateTimeOffset":
                        info.SetValue(target, DateTimeOffset.UtcNow);
                        break;

                    case "Decimal":
                        info.SetValue(target, 72514264337.75315741862M);
                        break;

                    case "Boolean":
                        info.SetValue(target, true);

                        break;

                    default:
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
