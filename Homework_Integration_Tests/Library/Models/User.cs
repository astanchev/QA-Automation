namespace Library.Models
{
    using Newtonsoft.Json;

    public class User
    {
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore, PropertyName = "householdId")]
        public long? HouseholdId { get; set; }


        [JsonProperty(NullValueHandling=NullValueHandling.Ignore, PropertyName = "wishlistId")]
        public long? WishlistId { get; set; }
    }
}