namespace RestAssured.Net.Workshop.Examples
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using WireMock.Server;
    using WireMock.RequestBuilders;
    using WireMock.ResponseBuilders;
    using RestAssured.Net.Workshop.Examples.Models;
    using WireMock.Matchers;

    public class ExampleBase
    {
        protected WireMockServer Server { get; private set; }

        private readonly string expectedSerializedJsonRequestBody = "{\"Country\":\"Italy\",\"State\":\"Tuscany\",\"ZipCode\":50123,\"Places\":[{\"Name\":\"Florence\",\"Inhabitants\":383000,\"IsCapital\":false}]}";

        private readonly string xmlBody = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Location xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Country>United States</Country><State>California</State><ZipCode>90210</ZipCode><Places><Place><Name>Sun City</Name><Inhabitants>100000</Inhabitants><IsCapital>true</IsCapital></Place><Place><Name>Pleasure Meadow</Name><Inhabitants>50000</Inhabitants><IsCapital>false</IsCapital></Place></Places></Location>";

        [SetUp]
        public void StartServer()
        {
            Server = WireMockServer.Start(9876);

            PopulateLocationResponseForUs90210();
            PopulateLocationResponseForIt50123();
            PopulateQueryParamResponse();
            PopulateBasicAuthResponse();
            PopulateOAuth2Response();
            PopulateXmlResponse();
            CreateJsonSerializationStub();
            CreateXmlSerializationStub();
        }

        private void PopulateLocationResponseForUs90210()
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

        private void PopulateLocationResponseForIt50123()
        {
            Place firstPlace = new Place
            {
                Name = "Florence",
                Inhabitants = 383000,
                IsCapital = false,
            };

            Location location = new Location
            {
                Country = "Italy",
                State = "Tuscany",
                ZipCode = 50123,
                Places = new List<Place>() { firstPlace },
            };

            Server.Given(Request.Create().WithPath("/it/50123").UsingGet())
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(location)
                .WithStatusCode(200));
        }

        private void PopulateQueryParamResponse()
        {
            Server.Given(Request.Create().WithPath("/user").UsingGet()
                .WithParam("name", "John"))
                .RespondWith(Response.Create()
                .WithStatusCode(200));
        }

        private void PopulateBasicAuthResponse()
        {
            Server.Given(Request.Create().WithPath("/basic-auth").UsingGet()
                .WithHeader("Authorization", "Basic am9objpkZW1v"))
                .RespondWith(Response.Create()
                .WithStatusCode(200));
        }

        private void PopulateOAuth2Response()
        {
            Server.Given(Request.Create().WithPath("/oauth2").UsingGet()
                .WithHeader("Authorization", "Bearer this_is_my_token"))
                .RespondWith(Response.Create()
                .WithStatusCode(200));
        }

        private void PopulateXmlResponse()
        {
            Server.Given(Request.Create().WithPath("/xml/us/90210").UsingGet())
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/xml")
                .WithBody(xmlBody)
                .WithStatusCode(200));
        }

        private void CreateJsonSerializationStub()
        {
            Server.Given(Request.Create().WithPath("/json-serialization").UsingPost()
                .WithBody(new JsonMatcher(expectedSerializedJsonRequestBody)))
                .RespondWith(Response.Create()
                .WithStatusCode(201));
        }
        private void CreateXmlSerializationStub()
        {
            Server.Given(Request.Create().WithPath("/xml-serialization").UsingPost()
                .WithBody(new XPathMatcher("//Places[count(Place) = 2]")))
                .RespondWith(Response.Create()
                .WithStatusCode(201));
        }

        [TearDown]
        public void StopServer()
        {
            Server.Stop();
        }
    }
}
