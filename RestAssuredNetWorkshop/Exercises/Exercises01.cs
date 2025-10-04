using NUnit.Framework;
using RestAssured.Logging;
using RestAssured.Request.Builders;

using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Exercises
{
    public class Exercises01 : TestBase
    {
        private RequestSpecification requestSpecification;

        [SetUp]
        public void CreateRequestSpecification()
        {
            var logConfiguration = new LogConfiguration
            {
                RequestLogLevel = RequestLogLevel.All,
                ResponseLogLevel = ResponseLogLevel.All,
            };

            requestSpecification = new RequestSpecBuilder()
                .WithBaseUri("http://localhost")
                .WithPort(9876)
                .WithLogConfiguration(logConfiguration)
                .Build();
        }
                
        [Test]
        public void RequestDataForCustomer12212_CheckResponseCode_Expect200()
        {
            /**
             * Send a GET request to /customer/12212
             * and check that the response has HTTP status code 200
             */

            Given()
                .Spec(requestSpecification);
        }

        [Test]
        public void RequestDataForCustomer99999_CheckResponseCode_Expect404()
        {
            /**
             * Send a GET request to /customer/99999
             * and check that the response has HTTP status code 404
             */

            Given()
                .Spec(requestSpecification);
        }

        [Test]
        public void RequestDataForCustomer12212_CheckContentType_ExpectApplicationJson()
        {
            /**
             * Send a GET request to /customer/12212
             * and check that the value of the response Content-Type header
             * is equal to 'application/json'
             */

            Given()
                .Spec(requestSpecification);
        }

        [Test]
        public void RequestDataForCustomer12212_CheckFirstName_ExpectJohn()
        {
            /**
             * Send a GET request to /customer/12212 and check
             * that the first name of the person associated with
             * this customer ID is 'John'.
             * 
             * Use the JsonPath expression "$.firstName" to
             * extract the required response body element
             */

            Given()
                .Spec(requestSpecification);
        }

        [Test]
        public void RequestDataForCustomer12212_CheckAddressCity_ExpectBeverlyHills()
        {
            /**
             * Send a GET request to /customer/12212 and check
             * that the city where the person associated with
             * this customer ID is living is 'Beverly Hills'.
             * 
             * Use the JsonPath expression "$.address.city" to
             * extract the required response body element
             */

            Given()
                .Spec(requestSpecification);
        }

        [Test]
        public void RequestAccountsForCustomer12212_CheckListOfAccountsIDs_ExpectContains12345()
        {
            /**
             * Send a GET request to /customer/12212/accounts
             * and check that the list of accounts returned
             * includes an account with ID 12345
             * 
             * Use the JsonPath expression "$.accounts[0:].id" to
             * extract the required response body elements
             */

            Given()
                .Spec(requestSpecification);
        }
    }
}
