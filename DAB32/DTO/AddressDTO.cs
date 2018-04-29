using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAB32.Migrations;
using DAB32.Models;

namespace DAB32.DTO
{
    public class AddressDTO
    {

        public AddressDTO()
        {
            PersonAdresses = new List<PersonAdressesDTO>();
        }

        public AddressDTO(Adresse address)
        {
            PersonAdresses = new List<PersonAdressesDTO>();
            AdresseId = address.AdresseId;
            VejNavn = address.VejNavn;
            Husnummer = address.Husnummer;
          
            ByPostNummer = address.ByPostNummer;

            foreach (var item in address.PersonAdresses)
            {
                PersonAdresses.Add(new PersonAdressesDTO(item));
            }
        }

        public Adresse ToAdresse()
        {
            return new Adresse()
            {
                AdresseId = AdresseId,
                Husnummer = Husnummer,
                PersonAdresses = PersonAdresses.Select(pa => pa.ToPersonAdresses()).ToList(),
                VejNavn = VejNavn,

            };
        }

        public int AdresseId { get; set; }

        public string VejNavn { get; set; }
        public int Husnummer { get; set; }



        public List<PersonAdressesDTO> PersonAdresses { get; set; }
        
        public ByPostNummer ByPostNummer { get; set; }
    }
}