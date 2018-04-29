using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAB33.DAL;
using DAB33.Models;

namespace DAB33.Controllers
{
    public class PeopleController : ApiController
    {
        // GET: api/People
        public IEnumerable<Person> GetPeople()
        {
            var people = new UnitOfWork<Person>().GetAllPersons();
            
            return people;
        }

        // GET: api/People/5
        public Person GetPerson(int id)
        {
            var unitOfWork = new UnitOfWork<Person>();
            return unitOfWork.FindPersonById(id.ToString());
        }

        // POST: api/People
        public void PostPerson([FromBody]string value)
        {
        }

        // PUT: api/People/5
        public void PutPerson(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void DeletePerson(int id)
        {
        }
    }
}
