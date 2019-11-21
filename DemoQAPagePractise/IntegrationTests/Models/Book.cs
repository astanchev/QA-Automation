namespace IntegrationTests.Models
{
    using Newtonsoft.Json;
    using System;

    public partial class Book
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("publicationDate")]
        public DateTimeOffset PublicationDate { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }
    }

    public partial class Book
    {
        public static Book FromJson(string json) => JsonConvert.DeserializeObject<Book>(json, Converter.Settings);
    }

}
