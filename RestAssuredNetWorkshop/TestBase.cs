using NUnit.Framework;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace RestAssuredNetWorkshop
{
    public class TestBase
    {
        protected WireMockServer? Server { get; private set; }

        [SetUp]
        protected void StartServer()
        {
            Server = WireMockServer.Start(9876);

            AddCustomer12212();
            AddCustomer12323();
            AddCustomer14545();
            AddCustomer12212Accounts();
            AddToken();
            AddCustomer12212Secure();
            AddPostAccount();
        }

        [TearDown]
        protected void StopServer()
        {
            Server?.Stop();
        }

        private void AddCustomer12212()
        {
            var customer = new
            {
                id = 12212,
                firstName = "John",
                lastName = "Smith",
                address = new
                {
                    street = "Main Street",
                    number = 123,
                    city = "Beverly Hills"
                }
            };

            this.Server?.Given(Request.Create().WithPath("/customer/12212").UsingGet())
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(customer));
        }

        private void AddCustomer12323()
        {
            var customer = new
            {
                id = 12323,
                firstName = "Susan",
                lastName = "Holmes",
                address = new
                {
                    street = "Long Street",
                    number = 4,
                    city = "Beverly Hills"
                }
            };

            this.Server?.Given(Request.Create().WithPath("/customer/12323").UsingGet())
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(customer));
        }

        private void AddCustomer14545()
        {
            var customer = new
            {
                id = 14545,
                firstName = "Anna",
                lastName = "Grant",
                address = new
                {
                    street = "Sunny Avenue",
                    number = 987,
                    city = "Beverly Hills"
                }
            };

            this.Server?.Given(Request.Create().WithPath("/customer/14545").UsingGet())
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(customer));
        }

        private void AddCustomer12212Accounts()
        {
            var accounts = new
            {
                customerId = 12212,
                accounts = new[]
                {
                    new
                    {
                        id = 12345,
                        balance = 100
                    },
                    new
                    {
                        id = 54321,
                        balance = 250
                    },
                    new
                    {
                        id = 23456,
                        balance = 50
                    }
                }
            };

            this.Server?.Given(Request.Create().WithPath("/customer/12212/accounts").UsingGet())
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(accounts));
        }

        private void AddToken()
        {
            var response = new
            {
                token = "c4515429-0c2e-4520-894c-fbd5e8ae5874"
            };

            this.Server?.Given(Request.Create().WithPath("/token").UsingGet()
                .WithHeader("Authorization", new ExactMatcher("Basic am9objpkZW1v")))
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));
        }

        private void AddCustomer12212Secure()
        {
            var customer = new
            {
                id = 12212,
                firstName = "John",
                lastName = "Smith",
                address = new
                {
                    street = "Main Street",
                    number = 123,
                    city = "Beverly Hills"
                }
            };

            this.Server?.Given(Request.Create().WithPath("/secure/customer/12212").UsingGet()
                .WithHeader("Authorization", new ExactMatcher("Bearer c4515429-0c2e-4520-894c-fbd5e8ae5874")))
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(customer));
        }

        private void AddPostAccount()
        {
            string expectedBody = "{\"id\":12345,\"type\":\"savings\",\"balance\":0}";

            this.Server?.Given(Request.Create().WithPath("/accounts").UsingPost()
                .WithBody(new JsonMatcher(expectedBody)))
                .RespondWith(Response.Create()
                .WithStatusCode(201));
        }
    }
}
