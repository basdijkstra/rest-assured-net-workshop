namespace RestAssured.Net.Workshop.Examples
{
    using NUnit.Framework;
    using static RestAssured.Dsl;

    [TestFixture]
    public class Examples01 : ExampleBase
    {
        [Test]
        public void GetLocationsForUsZipCode90210()
        {
            Given()
            .When()
            .Get("http://localhost:9876/us/90210")
            .Then()
            .AssertThat()
            .StatusCode(200)
            .And()
            .ContentType("application/json")
            .And()
            .Body("$.Places[0].Name", NHamcrest.Is.EqualTo("Sun City"));
        }

        [Test]
        public void GetLocationsForUsZipCode90210InXml()
        {
            Given()
            .When()
            .Get("http://localhost:9876/xml/us/90210")
            .Then()
            .AssertThat()
            .StatusCode(200)
            .And()
            .ContentType("application/xml")
            .And()
            .Body("//Place[1]/Name", NHamcrest.Is.EqualTo("Sun City"));
        }
        
        [Test]
        public void DemonstrateRequestAndResponseLogging()
        {
            Given()
            .Log().All()
            .When()
            .Get("http://localhost:9876/us/90210")
            .Then()
            .Log().All()
            .And()
            .StatusCode(200);
        }
    }
}
