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
    public class DonacionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Donacions
        public IQueryable<Donacion> GetDonacions()
        {
            return db.Donacions;
        }

        // GET: api/Donacions/5
        [ResponseType(typeof(Donacion))]
        public async Task<IHttpActionResult> GetDonacion(int id)
        {
            Donacion donacion = await db.Donacions.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            return Ok(donacion);
        }

        // PUT: api/Donacions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDonacion(int id, Donacion donacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donacion.Id)
            {
                return BadRequest();
            }

            db.Entry(donacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
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

        // POST: api/Donacions
        [ResponseType(typeof(Donacion))]
        public async Task<IHttpActionResult> PostDonacion(Donacion donacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donacions.Add(donacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = donacion.Id }, donacion);
        }

        // DELETE: api/Donacions/5
        [ResponseType(typeof(Donacion))]
        public async Task<IHttpActionResult> DeleteDonacion(int id)
        {
            Donacion donacion = await db.Donacions.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            db.Donacions.Remove(donacion);
            await db.SaveChangesAsync();

            return Ok(donacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonacionExists(int id)
        {
            return db.Donacions.Count(e => e.Id == id) > 0;
        }
    }
}