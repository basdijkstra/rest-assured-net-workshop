using Newtonsoft.Json;

namespace RestAssuredNetWorkshop.Examples.Models
{
    internal class Post
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("body")]
        public string Body { get; set; } = string.Empty;
    }
}
