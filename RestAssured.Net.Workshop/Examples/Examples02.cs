namespace RestAssured.Net.Workshop.Examples
{
    using NUnit.Framework;
    using static RestAssured.Dsl;

    [TestFixture]
    public class Examples02 : ExampleBase
    {
        [Test]
        public void UsingQueryParameters()
        {
            Given()
            .QueryParam("name", "John")
            .When()
            .Get("http://localhost:9876/user")
            .Then()
            .StatusCode(200);
        }

        [Test]
        public void UsingPathParameters()
        {
            Given()
            .PathParam("countryCode", "us")
            .PathParam("zipCode", "90210")
            .When()
            .Get("http://localhost:9876/{{countryCode}}/{{zipCode}}")
            .Then()
            .StatusCode(200);
        }

        [TestCase("us", "90210", "Sun City", TestName = "Get locations for US zip code 90210")]
        [TestCase("it", "50123", "Florence", TestName = "Get locations for IT zip code 50123")]
        public void DemonstrateParameterizedTest(string countryCode, string zipCode, string expectedPlace)
        {
            Given()
            .PathParam("countryCode", countryCode)
            .PathParam("zipCode", zipCode)
            .When()
            .Get("http://localhost:9876/{{countryCode}}/{{zipCode}}")
            .Then()
            .StatusCode(200)
            .And()
            .Body("$.Places[0].Name", NHamcrest.Is.EqualTo(expectedPlace));
        }
    }
}
