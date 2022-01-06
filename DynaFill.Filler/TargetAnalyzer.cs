using System;
using System.Reflection;

namespace DynaFill.Filler
{
    public class TargetAnalyzer
    {
        public Type TargetType { get; private set; }

        public string TargetName { get; private set; }
        public PropertyInfo[] TargetProperties { get; private set; }

        public Object TargetInstance { get; set; }

        private readonly CustomAttributeData _customAttributeData;

        public void AnalyzeTarget(object target)
        {
            TargetType = target.GetType();

            TargetName = target.GetType().Name;

            TargetProperties = target.GetType().GetProperties();
        }

        public object CreateTargetInstance()
        {
            var instance = Activator.CreateInstance(TargetType);
            FillAttributes(instance);

            return instance;
        }

        private void FillAttributes(object target)
        {
            foreach (PropertyInfo info in TargetProperties)
            {
                switch (info.PropertyType.FullName)
                {
                    case "System.Int32":
                        info.SetValue(target, 1073741823);
                        Console.WriteLine($"|Prop Name: {info.Name} | " +
                            $"Property Type: {info.PropertyType.FullName} | " +
                            $"System Type: System.Int32 | " +
                            $"Property Value: {info.GetValue(target)}");
                        break;

                    case "System.String":
                        info.SetValue(target, "Mnemonic Test Text");
                        Console.WriteLine($"|Prop Name: {info.Name} | " +
                         $"Property Type: {info.PropertyType.FullName} | " +
                         $"System Type: System.String | " +
                         $"Property Value: {info.GetValue(target)}");
                        break;

                    case "System.Char":
                        info.SetValue(target, '\u2649');
                        Console.WriteLine($"|Prop Name: {info.Name} | " +
                         $"Property Type: {info.PropertyType.FullName} | " +
                         $"System Type: System.Char | " +
                         $"Property Value: {Convert.ToChar(info.GetValue(target))}");
                        break;

                    case "System.DateTime":
                        info.SetValue(target, DateTime.Now);
                        Console.WriteLine($"|Prop Name: {info.Name} | " +
                         $"Property Type: {info.PropertyType.FullName} | " +
                         $"System Type: System.DateTime | " +
                         $"Property Value: {info.GetValue(target)}");
                        break;

                    case "System.DateTimeOffset":
                        info.SetValue(target, DateTimeOffset.UtcNow);
                        Console.WriteLine($"|Prop Name: {info.Name} | " +
                         $"Property Type: {info.PropertyType.FullName} | " +
                         $"System Type: System.DateTimeOffset | " +
                         $"Property Value: {info.GetValue(target)}");
                        break;

                    case "System.Decimal":
                        info.SetValue(target, 72514264337.75315741862M);
                        Console.WriteLine($"|Prop Name: {info.Name} | " +
                         $"Property Type: {info.PropertyType.FullName} | " +
                         $"System Type: System.Decimal | " +
                         $"Property Value: {info.GetValue(target)}");
                        break;

                    case "System.Boolean":
                        info.SetValue(target, true);
                        Console.WriteLine($"|Prop Name: {info.Name} | " +
                         $"Property Type: {info.PropertyType.FullName} | " +
                         $"System Type: System.Boolean | " +
                         $"Property Value: {info.GetValue(target)}");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
