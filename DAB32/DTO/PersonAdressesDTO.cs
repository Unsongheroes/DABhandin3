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
            Person = new PersonDTO(pr.Person);
            AdresseId = AdresseId;
            Adresse = new AddressDTO(pr.Adresse);
        }

        public PersonAdresse ToPersonAdresses()
        {
            return new PersonAdresse()
            {
                MatchId = MatchId,
                Adresse = Adresse.ToAdresse(),
                AdresseId = AdresseId,
                Type = Type,
                Person = Person.ToPerson(),
                PersonCpr = PersonCpr
            };
        }


        public int MatchId { get; set; }

        public string Type { get; set; }

        public int PersonCpr { get; set; }
        public PersonDTO Person { get; set; }

        public int AdresseId { get; set; }
        public AddressDTO Adresse { get; set; }
    }
}