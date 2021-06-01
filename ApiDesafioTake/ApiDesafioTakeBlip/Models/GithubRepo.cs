using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiDesafioTakeBlip.Models
{
    public class GithubRepo
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("description")]
        public String Description { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime Created_At { get; set; }

    }
}
