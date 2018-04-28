using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB32.Models
{
    public class PersonAdresse
    {
        [Key]
        public int MatchId { get; set; }

        public string Type { get; set; }

        public int PersonCpr { get; set; }
        public Person Person { get; set; }

        public int AdresseId { get; set; }
        public Adresse Adresse { get; set; }


    }
}