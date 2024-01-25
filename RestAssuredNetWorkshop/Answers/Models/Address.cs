using Newtonsoft.Json;

namespace RestAssuredNetWorkshop.Answers.Models
{
    public class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; } = string.Empty;

        [JsonProperty("number")]
        public int Number {  get; set; }

        [JsonProperty("city")]
        public string City { get; set; } = string.Empty;
    }
}
