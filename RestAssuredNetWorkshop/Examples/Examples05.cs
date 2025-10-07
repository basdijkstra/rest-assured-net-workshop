using NUnit.Framework;
using RestAssuredNetWorkshop.Examples.Models;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Examples
{
    public class Examples05
    {
        [Test]
        public void SerializePostObjectToJson()
        {
            Post post = new Post
            {
                UserId = 1,
                Title = "My new blog post",
                Body = "This is an awesome piece of content"
            };

            Given()
                .Body(post)
                .When()
                .Post("https://jsonplaceholder.typicode.com/posts")
                .Then()
                .StatusCode(201);
        }

        [Test]
        public void SerializeAnonymousObjectToJson()
        {
            var post = new
            {
                userId = 1,
                title = "My new blog post",
                body = "This is an awesome piece of content"
            };

            Given()
                .Body(post)
                .When()
                .Post("https://jsonplaceholder.typicode.com/posts")
                .Then()
                .StatusCode(201);
        }

        [Test]
        public void DeserializeJsonToPost()
        {
            Post post = (Post)Given()
                .When()
                .Get("https://jsonplaceholder.typicode.com/posts/1")
                .DeserializeTo(typeof(Post));

            Assert.That(post.Title, Contains.Substring("sunt aut facere"));
        }

        [Test]
        public void DeserializeJsonToPostAfterVerification()
        {
            Post post = (Post)Given()
                .When()
                .Get("https://jsonplaceholder.typicode.com/posts/1")
                .Then()
                .StatusCode(200)
                .DeserializeTo(typeof(Post));

            Assert.That(post.Title, Contains.Substring("sunt aut facere"));
        }
    }
}
