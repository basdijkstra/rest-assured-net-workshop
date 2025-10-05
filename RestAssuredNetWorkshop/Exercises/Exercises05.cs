using NUnit.Framework;
using RestAssured.Logging;
using RestAssured.Request.Builders;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Exercises
{
    public class Exercises05 : TestBase
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

            Given()
                .Spec(this.requestSpecification);
        }

        [Test]
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

            
            Given()
                .Spec(this.requestSpecification);
        }
    }
}
