namespace IntegrationTests.Models
{
    using Newtonsoft.Json;
    using System;

    public partial class Household
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)] 
        public long? Id { get; set; }


        [JsonProperty("name")] 
        public string Name { get; set; }
    }

    public partial class Household
    {
        public static Household FromJson(string json) =>
            JsonConvert.DeserializeObject<Household>(json, IntegrationTests.Models.Converter.Settings);
    }
}