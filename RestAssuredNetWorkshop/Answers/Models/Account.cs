using Newtonsoft.Json;

namespace RestAssuredNetWorkshop.Answers.Models
{
    internal class Account
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("balance")]
        public int Balance { get; set; } = 0;
    }
}
