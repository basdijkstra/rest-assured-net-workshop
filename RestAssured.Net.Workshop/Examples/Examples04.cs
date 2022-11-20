namespace RestAssured.Net.Workshop.Examples
{
    using NUnit.Framework;
    using RestAssured.Net.Workshop.Examples.Models;
    using System.Collections.Generic;
    using static RestAssured.Dsl;

    [TestFixture]
    public class Examples04 : ExampleBase
    {
        [Test]
        public void ExampleSerializingToJson()
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

            Given()
            .Body(location)
            .When()
            .Post("http://localhost:9876/json-serialization")
            .Then()
            .StatusCode(201);
        }

        [Test]
        public void ExampleSerializingToXml()
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

            Given()
            .ContentType("application/xml")
            .Body(location)
            .When()
            .Post("http://localhost:9876/xml-serialization")
            .Then()
            .StatusCode(201);
        }

        [Test]
        public void ExampleDeserializingFromJson()
        {
            Location location = 

            (Location)Given()
            .When()
            .Get("http://localhost:9876/us/90210")
            .As(typeof(Location));

            Assert.That(location.Country, Is.EqualTo("United States"));
            Assert.That(location.Places.Count, Is.EqualTo(2));
        }
    }
}
