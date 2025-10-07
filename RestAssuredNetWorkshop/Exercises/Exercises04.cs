using NUnit.Framework;
using RestAssured.Request.Builders;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Exercises
{
    public class Exercises04 : TestBase
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
        public void GetAccountsForCustomer12212AsXml_CheckIdOfFirstAccount_ShouldBe12345()
        {
            /**
             * Perform a GET request to /xml/customer/12212/accounts
             * to get the list of accounts associated with customer
             * 12212 in XML format
             *
             * Assert that the ID of the first account equals 12345
             *
             * Use "//account[1]/id" as the XPath expression to
             * extract the required value from the response
             */

            Given()
                .Spec(requestSpecification);
        }

        [Test]
        public void GetAccountsForCustomer12212AsXml_CheckBalanceOfThirdAccount_ShouldBe4321()
        {
            /**
             * Perform a GET request to /xml/customer/12212/accounts
             * to get the list of accounts associated with customer
             * 12212 in XML format
             *
             * Assert that the balance for the third account in the
             * list is equal to 43.21
             * 
             * What do you notice about comparing numerical values?
             * How would you address this in this exercise?
             *
             * Can you create the correct XPath expression yourself,
             * using the examples as shown in the slides?
             */

            Given()
                .Spec(requestSpecification);
        }

        [Test]
        public void GetSavingsAccountForCustomer12212AsXml_CheckIdAndBalance_ShouldBe98765and10123()
        {
            /**
             * Perform a GET request to /xml/customer/12212/accounts
             * to get the list of accounts associated with customer
             * 12212 in XML format
             *
             * Assert that the ID of the (only) savings account
             * in the list is equal to 98765, and that its balance
             * is equal to 10123.00
             * 
             * Every account has a 'type' attribute with a value
             * equal to 'checking' or 'savings' (see for yourself by
             * logging the response details to the console)
             * 
             * Can you create the correct XPath expressions yourself,
             * using the examples as shown in the slides?
             */

            Given()
                .Spec(requestSpecification);
        }
    }
}
