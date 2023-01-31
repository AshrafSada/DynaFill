using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynaFill.Filler.Helpers
{
    public static class StringHelpers
    {
        public static string GenerateRandomName()
        {
            var dataFilePath = Path.Combine(Environment.CurrentDirectory, "DataFiles", "names.json");

            try
            {
                var json = File.ReadAllText(dataFilePath);

                var deserialized = JsonConvert.DeserializeObject<JObject>(json);

                var names = deserialized.SelectToken("names").ToArray();

                Random rand = new Random();
                string randName = new String(names[rand.Next(0, names.Length)].ToString());
                System.Console.WriteLine(randName);
                return randName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}