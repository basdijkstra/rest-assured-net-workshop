using NUnit.Framework;
using RestAssuredNetWorkshop.Exercises.Clients;
using RestAssuredNetWorkshop.Answers.Models;
using System.Net;

namespace RestAssuredNetWorkshop.Exercises
{
    public class Exercises06 : TestBase
    {
        private readonly AccountClient accountClient = new AccountClient();

        [Test]
        public void ApplyClientTestModel_ReturnVerifiableResponse_CheckStatusCodeAndResponseHeader()
        {
            /**
             * Implement this test to make it:
             * - call the GetAccount() method from the accountClient to return details for account 12345
             * - Verify (using a RestAssured.Net method) that the response status code is HTTP 200
             * - Verify (using a RestAssured.Net method) that the response content type is "application/json"
             */

        }

        [Test]
        public void ApplyClientTestModel_ReturnHttpResponseMessage_CheckStatusCodeAndResponseHeader()
        {
            Account account = new Account
            {
                Id = 12345,
                Type = "savings"
            };

            /**
             * Implement this test to make it:
             * - call the CreateAccount() method from the accountClient to create the specified accout
             * - Verify (using an NUnit assertion) that the response status code is HTTP 201 (HttpStatusCode.Created)
             * - Verify (using an NUnit assertion) that the response content type is "application/json"
             */

        }
    }
}
