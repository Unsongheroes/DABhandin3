using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DAB32.DAL;
using DAB32.DTO;
using DAB32.Models;

namespace DAB32.Controllers
{
    public class PeopleController : ApiController
    {


        // GET: api/People
        //Do instantiate a new DbContext instance for each request.
        public IEnumerable<PersonDTO> GetPeople()
        {
            DAB32Context db = new DAB32Context();
            IUnitOfWork uow = new UnitOfWork(db);
            var persons = from p in uow.Persons.GetAllPersons()
                          select new PersonDTO()
            {
                PersonId = p.Cpr,
                Email = p.Email,
                FirstName = p.Fornavn,
                LastName = p.EfterNavn,
                MiddleName = p.MellemNavn,
                PersonAddresses = p.PersonAdresses.Select(pa => new PersonAdressesDTO()
                {
                    AdresseId = pa.AdresseId,
                    MatchId = pa.MatchId,
                    PersonCpr = pa.PersonCpr,
                    Type = pa.Type
                }).ToList(),
                PhoneNumbers =  p.TelefonBog.Select( tlf => new PhoneNumberDTO()
                {
                    Telefonnummer = tlf.Telefonnummer,
                    TelefonSelskab = tlf.TelefonSelskab,
                    TelefonnummerType = tlf.TelefonnummerType,
                    PersonCpr = tlf.PersonCpr
                }).ToList()
            };

            return persons;
        }

        // GET: api/People/5
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult GetPerson(int id)
        {
            DAB32Context db = new DAB32Context();
            IUnitOfWork uow = new UnitOfWork(db);

            var person = uow.Persons.Get(id);
            PersonDTO personDto = new PersonDTO()
            {
                PersonId = person.Cpr,
                FirstName = person.Fornavn,
                MiddleName = person.MellemNavn,
                LastName = person.EfterNavn,
                Email = person.Email,
                PersonAddresses = person.PersonAdresses.Select(pa => new PersonAdressesDTO()
                {
                    AdresseId = pa.AdresseId,
                    MatchId = pa.MatchId,
                    PersonCpr = pa.PersonCpr,
                    Type = pa.Type
                }).ToList(),
                PhoneNumbers = person.TelefonBog.Select(tlf => new PhoneNumberDTO()
                {
                    Telefonnummer = tlf.Telefonnummer,
                    TelefonSelskab = tlf.TelefonSelskab,
                    TelefonnummerType = tlf.TelefonnummerType,
                    PersonCpr = tlf.PersonCpr
                }).ToList()

            };
                
            if (personDto == null)
            {
                return NotFound();
            }

            return Ok(new PersonDTO(person));
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, Person person)
        {
            DAB32Context db = new DAB32Context();
            IUnitOfWork uow = new UnitOfWork(db);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Cpr)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/People
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person person)
        {
            DAB32Context db = new DAB32Context();
            IUnitOfWork uow = new UnitOfWork(db);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.Cpr }, person);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            DAB32Context db = new DAB32Context();
            IUnitOfWork uow = new UnitOfWork(db);

            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            DAB32Context db = new DAB32Context();
            
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            DAB32Context db = new DAB32Context();
            
            return db.People.Count(e => e.Cpr == id) > 0;
        }
    }
}