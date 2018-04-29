using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DAB33.Models
{
    public class Addresse
    {
        [JsonProperty(PropertyName = "id")]
        public string AdresseId { get; set; }
        [JsonProperty(PropertyName = "vejnavn")]
        public string VejNavn { get; set; }
        [JsonProperty(PropertyName = "husnummer")]
        public int Husnummer { get; set; }
        [JsonProperty(PropertyName = "bypostnummer")]
        public ByPostNummer ByPostNummer { get; set; }
    }
}