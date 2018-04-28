using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB32.Models
{
        public class ByPostNummer
        {
            [Key]
            public int Postnummer { get; set; }

            public string ByNavn { get; set; }
            public string Land { get; set; }


        }

}