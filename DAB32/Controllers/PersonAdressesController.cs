using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAB32.Models;

namespace DAB32.Controllers
{
    public class PersonAdressesController : ApiController
    {
        private DAB32Context db = new DAB32Context();

        // GET: api/PersonAdresses
        public IQueryable<PersonAdresse> GetPersonAdresses()
        {
            return db.PersonAdresses;
        }

        // GET: api/PersonAdresses/5
        [ResponseType(typeof(PersonAdresse))]
        public IHttpActionResult GetPersonAdresse(int id)
        {
            PersonAdresse personAdresse = db.PersonAdresses.Find(id);
            if (personAdresse == null)
            {
                return NotFound();
            }

            return Ok(personAdresse);
        }

        // PUT: api/PersonAdresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonAdresse(int id, PersonAdresse personAdresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personAdresse.MatchId)
            {
                return BadRequest();
            }

            db.Entry(personAdresse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonAdresseExists(id))
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

        // POST: api/PersonAdresses
        [ResponseType(typeof(PersonAdresse))]
        public IHttpActionResult PostPersonAdresse(PersonAdresse personAdresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonAdresses.Add(personAdresse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personAdresse.MatchId }, personAdresse);
        }

        // DELETE: api/PersonAdresses/5
        [ResponseType(typeof(PersonAdresse))]
        public IHttpActionResult DeletePersonAdresse(int id)
        {
            PersonAdresse personAdresse = db.PersonAdresses.Find(id);
            if (personAdresse == null)
            {
                return NotFound();
            }

            db.PersonAdresses.Remove(personAdresse);
            db.SaveChanges();

            return Ok(personAdresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonAdresseExists(int id)
        {
            return db.PersonAdresses.Count(e => e.MatchId == id) > 0;
        }
    }
}