using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB32.Models
{
 

        public class Adresse
        {
            [Key]
            public int AdresseId { get; set; }

            public string VejNavn { get; set; }
            public int Husnummer { get; set; }

            public List<PersonAdresse> PersonAdresses { get; set; }

            public ByPostNummer ByPostNummer { get; set; }

            public Adresse()
            {
                PersonAdresses = new List<PersonAdresse>();
            }

        }

    
}