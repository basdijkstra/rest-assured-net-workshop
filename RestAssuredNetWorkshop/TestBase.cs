﻿using NUnit.Framework;
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
            AddCustomer12212Accounts();
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
    }
}
