using NUnit.Framework;
using RestAssured.Logging;
using static RestAssured.Dsl;

namespace RestAssuredNetWorkshop.Examples
{
    public class Examples01
    {
        [Test]
        public void GetUserData_VerifyName_ShouldBeLeanneGraham()
        {
            Given()
                .When()
                .Get("https://jsonplaceholder.typicode.com/users/1")
                .Then()
                .AssertThat()
                .Body("$.name", NHamcrest.Is.EqualTo("Leanne Graham"));
        }

        [Test]
        public void LogAllRequestAndResponseData()
        {
            var logConfiguration = new LogConfiguration
            {
                RequestLogLevel = RequestLogLevel.All,
                ResponseLogLevel = ResponseLogLevel.All,
            };

            Given()
                .Log(logConfiguration)
                .When()
                .Get("https://jsonplaceholder.typicode.com/users/1")
                .Then()
                .AssertThat()
                .Body("$.name", NHamcrest.Is.EqualTo("Leanne Graham"));
        }

        [Test]
        public void GetUserData_VerifyStatusCodeAndContentType()
        {
            Given()
                .When()
                .Get("https://jsonplaceholder.typicode.com/users/1")
                .Then()
                .AssertThat()
                .StatusCode(200)
                .And()
                .ContentType("application/json; charset=utf-8");
        }
    }
}
