namespace IntegrationTests.Models
{
    using Newtonsoft.Json;

    public partial class Wishlist
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)] 
        public long? Id { get; set; }


        [JsonProperty("name")] 
        public string Name { get; set; }
    }

    public partial class Wishlist
    {
        public static Wishlist FromJson(string json) =>
            JsonConvert.DeserializeObject<Wishlist>(json, IntegrationTests.Models.Converter.Settings);
    }
}