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
            IUnitOfWork uow = new UnitOfWork();
            var persons = from p in uow.PersonRepository.GetAllPersons()
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
            IUnitOfWork uow = new UnitOfWork();

            var person = uow.PersonRepository.GetPerson(id);
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
            IUnitOfWork uow = new UnitOfWork();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Cpr)
            {
                return BadRequest();
            }

            var dbPerson = uow.PersonRepository.Update(id, person);
            

            try
            {
                uow.Complete();
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
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult PostPerson(PersonDTO person)
        {
            IUnitOfWork uow = new UnitOfWork();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uow.PersonRepository.Add(person.ToPerson());
            uow.Complete();

            return CreatedAtRoute("DefaultApi", new { id = person.PersonId }, person);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult DeletePerson(int id)
        {
            IUnitOfWork uow = new UnitOfWork();

            Person person = uow.PersonRepository.Get(id);
            if (person == null)
            {
                return NotFound();
            }


            uow.PersonRepository.Remove(person);
            uow.Complete();

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