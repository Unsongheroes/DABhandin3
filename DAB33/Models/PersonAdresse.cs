using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAB32.Models;
using Newtonsoft.Json;

namespace DAB33.Models
{
    public class PersonAdresse
    {
        [JsonProperty(PropertyName = "id")]
        public string MatchId { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "adresse")]
        public Adresse Adresse { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
    }
}