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
using System.Web.Http.Cors;

namespace Mascotas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdopcionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Adopcions
        public IQueryable<Adopcion> GetAdopcions()
        {
            return db.Adopcions;
        }

        // GET: api/Adopcions/5
        [ResponseType(typeof(Adopcion))]
        public async Task<IHttpActionResult> GetAdopcion(int id)
        {
            Adopcion adopcion = await db.Adopcions.FindAsync(id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return Ok(adopcion);
        }

        // PUT: api/Adopcions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdopcion(int id, Adopcion adopcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adopcion.Id)
            {
                return BadRequest();
            }

            db.Entry(adopcion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopcionExists(id))
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

        // POST: api/Adopcions
        [ResponseType(typeof(Adopcion))]
        public async Task<IHttpActionResult> PostAdopcion(Adopcion adopcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adopcions.Add(adopcion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = adopcion.Id }, adopcion);
        }

        // DELETE: api/Adopcions/5
        [ResponseType(typeof(Adopcion))]
        public async Task<IHttpActionResult> DeleteAdopcion(int id)
        {
            Adopcion adopcion = await db.Adopcions.FindAsync(id);
            if (adopcion == null)
            {
                return NotFound();
            }

            db.Adopcions.Remove(adopcion);
            await db.SaveChangesAsync();

            return Ok(adopcion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdopcionExists(int id)
        {
            return db.Adopcions.Count(e => e.Id == id) > 0;
        }
    }
}