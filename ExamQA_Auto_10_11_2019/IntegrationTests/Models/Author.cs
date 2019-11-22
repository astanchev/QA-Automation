namespace IntegrationTests.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Author
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("genre", NullValueHandling = NullValueHandling.Ignore)]
        public string Genre { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Href { get; set; }

        [JsonProperty("rel", NullValueHandling = NullValueHandling.Ignore)]
        public string Rel { get; set; }

        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }
    }

    public partial class Author
    {
        public static Author FromJson(string json) =>
            JsonConvert.DeserializeObject<Author>(json, IntegrationTests.Models.Converter.Settings);
    }
}
