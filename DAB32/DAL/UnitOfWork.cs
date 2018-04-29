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
        private readonly DAB32Context _context;

        public UnitOfWork(DAB32Context context)
        {
            _context = context;
            Persons = new PersonRepository(_context);
        }

        public void Dispose()
        {
            var itemsToDelete = Persons.GetAll();
            Persons.RemoveRange(itemsToDelete);

            var itemsToDelete2 = _context.ByPostNummers;
            _context.ByPostNummers.RemoveRange(itemsToDelete2);

            var itemsToDelete3 = _context.Adresses;
            _context.Adresses.RemoveRange(itemsToDelete3);
        }

        public IPersonRepository Persons { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}