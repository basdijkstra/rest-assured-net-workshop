using RestAssured.Response;
using RestAssuredNetWorkshop.Examples.Models;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Examples.Clients
{
    public class PostClient : ClientBase
    {
        private static readonly string BaseUri = "https://jsonplaceholder.typicode.com";

        public PostClient() : base(BaseUri)
        {
        }

        public VerifiableResponse GetPost(int postId)
        {
            return Given()
                .Spec(base.GetRequestSpec())
                .When()
                .Get($"/posts/{postId}");
        }

        public HttpResponseMessage CreatePost(Post post)
        {
            return Given()
                .Spec(base.GetRequestSpec())
                .Body(post)
                .When()
                .Post("/posts")
                .Then()
                .StatusCode(201)
                .Extract().Response();
        }
    }
}
