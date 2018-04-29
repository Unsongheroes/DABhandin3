using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using DAB32.Models;

namespace DAB32.DAL
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DAB32Context context) : base(context)
        {
        }

        public IEnumerable<Person> GetPersonsByLastName(int amountofPersons)
        {
            return PersonContext.People.OrderBy(c => c.EfterNavn).Take(amountofPersons).ToList();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            var query = PersonContext.People.Include(pa => pa.PersonAdresses).Include(pa => pa.TelefonBog);
            return query.ToList();
        }

        public Person GetPerson(int id)
        {
            return PersonContext.People.Include(p => p.PersonAdresses).Include(p => p.TelefonBog).First(p => p.Cpr.Equals(id));
        }

        public IEnumerable<Adresse> GetAllAdresses()
        {
            var query = PersonContext.Adresses.Include(pa => pa.PersonAdresses).Include(b => b.ByPostNummer);
            return query.ToList();
        }

        public IEnumerable<TelefonNummer> GetAllTelefonNummers()
        {
            var query = PersonContext.TelefonNummers.Include(p => p.Person);
            return query.ToList();
        }


        public DAB32Context PersonContext => Context as DAB32Context;
    }
}