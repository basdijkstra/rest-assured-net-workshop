using NUnit.Framework;
using RestAssured.Request.Builders;

using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Exercises
{
    public class Exercises02 : TestBase
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

        /**
         * Transform these tests into a parameterized test, with
         * three [TestCase] attributes using the following test data:
         * ------------------------------------
         * customer ID | first name | last name
         * ------------------------------------
         * 12212       | John       | Smith
         * 12323       | Susan      | Holmes
         * 14545       | Anna       | Grant
         * 
         * Request user data for the given user IDs by sending
         * an HTTP GET to /customer/<customerID>.
         * 
         * Use the test data collection created
         * above. Check that both the first name and the last name
         * for each of the customer IDs matches the expected values
         * listed in the table above
         * 
         * Use the JsonPath expressions "$.firstName" and "$.lastName",
         * respectively, to extract the required response body elements
         */

        [Test]
        public void RequestDataForCustomer12212_CheckFirstAndLastName_ExpectJohnSmith()
        {
            Given()
                .Spec(requestSpecification)
                .When()
                .Get("/customer/12212")
                .Then()
                .Body("$.firstName", NHamcrest.Is.EqualTo("John"))
                .Body("$.lastName", NHamcrest.Is.EqualTo("Smith"));
        }

        [Test]
        public void RequestDataForCustomer12323_CheckFirstAndLastName_ExpectSusanHolmes()
        {
            Given()
                .Spec(requestSpecification)
                .When()
                .Get("/customer/12323")
                .Then()
                .Body("$.firstName", NHamcrest.Is.EqualTo("Susan"))
                .Body("$.lastName", NHamcrest.Is.EqualTo("Holmes"));
        }

        [Test]
        public void RequestDataForCustomer14545_CheckFirstAndLastName_ExpectAnnaGrant()
        {
            Given()
                .Spec(requestSpecification)
                .When()
                .Get("/customer/14545")
                .Then()
                .Body("$.firstName", NHamcrest.Is.EqualTo("Anna"))
                .Body("$.lastName", NHamcrest.Is.EqualTo("Grant"));
        }
    }
}
