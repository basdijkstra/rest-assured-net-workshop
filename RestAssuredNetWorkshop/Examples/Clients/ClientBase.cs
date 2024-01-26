using RestAssured.Request.Builders;

namespace RestAssuredNetWorkshop.Examples.Clients
{
    public abstract class ClientBase
    {
        private string baseUri;

        protected ClientBase(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public RequestSpecification GetRequestSpec()
        {
            return new RequestSpecBuilder()
                .WithBaseUri(baseUri)
                .WithContentType("application/json")
                .Build();
        }
    }
}
