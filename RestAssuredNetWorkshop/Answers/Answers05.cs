using NUnit.Framework;
using RestAssured.Logging;
using RestAssured.Request.Builders;
using RestAssuredNetWorkshop.Answers.Models;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Answers
{
    public class Answers05 : TestBase
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
        public void SerializeAccountToJson_CheckStatusCode_ShouldBeHttp201()
        {
            /**
             * Create a new Account object with 12345 as the id and 'savings'
             * as the account type (you can leave the balance property out as
             * that should be assigned its default value of 0)
             * 
             * POST this object to /accounts
             * 
             * Verify that the response HTTP status code is equal to 201
             */

            Account account = new Account
            {
                Id = 12345,
                Type = "savings"
            };

            Given()
                .Spec(requestSpecification)
                .Body(account)
                .When()
                .Post("/accounts")
                .Then()
                .StatusCode(201);
        }

        [Test]
        public void SerializeAnonymousObjectToJson_CheckStatusCode_ShouldBeHttp201()
        {
            /**
             * Create a new anonymous object with the following properties:
             * - 'id' with value 12345 (int)
             * - 'type' with value 'savings' (string)
             * - 'balance' with value 0 (int)
             * 
             * POST this object to /accounts
             * 
             * Verify that the response HTTP status code is equal to 201
             */

            var account = new
            {
                id = 12345,
                type = "savings",
                balance = 0
            };

            Given()
                .Spec(requestSpecification)
                .Body(account)
                .When()
                .Post("/accounts")
                .Then()
                .StatusCode(201);
        }

        [Test]
        public void DeserializeCustomer12212Response_CheckLastNameAndStreetName()
        {
            /**
             * Perform an HTTP GET to /customer/12212 and deserialize the JSON
             * response body to an object of type Customer, but only after checking
             * that the response status is equal to HTTP 200
             * 
             * Use NUnit Assert.That() assertions to check that:
             * - the value of the LastName property is equal to 'Smith'
             * - the value of the Street property (of the Address) is equal to 'Main Street'
             * 
             * You don't need to create or modify the Customer or the Address object,
             * that has been done for you already. By all means do have a look at them, though
             */

            Customer customer = (Customer)Given()
                .Spec(requestSpecification)
                .When()
                .Get("/customer/12212")
                .Then()
                .StatusCode(200)
                .DeserializeTo(typeof(Customer));

            Assert.That(customer.LastName, Is.EqualTo("Smith"));
            Assert.That(customer.Address.Street, Is.EqualTo("Main Street"));
        }

        [Test]
        public void PostCustomerObject_CheckReturnedFirstAndLastName_ExpectSuppliedValues()
        {
            /**
             * Create a new Customer object with a first name and a
             * last name of your own choosing (the other fields will be ignored)
             *
             * POST this object to /customers
             *
             * Deserialize the response into another object of type
             * Customer and use NUnit Assert.That() assertions to
             * check that the first name and last name returned by
             * the API are the same as those you set in the request
             * when you POSTed the Customer object
             */

            var customer = new Customer
            {
                FirstName = "Anna",
                LastName = "Grant"
            };

            var logConfig = new LogConfiguration
            {
                RequestLogLevel = RequestLogLevel.All,
                ResponseLogLevel = ResponseLogLevel.All
            };

            var returnedCustomer = (Customer)Given()
                .Spec(requestSpecification)
                .Log(logConfig)
                .Body(customer)
                .When()
                .Post("/customers")
                .Then()
                .StatusCode(201)
                .DeserializeTo(typeof(Customer));

            Assert.That(returnedCustomer.FirstName, Is.EqualTo("Anna"));
            Assert.That(returnedCustomer.LastName, Is.EqualTo("Grant"));
        }
    }
}
