using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using System.Web;
using DAB33.Models;

namespace DAB33.DAL
{
    public class UnitOfWork<T> where T : Person
    {
        private readonly List<T> _changed = new List<T>();
        private readonly List<T> _new = new List<T>();
        private readonly List<T> _deleted = new List<T>();

        public void Add(T item)
        {
            _new.Add(item);
        }

        public void Update(T item)
        {
            _changed.Add(item);
        }

        public void Delete(T item)
        {
            _deleted.Add(item);
        }

        public void Commit()
        {
            Repository<Person>.CreateDatabase().Wait();
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (T item in _changed)
                {
                    Repository<T>.UpdateDocumentAsync(item.Cpr, item).Wait();
                }

                foreach (T item in _new)
                {
                    Repository<T>.CreateDocumentAsync(item).Wait();
                }

                foreach (T item in _deleted)
                {
                    Repository<T>.DeleteDocumentAsync(item.Cpr).Wait();
                }
            }
        }

        public Person FindPersonById(string id)
        {
            var read = Repository<Person>.GetDocumentAsync(id).Result;
            return read;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            
            var read = Repository<Person>.GetAllDocuments().Result;
            return read;
        }

    }
}