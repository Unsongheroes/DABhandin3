using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace DAB33.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Cpr { get; set; }
        [JsonProperty(PropertyName = "fornavn")]
        public string Fornavn { get; set; }
        [JsonProperty(PropertyName = "mellemnavn")]
        public string MellemNavn { get; set; }
        [JsonProperty(PropertyName = "efternavn")]
        public string EfterNavn { get; set; }
        [JsonProperty(PropertyName = "persontype")]
        public string PersonType { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "telefonbog")]
        public List<TelefonNummer> TelefonBog { get; set; }
        [JsonProperty(PropertyName = "personadresser")]
        public List<PersonAdresse> PersonAdresses { get; set; }

        /*
         * uvidst om der skal være en constructor - dette spørgsmål gælder for alle classerne i denne fil.
         */

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}