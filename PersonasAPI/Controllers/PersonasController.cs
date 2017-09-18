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
using PersonasAPI.Models;

namespace PersonasAPI.Controllers
{
    public class PersonasController : ApiController
    {
        #region Fields

        private PersonasAPIContext db = new PersonasAPIContext();

        #endregion Fields

        #region Methods

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersonas(int id)
        {
            Persona personas = db.Personas.Find(id);
            if (personas == null)
            {
                return NotFound();
            }

            db.Personas.Remove(personas);
            db.SaveChanges();

            return Ok(personas);
        }

        // GET: api/Personas
        public IQueryable<Persona> GetPersonas()
        {
            return db.Personas;
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersonas(int id)
        {
            Persona personas = db.Personas.Find(id);
            if (personas == null)
            {
                return NotFound();
            }

            return Ok(personas);
        }

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersonas(Persona personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personas.Add(personas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personas.ID }, personas);
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonas(int id, Persona personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personas.ID)
            {
                return BadRequest();
            }

            db.Entry(personas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(id))
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonasExists(int id)
        {
            return db.Personas.Count(e => e.ID == id) > 0;
        }

        #endregion Methods
    }
}