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
    public class RazasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Razas
        public IQueryable<Raza> GetRazas()
        {
            return db.Razas;
        }

        // GET: api/Razas/5
        [ResponseType(typeof(Raza))]
        public async Task<IHttpActionResult> GetRaza(int id)
        {
            Raza raza = await db.Razas.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }

            return Ok(raza);
        }

        // PUT: api/Razas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaza(int id, Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raza.Id)
            {
                return BadRequest();
            }

            db.Entry(raza).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazaExists(id))
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

        // POST: api/Razas
        [ResponseType(typeof(Raza))]
        public async Task<IHttpActionResult> PostRaza(Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Razas.Add(raza);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = raza.Id }, raza);
        }

        // DELETE: api/Razas/5
        [ResponseType(typeof(Raza))]
        public async Task<IHttpActionResult> DeleteRaza(int id)
        {
            Raza raza = await db.Razas.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }

            db.Razas.Remove(raza);
            await db.SaveChangesAsync();

            return Ok(raza);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RazaExists(int id)
        {
            return db.Razas.Count(e => e.Id == id) > 0;
        }
    }
}