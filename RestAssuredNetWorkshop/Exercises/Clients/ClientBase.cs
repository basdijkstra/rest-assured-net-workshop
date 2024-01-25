using RestAssured.Request.Builders;

namespace RestAssuredNetWorkshop.Exercises.Clients
{
    public abstract class ClientBase
    {
        private string baseUri;
        private int port;

        protected ClientBase(string baseUri, int port)
        {
            this.baseUri = baseUri;
            this.port = port;
        }

        public RequestSpecification GetRequestSpec()
        {
            return new RequestSpecBuilder()
                .WithBaseUri(baseUri)
                .WithPort(port)
                .WithContentType("application/json")
                .Build();
        }
    }
}
