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
    public class ByPostNummersController : ApiController
    {
        private DAB32Context db = new DAB32Context();

        // GET: api/ByPostNummers
        public IQueryable<ByPostNummer> GetByPostNummers()
        {
            return db.ByPostNummers;
        }

        // GET: api/ByPostNummers/5
        [ResponseType(typeof(ByPostNummer))]
        public IHttpActionResult GetByPostNummer(int id)
        {
            ByPostNummer byPostNummer = db.ByPostNummers.Find(id);
            if (byPostNummer == null)
            {
                return NotFound();
            }

            return Ok(byPostNummer);
        }

        // PUT: api/ByPostNummers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutByPostNummer(int id, ByPostNummer byPostNummer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != byPostNummer.Postnummer)
            {
                return BadRequest();
            }

            db.Entry(byPostNummer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ByPostNummerExists(id))
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

        // POST: api/ByPostNummers
        [ResponseType(typeof(ByPostNummer))]
        public IHttpActionResult PostByPostNummer(ByPostNummer byPostNummer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ByPostNummers.Add(byPostNummer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = byPostNummer.Postnummer }, byPostNummer);
        }

        // DELETE: api/ByPostNummers/5
        [ResponseType(typeof(ByPostNummer))]
        public IHttpActionResult DeleteByPostNummer(int id)
        {
            ByPostNummer byPostNummer = db.ByPostNummers.Find(id);
            if (byPostNummer == null)
            {
                return NotFound();
            }

            db.ByPostNummers.Remove(byPostNummer);
            db.SaveChanges();

            return Ok(byPostNummer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ByPostNummerExists(int id)
        {
            return db.ByPostNummers.Count(e => e.Postnummer == id) > 0;
        }
    }
}