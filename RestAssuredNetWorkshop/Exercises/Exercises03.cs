using NUnit.Framework;
using RestAssured.Request.Builders;

using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Exercises
{
    public class Exercises03 : TestBase
    {
        private RequestSpecification requestSpecification;

        [SetUp]
        public void CreateRequestSpecification()
        {
            requestSpecification = new RequestSpecBuilder()
                .WithBaseUri("http://localhost")
                .WithPort(9876)
                .Build();
        }

        [Test]
        public void UseRequestSpecification()
        {
            /**
             * Improve this test by using the request specification as defined in this
             * class and removing the duplicate properties from this test itself.
             */

            Given()
                .When()
                .Get("http://localhost:9876/customer/12212")
                .Then()
                .StatusCode(200);
        }

        [Test]
        public void GetTokenUsingBasicAuth_ExtractFromResponse_ThenReuseAsOAuthToken()
        {
            /**
             * Perform a GET request to /token and pass in basic
             * authentication details with username 'john' and
             * password 'demo'.
             * 
             * Extract the value of the 'token' element in the
             * response into a String variable.
             * 
             * Use the token to authenticate using OAuth2 when sending
             * a GET request to /secure/customer/12212
             * 
             * Verify that the status code of this response is equal to HTTP 200
             */
                
            Given()
                .Spec(requestSpecification);

            Given()
                .Spec(requestSpecification);
        }
    }
}
