using NUnit.Framework;
using RestAssured.Request.Builders;

using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Answers
{
    public class Answers02 : TestBase
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
         * Transform these tests into a single ParameterizedTest,
         * using a CsvSource data source with three test data rows:
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

        [TestCase(12212, "John", "Smith", TestName = "Customer with ID 12212 is John Smith")]
        [TestCase(12323, "Susan", "Holmes", TestName = "Customer with ID 12323 is Susan Holmes")]
        [TestCase(14545, "Anna", "Grant", TestName = "Customer with ID 14545 is Anna Grant")]
        public void CheckFirstNameAndLastNameForCustomerIDs
            (int customerId, string expectedFirstName, string expectedLastName)
        {
            Given()
                .Spec(requestSpecification)
                .PathParam("customerId", customerId)
                .When()
                .Get("/customer/[customerId]")
                .Then()
                .Body("$.firstName", NHamcrest.Is.EqualTo(expectedFirstName))
                .Body("$.lastName", NHamcrest.Is.EqualTo(expectedLastName));
        }
    }
}
