namespace RestAssured.Net.Workshop.Examples
{
    using NUnit.Framework;
    using static RestAssured.Dsl;

    [TestFixture]
    public class Examples03 : ExampleBase
    {
        [Test]
        public void ExampleUsingBasicAuth()
        {
            Given()
            .BasicAuth("john", "demo")
            .When()
            .Get("http://localhost:9876/basic-auth")
            .Then()
            .StatusCode(200);
        }

        [Test]
        public void ExampleUsingOAuth2()
        {
            Given()
            .OAuth2("this_is_my_token")
            .When()
            .Get("http://localhost:9876/oauth2")
            .Then()
            .StatusCode(200);
        }

        [Test]
        public void ExampleExtractingResponseBodyElement()
        {
            string placeName = 

            (string)Given()
            .When()
            .Get("http://localhost:9876/us/90210")
            .Then()
            .Extract()
            .Body("$.Places[0].Name");

            Assert.That(placeName, Is.EqualTo("Sun City"));
        }
    }
}
