using NUnit.Framework;

using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Examples
{
    public class Examples04
    {
        [Test]
        public void GetAccount12345_CheckType_ShouldBeChecking()
        {
            Given()
                .When()
                .Get("https://parabank.parasoft.com/parabank/services/bank/accounts/12345")
                .Then()
                .StatusCode(200)
                .Body("//type", NHamcrest.Is.EqualTo("CHECKING"));
        }

        [Test]
        public void GetAccountsForCustomer12212_CheckSavingsAccounts_ShouldContain12678()
        {
            Given()
                .When()
                .Get("https://parabank.parasoft.com/parabank/services/bank/customers/12212/accounts")
                .Then()
                .StatusCode(200)
                .Body(
                    "//account/type[text()='SAVINGS']/parent::account/id",
                    NHamcrest.Has.Item(NHamcrest.Is.EqualTo(12678))
                );
        }
    }
}
