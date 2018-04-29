using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DAB33.Models
{
    public class ByPostNummer
    {
        [JsonProperty(PropertyName = "id")]
        public string Postnummer { get; set; }
        [JsonProperty(PropertyName = "bynavn")]
        public string ByNavn { get; set; }
        [JsonProperty(PropertyName = "land")]
        public string Land { get; set; }
    }
}