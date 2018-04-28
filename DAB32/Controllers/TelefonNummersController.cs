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
    public class TelefonNummersController : ApiController
    {
        private DAB32Context db = new DAB32Context();

        // GET: api/TelefonNummers
        public IQueryable<TelefonNummer> GetTelefonNummers()
        {
            return db.TelefonNummers;
        }

        // GET: api/TelefonNummers/5
        [ResponseType(typeof(TelefonNummer))]
        public IHttpActionResult GetTelefonNummer(int id)
        {
            TelefonNummer telefonNummer = db.TelefonNummers.Find(id);
            if (telefonNummer == null)
            {
                return NotFound();
            }

            return Ok(telefonNummer);
        }

        // PUT: api/TelefonNummers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelefonNummer(int id, TelefonNummer telefonNummer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefonNummer.Telefonnummer)
            {
                return BadRequest();
            }

            db.Entry(telefonNummer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonNummerExists(id))
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

        // POST: api/TelefonNummers
        [ResponseType(typeof(TelefonNummer))]
        public IHttpActionResult PostTelefonNummer(TelefonNummer telefonNummer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TelefonNummers.Add(telefonNummer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telefonNummer.Telefonnummer }, telefonNummer);
        }

        // DELETE: api/TelefonNummers/5
        [ResponseType(typeof(TelefonNummer))]
        public IHttpActionResult DeleteTelefonNummer(int id)
        {
            TelefonNummer telefonNummer = db.TelefonNummers.Find(id);
            if (telefonNummer == null)
            {
                return NotFound();
            }

            db.TelefonNummers.Remove(telefonNummer);
            db.SaveChanges();

            return Ok(telefonNummer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonNummerExists(int id)
        {
            return db.TelefonNummers.Count(e => e.Telefonnummer == id) > 0;
        }
    }
}