using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using DAB33.DAL;
using DAB33.Models;

namespace DAB33.Controllers
{
    public class PeopleController : ApiController
    {
        // GET: api/People
        public async Task<IEnumerable<Person>> GetPeople()
        {
            var unitOfWork = new UnitOfWork<Person>();
            return await unitOfWork.GetAllPersons();
            
        }

        // GET: api/People/5
        public async Task<Person> GetPerson(int id)
        {
            var unitOfWork = new UnitOfWork<Person>();
            return await unitOfWork.FindPersonById(id.ToString());
        }

        // POST: api/People
        public async Task PostPerson([FromBody]Person person)
        {
            
            var unitOfWork = new UnitOfWork<Person>();
            unitOfWork.Add(person);
            await unitOfWork.Commit();
        }

        // PUT: api/People/5
        public async Task PutPerson(int id, [FromBody]Person person)
        {
            var unitOfWork = new UnitOfWork<Person>();
            unitOfWork.Update(person);
            await unitOfWork.Commit();
        }

        // DELETE: api/People/5
        public async Task DeletePerson(int id)
        {
            var unitOfWork = new UnitOfWork<Person>();
            unitOfWork.Delete(id);
            await unitOfWork.Commit();
        }
    }
}
