﻿using System;
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

        public DAB32Context PersonContext => Context as DAB32Context;
    }
}