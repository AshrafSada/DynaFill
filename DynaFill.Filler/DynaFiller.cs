using System;
using System.Reflection;

namespace DynaFill.Filler
{
   public static class DynaFiller
   {
      private static readonly Random _rand = new Random();

      /// <summary>
      /// Create Target instance of an Object from user object type to process properties
      /// </summary>
      /// <param name="target">User Object instance</param>
      /// <param name="withHumanNames">True generate names for string property type</param>
      /// <returns>Object Instance</returns>
      public static object Fill(object target, bool withHumanNames, bool withDepartmentNames)
      {
         var targetType = target.GetType();
         var instance = Activator.CreateInstance(targetType);
         if (instance != null)
         {
            _ = FillAttributes(instance, withHumanNames, withDepartmentNames);
         }
         return instance;
      }

      /// <summary>
      /// Fill the target object attributes with values per property type
      /// </summary>
      /// <param name="target">Target Object</param>
      /// <param name="includeHumanNames">True generate names for string property type</param>
      /// <returns>True if the attributes are filled, False if not all attributes fills</returns>
      private static bool FillAttributes(object target, bool includeHumanNames, bool includeDepartments)
      {
         foreach (PropertyInfo propInfo in target.GetType().GetProperties())
         {
            switch (propInfo.PropertyType.Name)
            {
               case "Int64":
                  propInfo.SetValue(target, _rand.Next(Int32.MaxValue));
                  break;

               case "Byte":
                  propInfo.SetValue(target, (byte)_rand.Next(255));
                  break;

               case "Byte[]":
                  propInfo.SetValue(target, new byte[] { (byte)_rand.Next(255) });
                  break;

               case "Guid":
                  propInfo.SetValue(target, Guid.NewGuid());
                  break;

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
                  propInfo.SetValue(target, decimal.MaxValue / 20807040628566084398385987M);
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
                  if (includeHumanNames)
                  {
                     string randName = DynaFillerHelpers.GenerateRandomName(); propInfo.SetValue(target, randName); break;
                  }
                  if (includeDepartments)
                  {
                     string randName = DynaFillerHelpers.GenerateDepartmentName(); propInfo.SetValue(target, randName); break;
                  }
                  propInfo.SetValue(target, "Mnemonic Test Text");
                  break;

               case "TimeSpan":
                  propInfo.SetValue(target, TimeSpan.FromMilliseconds(_rand.Next(Int32.MaxValue)));
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
