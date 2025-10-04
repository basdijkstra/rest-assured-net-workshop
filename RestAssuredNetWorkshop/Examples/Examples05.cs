using NUnit.Framework;
using RestAssured.Logging;
using RestAssured.Request.Builders;

using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Examples
{
    public class Examples05
    {
        private readonly string hardcodedGraphQLQuery =
            @"query GetCountryData {
                country(code: ""NL"") {
                    name
                    capital
                    currency
                    languages {
                        code
                        name
                    }
                }
            }";

        private readonly string parameterizedGraphQLQuery =
            @"query GetCountryData($country: ID!) {
                country(code: $country) {
                    name
                    capital
                    currency
                    languages {
                        code
                        name
                    }
                }
            }";

        [Test]
        public void UseHardCodedValuesInQuery_CheckTheCapital()
        {
            GraphQLRequest request = new GraphQLRequestBuilder()
                .WithQuery(this.hardcodedGraphQLQuery)
                .WithOperationName("GetCountryData")
                .Build();
            
            Given()
                .GraphQL(request)
                .When()
                .Post("https://countries.trevorblades.com/graphql")
                .Then()
                .StatusCode(200)
                .Body("$.data.country.capital", NHamcrest.Is.EqualTo("Amsterdam"));
        }

        [TestCase("NL", "Amsterdam", TestName = "The capital of NL is Amsterdam")]
        [TestCase("IT", "Rome", TestName = "The capital of IT is Rome")]
        [TestCase("CA", "Ottawa", TestName = "The capital of CA is Ottawa")]
        public void UseParametersInQuery_CheckTheCapital(string countryCode, string expectedCapital)
        {
            Dictionary<string, object> variables = new Dictionary<string, object>
            {
                { "country", countryCode },
            };

            GraphQLRequest request = new GraphQLRequestBuilder()
                .WithQuery(this.parameterizedGraphQLQuery)
                .WithOperationName("GetCountryData")
                .WithVariables(variables)
                .Build();

            var logConfiguration = new LogConfiguration
            {
                RequestLogLevel = RequestLogLevel.All,
            };

            Given()
                .Log(logConfiguration)
                .GraphQL(request)
                .When()
                .Post("https://countries.trevorblades.com/graphql")
                .Then()
                .StatusCode(200)
                .Body("$.data.country.capital", NHamcrest.Is.EqualTo(expectedCapital));
        }
    }
}
