namespace IntegrationTests.Models
{
    using Newtonsoft.Json;

    public partial class User
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)] 
        public long? Id { get; set; }


        [JsonProperty("email")] 
        public string Email { get; set; }


        [JsonProperty("firstName")] 
        public string FirstName { get; set; }


        [JsonProperty("lastName")] 
        public string LastName { get; set; }


        [JsonProperty("wishlistId", NullValueHandling = NullValueHandling.Ignore)] 
        public long? WishlistId { get; set; }


        [JsonProperty("householdId")] 
        public long HouseholdId { get; set; }
    }

    public partial class User
    {
        public static User FromJson(string json) =>
            JsonConvert.DeserializeObject<User>(json, IntegrationTests.Models.Converter.Settings);
    }
}