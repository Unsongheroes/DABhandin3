using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB32.Models
{

    //datakravene opfyldes muligvis ikke da, der ingen mulige foreign keyes er i nogle af modellerne. 
        public class Person
        {
            [Key]
            public int Cpr { get; set; }

            public string Fornavn { get; set; }
            public string MellemNavn { get; set; }
            public string EfterNavn { get; set; }
            public string PersonType { get; set; }
            public string Email { get; set; }

            public List<TelefonNummer> TelefonBog { get; set; }

            public List<PersonAdresse> PersonAdresses { get; set; }

            public Person()
            {
                TelefonBog = new List<TelefonNummer>();
                PersonAdresses = new List<PersonAdresse>();
            }
        }






    
}