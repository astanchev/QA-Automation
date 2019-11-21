namespace IntegrationTests
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;

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