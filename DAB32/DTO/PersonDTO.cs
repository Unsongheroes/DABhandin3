using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAB32.Models;

namespace DAB32.DTO
{
    public class PersonDTO
    {
        public PersonDTO()
        { }

        public PersonDTO(Person person)
        {
            PersonId = person.Cpr;

            FirstName = person.Fornavn;

            MiddleName = person.MellemNavn;

            LastName = person.EfterNavn;

            Email = person.Email;

            PersonAddresses = new List<PersonAdressesDTO>();

            PhoneNumbers = new List<PhoneNumberDTO>();

            foreach (PersonAdresse pa in person.PersonAdresses)
            {
                PersonAddresses.Add(new PersonAdressesDTO(pa));
            }

            foreach (TelefonNummer pn in person.TelefonBog)
            {
                PhoneNumbers.Add(new PhoneNumberDTO(pn));
            }
        }

        public Person ToPerson()
        {
            return new Person() { Cpr = PersonId, Fornavn = FirstName, MellemNavn = MiddleName, EfterNavn = LastName, Email = Email, PersonAdresses = PersonAddresses.Select(pa => pa.ToPersonAdresses()).ToList(), TelefonBog = PhoneNumbers.Select(pn => pn.ToNummer()).ToList() };
        }

        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<PersonAdressesDTO> PersonAddresses { get; set; }

        public List<PhoneNumberDTO> PhoneNumbers { get; set; }
    }
}