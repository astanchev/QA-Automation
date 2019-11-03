namespace Library.Models
{
    using Newtonsoft.Json;

    public class Household
    {

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public long? Id { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}