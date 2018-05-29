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
using Mascotas.Models;
using ModeloDatos;

namespace Mascotas.Controllers
{
    public class LocalidadsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Localidads
        public IQueryable<Localidad> GetLocalidads()
        {
            return db.Localidads;
        }

        // GET: api/Localidads/5
        [ResponseType(typeof(Localidad))]
        public async Task<IHttpActionResult> GetLocalidad(int id)
        {
            Localidad localidad = await db.Localidads.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }

            return Ok(localidad);
        }

        // PUT: api/Localidads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLocalidad(int id, Localidad localidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != localidad.Id)
            {
                return BadRequest();
            }

            db.Entry(localidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadExists(id))
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

        // POST: api/Localidads
        [ResponseType(typeof(Localidad))]
        public async Task<IHttpActionResult> PostLocalidad(Localidad localidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Localidads.Add(localidad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = localidad.Id }, localidad);
        }

        // DELETE: api/Localidads/5
        [ResponseType(typeof(Localidad))]
        public async Task<IHttpActionResult> DeleteLocalidad(int id)
        {
            Localidad localidad = await db.Localidads.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }

            db.Localidads.Remove(localidad);
            await db.SaveChangesAsync();

            return Ok(localidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocalidadExists(int id)
        {
            return db.Localidads.Count(e => e.Id == id) > 0;
        }
    }
}