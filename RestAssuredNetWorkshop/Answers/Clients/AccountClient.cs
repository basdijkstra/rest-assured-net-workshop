using RestAssured.Response;
using RestAssuredNetWorkshop.Answers.Models;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Answers.Clients
{
    public class AccountClient : ClientBase
    {
        private static readonly string BaseUri = "http://localhost";
        private static readonly int Port = 9876;

        public AccountClient() : base(BaseUri, Port)
        {
        }

        public VerifiableResponse GetAccount(int accountId)
        {
            /**
             * Implement this method to make it:
             * - Use the RequestSpecification from the ClientBase
             * - Get the account with the specified accountId from "/accounts/<accountId>"
             * - Return the VerifiableResponse
             */

            return Given()
                .Spec(base.GetRequestSpec())
                .When()
                .Get($"/accounts/{accountId}");
        }

        public HttpResponseMessage CreateAccount(Account account)
        {
            /**
             * Implement this method to make it:
             * - Use the RequestSpecification from the ClientBase
             * - Post the given account to "/accounts"
             * - Extract and return the HttpResponseMessage
             */

            return Given()
                .Spec(base.GetRequestSpec())
                .Body(account)
                .When()
                .Post("/accounts")
                .Then()
                .Extract().Response();
        }
    }
}
