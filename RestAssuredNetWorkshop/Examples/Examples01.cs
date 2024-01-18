using NUnit.Framework;
using RestAssured.Request.Logging;
using RestAssured.Response.Logging;
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
        public void LogAllRequestData()
        {
            Given()
                .Log(RequestLogLevel.All)
                .When()
                .Get("https://jsonplaceholder.typicode.com/users/1")
                .Then()
                .AssertThat()
                .Body("$.name", NHamcrest.Is.EqualTo("Leanne Graham"));
        }

        [Test]
        public void LogAllResponseData()
        {
            Given()
                .When()
                .Get("https://jsonplaceholder.typicode.com/users/1")
                .Then()
                .Log(ResponseLogLevel.All)
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
                .ContentType("application/json; charset=utf-8");
        }
    }
}
