﻿using System.Collections.Generic;
using DAB32.Models;

namespace DAB32
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPersonsByLastName(int amountofPersons);
    }
}