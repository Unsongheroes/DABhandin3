using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAB32.Models;

namespace DAB32.DTO
{
    public class PhoneNumberDTO
    {
        public PhoneNumberDTO()
        {

        }

        public PhoneNumberDTO(TelefonNummer nr)
        {
            Telefonnummer = nr.Telefonnummer;
            TelefonnummerType = nr.TelefonnummerType;
            TelefonSelskab = nr.TelefonSelskab;
            PersonD = new PersonDTO(nr.Person);
            PersonCpr = nr.Person.Cpr;
        }

        public TelefonNummer ToNummer()
        {
            return new TelefonNummer()
            {
                Telefonnummer = Telefonnummer,
                TelefonnummerType = TelefonnummerType,
                TelefonSelskab = TelefonSelskab,
                Person = PersonD.ToPerson(),
                PersonCpr = PersonD.PersonId
            };
        }

        public int Telefonnummer { get; set; }

        public string TelefonnummerType { get; set; }
        public string TelefonSelskab { get; set; }

        public int PersonCpr { get; set; }
        public PersonDTO PersonD { get; set; }
    }
}