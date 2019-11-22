using NUnit.Framework;

namespace IntegrationTests
{
    using System;
    using System.Net.Http;

    public class BaseTest
    {
        private const string listeningHost = @"https://libexam2.azurewebsites.net";
        public HttpClient Client { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(listeningHost);
            Client.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }
    }
}