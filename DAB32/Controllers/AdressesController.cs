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
using DAB32.DAL;
using DAB32.DTO;
using DAB32.Models;

namespace DAB32.Controllers
{
    public class AdressesController : ApiController
    {
        private DAB32Context db = new DAB32Context();

        // GET: api/Adresses
        public IEnumerable<AddressDTO> GetAdresses()
        {
            DAB32Context db = new DAB32Context();
            IUnitOfWork _uow = new UnitOfWork(db);

            var address = from a in _uow.Persons.GetAllAdresses()
                select new AddressDTO()
                {
                    AdresseId = a.AdresseId,
                    Husnummer = a.Husnummer,
                    VejNavn = a.VejNavn,
                    PersonAdresses = a.PersonAdresses.Select(pa => new PersonAdressesDTO()
                    {
                        AdresseId = pa.AdresseId,
                        MatchId = pa.MatchId,
                        PersonCpr = pa.PersonCpr,
                        Type = pa.Type
                    }).ToList(),
                    
                };

            return address;
        }

        // GET: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult GetAdresse(int id)
        {
            Adresse adresse = db.Adresses.Find(id);
            if (adresse == null)
            {
                return NotFound();
            }

            return Ok(adresse);
        }

        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdresse(int id, Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adresse.AdresseId)
            {
                return BadRequest();
            }

            db.Entry(adresse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresses
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adresses.Add(adresse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adresse.AdresseId }, adresse);
        }

        // DELETE: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult DeleteAdresse(int id)
        {
            Adresse adresse = db.Adresses.Find(id);
            if (adresse == null)
            {
                return NotFound();
            }

            db.Adresses.Remove(adresse);
            db.SaveChanges();

            return Ok(adresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdresseExists(int id)
        {
            return db.Adresses.Count(e => e.AdresseId == id) > 0;
        }
    }
}