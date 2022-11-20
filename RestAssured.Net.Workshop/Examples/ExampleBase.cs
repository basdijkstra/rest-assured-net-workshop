namespace RestAssured.Net.Workshop.Examples
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using WireMock.Server;
    using WireMock.RequestBuilders;
    using WireMock.ResponseBuilders;
    using RestAssured.Net.Workshop.Examples.Models;

    public class ExampleBase
    {
        protected WireMockServer Server { get; private set; }

        [SetUp]
        public void StartServer()
        {
            Server = WireMockServer.Start(9876);

            PopulateLocationResponse();
        }

        private void PopulateLocationResponse()
        {
            Place firstPlace = new Place
            {
                Name = "Sun City",
                Inhabitants = 100000,
                IsCapital = true,
            };

            Place secondPlace = new Place
            {
                Name = "Pleasure Meadow",
                Inhabitants = 50000,
                IsCapital = false,
            };

            Location location = new Location
            {
                Country = "United States",
                State = "California",
                ZipCode = 90210,
                Places = new List<Place>() { firstPlace, secondPlace },
            };

            Server.Given(Request.Create().WithPath("/us/90210").UsingGet())
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(location)
                .WithStatusCode(200));
        }

        [TearDown]
        public void StopServer()
        {
            Server.Stop();
        }
    }
}
