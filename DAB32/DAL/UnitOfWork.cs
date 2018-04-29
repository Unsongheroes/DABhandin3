using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DAB32.Models;

namespace DAB32.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DAB32Context _context = new DAB32Context();
        private IPersonRepository _personRepository;
        
        
        public void Dispose()
        {
            var itemsToDelete = PersonRepository.GetAllPersons();
            PersonRepository.RemoveRange(itemsToDelete);

            var itemsToDelete2 = _context.ByPostNummers;
            _context.ByPostNummers.RemoveRange(itemsToDelete2);

            var itemsToDelete3 = _context.Adresses;
            _context.Adresses.RemoveRange(itemsToDelete3);
        }

        public IPersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new PersonRepository(_context);
                }

                return _personRepository;
            }
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}