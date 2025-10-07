using NUnit.Framework;
using RestAssuredNetWorkshop.Examples.Clients;
using RestAssuredNetWorkshop.Examples.Models;
using System.Net;

namespace RestAssuredNetWorkshop.Examples
{
    public class Examples07 : TestBase
    {
        private readonly PostClient postClient = new PostClient();

        [Test]
        public void ApplyClientTestModel_ReturnVerifiableResponse_CheckStatusCodeAndResponseHeader()
        {
            postClient.GetPost(1)
                .Then()
                .StatusCode(200)
                .ContentType(NHamcrest.Contains.String("application/json"));
        }

        [Test]
        public void ApplyClientTestModel_ReturnHttpResponseMessage_CheckStatusCodeAndResponseHeader()
        {
            Post post = new Post
            {
                UserId = 1,
                Title = "My new blog post",
                Body = "This is the body of my brand new blog post."
            };

            var response = postClient.CreatePost(post);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            response.Content.Headers.TryGetValues("Content-Type", out IEnumerable<string>? values);
            Assert.That(values!.First(), Does.Contain("application/json"));
        }
    }
}
