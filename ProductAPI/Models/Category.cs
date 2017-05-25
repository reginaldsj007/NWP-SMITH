using Newtonsoft.Json;
using System;

namespace CategoryAPI
{
    public class Category 
    {
        [JsonProperty("id")]
        public int CategoryID { get; set; }
        [JsonProperty("name")]
        public string CategoryName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
