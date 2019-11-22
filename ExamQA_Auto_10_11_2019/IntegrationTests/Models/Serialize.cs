namespace IntegrationTests.Models
{
    using Newtonsoft.Json;

    public static class Serialize
    {
        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, IntegrationTests.Models.Converter.Settings);
    }
}