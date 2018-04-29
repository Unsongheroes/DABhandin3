using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DAB33.Models
{
    public class TelefonNummer
    {
        [JsonProperty(PropertyName = "id")]
        public string Telefonnummer { get; set; }
        [JsonProperty(PropertyName = "telefonnummertype")]
        public string TelefonnummerType { get; set; }
        [JsonProperty(PropertyName = "telefonselskab")]
        public string TelefonSelskab { get; set; }

    }
}