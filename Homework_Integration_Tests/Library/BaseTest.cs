namespace Library
{
    using System;
    using System.Net.Http;
    using NUnit.Framework;

    public class BaseTest
    {
        private const string listeningHost = @"http://localhost:3000";
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