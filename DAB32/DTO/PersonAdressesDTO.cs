using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAB32.Models;

namespace DAB32.DTO
{
    public class PersonAdressesDTO
    {
        public PersonAdressesDTO()
        {

        }

        public PersonAdressesDTO(PersonAdresse pr)
        {
            MatchId = pr.MatchId;
            Type = pr.Type;
            PersonCpr = pr.PersonCpr;
            AdresseId = pr.AdresseId;
        }

        public PersonAdresse ToPersonAdresses()
        {
            return new PersonAdresse()
            {
                MatchId = MatchId,
                AdresseId = AdresseId,
                Type = Type,
                PersonCpr = PersonCpr
            };
        }


        public int MatchId { get; set; }

        public string Type { get; set; }

        public int PersonCpr { get; set; }
        public int AdresseId { get; set; }
    }
}