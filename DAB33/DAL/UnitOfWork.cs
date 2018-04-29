using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using DAB33.Models;

namespace DAB33.DAL
{
    public class UnitOfWork<T> where T : Person
    {
        private readonly List<T> _changed = new List<T>();
        private readonly List<T> _new = new List<T>();
        private readonly List<int> _deleted = new List<int>();

        public void Add(T item)
        {
            _new.Add(item);
        }

        public void Update(T item)
        {
            _changed.Add(item);
        }

        public void Delete(int id)
        {
            _deleted.Add(id);
        }

        public async Task Commit()
        {
            foreach (T item in _changed)
            {
                    await Repository<T>.UpdateDocumentAsync(item.Cpr, item);
            }

            foreach (T item in _new)
            {
                await Repository<T>.CreateDocumentAsync(item);
            }

            foreach (int id in _deleted)
            {
                await Repository<T>.DeleteDocumentAsync(id.ToString());
            }             
        }

        public async Task<Person> FindPersonById(string id)
        {
            return await Repository<Person>.GetDocumentAsync(id); 
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await Repository<Person>.GetDocumentsAsync();
        }

    }
}