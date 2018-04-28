using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB32.Models
{
  
        public class TelefonNummer
        {
            [Key]

            public int Telefonnummer { get; set; }

            public string TelefonnummerType { get; set; }
            public string TelefonSelskab { get; set; }

            public int PersonCpr { get; set; }
            public Person Person { get; set; }
        }
    
}