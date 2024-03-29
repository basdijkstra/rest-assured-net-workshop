﻿using NUnit.Framework;
using RestAssured.Request.Builders;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Examples
{
    public class Examples03
    {
        [Test]
        public void UseBasicAuthentication()
        {
            Given()
                .BasicAuth("username", "password")
                .When()
                .Get("https://my.secure/api")
                .Then()
                .StatusCode(200);
        }

        [Test]
        public void UseOAuth2Authentication()
        {
            Given()
                .OAuth2("my_authentication_token")
                .When()
                .Get("https://my.very.secure/api")
                .Then()
                .StatusCode(200);
        }

        [Test]
        public void CaptureAndReuseUniqueId()
        {
            string userId = (string)Given()
                .When()
                .Post("https://my.user.api/user")
                .Then()
                .Extract()
                .Body("$.id");

            Given()
                .PathParam("userId", userId)
                .When()
                .Get("https://my.user.api/user/[userId]")
                .Then()
                .StatusCode(200);
        }

        private RequestSpecification? requestSpec;

        [SetUp]
        public void CreateRequestSpecification()
        {
            requestSpec = new RequestSpecBuilder()
                .WithBaseUri("https://jsonplaceholder.typicode.com")
                .WithContentType("application/json")
                .WithOAuth2("my_authentication_token")
                .Build();
        }

        [Test]
        public void UseRequestSpecification()
        {
            Given()
                .Spec(requestSpec)
                .When()
                .Get("/users/1")
                .Then()
                .StatusCode(200);
        }
    }
}
