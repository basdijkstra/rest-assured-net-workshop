using NUnit.Framework;
using RestAssured.Logging;
using RestAssured.Request.Builders;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Answers
{
    public class Answers06 : TestBase
    {
        private RequestSpecification requestSpecification;

        [SetUp]
        public void CreateRequestSpecification()
        {
            requestSpecification = new RequestSpecBuilder()
                .WithBaseUri("http://localhost")
                .WithPort(9876)
                .Build();
        }

        [Test]
        public void GetFruitData_CheckFruitAndTreeName_ShouldBeAppleAndMalus()
        {
            /**
             * Create a new payload for a GraphQL query using a
             * the specified query (with hardcoded ID) and
             * with operation name GetFruit
             *
             * POST this object to /graphql
             *
             * Assert that the name of the fruit is equal to "Apple"
             * Use "$.data.fruit.fruit_name" as the JsonPath
             * expression to extract the required value from the response
             *
             * Also, assert that the tree name is equal to "Malus"
             * Use "$.data.fruit.tree_name" as the JsonPath
             * expression to extract the required value from the response
             */

            var queryString = @"query GetFruit {
                    fruit(id: 1) {
                        id
                        fruit_name
                        tree_name
                    }
                }";

            GraphQLRequest request = new GraphQLRequestBuilder()
                .WithQuery(queryString)
                .WithOperationName("GetFruit")
                .Build();

            var logConfig = new LogConfiguration
            {
                RequestLogLevel = RequestLogLevel.All
            };

            Given()
                .Spec(this.requestSpecification)
                .Log(logConfig)
                .GraphQL(request)
                .When()
                .Post("/graphql")
                .Then()
                .StatusCode(200)
                .Body("$.data.fruit.fruit_name", NHamcrest.Is.EqualTo("Apple"))
                .Body("$.data.fruit.tree_name", NHamcrest.Is.EqualTo("Malus"));
        }

        [TestCase(1, "Apple", "Malus", TestName = "Fruit 1 is Apple (Malus)")]
        [TestCase(2, "Pear", "Pyrus", TestName = "Fruit 2 is Pear (Pyrus)")]
        [TestCase(3, "Banana", "Musa", TestName = "Fruit 3 is Banana (Musa)")]
        public void GetFruitData_CheckFruitAndTreeName_ShouldBeAsExpected
            (int id, string expectedFruitName, string expectedTreeName)
        {
            /**
             * Transform this Test into a parameterized test, with
             * three [TestCase] attributes using the following test data:
             * 
             * ---------------------------------
             * fruit id | fruit name | tree name
             * ---------------------------------
             *        1 |      Apple |     Malus
             *        2 |       Pear |     Pyrus
             *        3 |     Banana |      Musa
             *
             * Create a new GraphQL query from the given query string
             * and "GetFruit" as the operation name
             * 
             * Pass in the fruit id as a value to variable 'id'
             *
             * POST this object to /graphql
             *
             * Assert that the HTTP response status code is 200
             *
             * Assert that the name of the fruit is equal to the value in the data source
             * Use "$.data.fruit.fruit_name" as the JsonPath
             * expression to extract the required value from the response
             *
             * Also, assert that the tree name is equal to the value in the data source
             * Use "$.data.fruit.tree_name" as the JsonPath
             * expression to extract the required value from the response
             ******************************************************/

            var queryString = @"query GetFruit($id: ID!)
                {
                    fruit(id: $id) {
                        id
                        fruit_name
                        tree_name
                    }
                }";

            var variables = new Dictionary<string, object>
            {
                { "id", id },
            };

            GraphQLRequest request = new GraphQLRequestBuilder()
                .WithQuery(queryString)
                .WithOperationName("GetFruit")
                .WithVariables(variables)
                .Build();

            var logConfig = new LogConfiguration
            {
                RequestLogLevel = RequestLogLevel.All
            };

            Given()
                .Spec(this.requestSpecification)
                .Log(logConfig)
                .GraphQL(request)
                .When()
                .Post("/graphql")
                .Then()
                .StatusCode(200)
                .Body("$.data.fruit.fruit_name", NHamcrest.Is.EqualTo(expectedFruitName))
                .Body("$.data.fruit.tree_name", NHamcrest.Is.EqualTo(expectedTreeName));
        }
    }
}
