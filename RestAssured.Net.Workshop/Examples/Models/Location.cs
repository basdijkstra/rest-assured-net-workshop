namespace RestAssured.Net.Workshop.Examples.Models
{
    using System.Collections.Generic;

    public class Location
    {
        public string? Country { get; set; }

        public string? State { get; set; }

        public int ZipCode { get; set; }

        public List<Place>? Places { get; set; }
    }
}
