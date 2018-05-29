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
    public class ProvinciasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Provincias
        public IQueryable<Provincia> GetProvincias()
        {
            return db.Provincias;
        }

        // GET: api/Provincias/5
        [ResponseType(typeof(Provincia))]
        public async Task<IHttpActionResult> GetProvincia(int id)
        {
            Provincia provincia = await db.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }

            return Ok(provincia);
        }

        // PUT: api/Provincias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProvincia(int id, Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provincia.Id)
            {
                return BadRequest();
            }

            db.Entry(provincia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciaExists(id))
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

        // POST: api/Provincias
        [ResponseType(typeof(Provincia))]
        public async Task<IHttpActionResult> PostProvincia(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Provincias.Add(provincia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = provincia.Id }, provincia);
        }

        // DELETE: api/Provincias/5
        [ResponseType(typeof(Provincia))]
        public async Task<IHttpActionResult> DeleteProvincia(int id)
        {
            Provincia provincia = await db.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }

            db.Provincias.Remove(provincia);
            await db.SaveChangesAsync();

            return Ok(provincia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProvinciaExists(int id)
        {
            return db.Provincias.Count(e => e.Id == id) > 0;
        }
    }
}