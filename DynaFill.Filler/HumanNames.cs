using System.Text.Json.Serialization;

namespace DynaFill.Filler
{
   public class HumanNames
   {
      [JsonPropertyName("names")]
      public string Names { get; set; }
   }
}
