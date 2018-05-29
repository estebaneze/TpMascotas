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
    public class TamañoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Tamaño
        public IQueryable<Tamaño> GetTamaño()
        {
            return db.Tamaño;
        }

        // GET: api/Tamaño/5
        [ResponseType(typeof(Tamaño))]
        public async Task<IHttpActionResult> GetTamaño(int id)
        {
            Tamaño tamaño = await db.Tamaño.FindAsync(id);
            if (tamaño == null)
            {
                return NotFound();
            }

            return Ok(tamaño);
        }

        // PUT: api/Tamaño/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTamaño(int id, Tamaño tamaño)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tamaño.Id)
            {
                return BadRequest();
            }

            db.Entry(tamaño).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TamañoExists(id))
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

        // POST: api/Tamaño
        [ResponseType(typeof(Tamaño))]
        public async Task<IHttpActionResult> PostTamaño(Tamaño tamaño)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tamaño.Add(tamaño);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tamaño.Id }, tamaño);
        }

        // DELETE: api/Tamaño/5
        [ResponseType(typeof(Tamaño))]
        public async Task<IHttpActionResult> DeleteTamaño(int id)
        {
            Tamaño tamaño = await db.Tamaño.FindAsync(id);
            if (tamaño == null)
            {
                return NotFound();
            }

            db.Tamaño.Remove(tamaño);
            await db.SaveChangesAsync();

            return Ok(tamaño);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TamañoExists(int id)
        {
            return db.Tamaño.Count(e => e.Id == id) > 0;
        }
    }
}