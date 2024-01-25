using Newtonsoft.Json;

namespace RestAssuredNetWorkshop.Answers.Models
{
    public class Customer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("address")]
        public Address? Address { get; set; }
    }
}
