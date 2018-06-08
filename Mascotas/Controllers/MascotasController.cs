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
    public class MascotasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Mascotas
        public IQueryable<Mascota> GetMascotas()
        {
            return db.Mascotas;
        }

        // GET: api/Mascotas/5
        [ResponseType(typeof(Mascota))]
        public async Task<IHttpActionResult> GetMascota(int id)
        {
            Mascota mascota = await db.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }

            return Ok(mascota);
        }

        // PUT: api/Mascotas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMascota(int id, Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mascota.Id)
            {
                return BadRequest();
            }

            db.Entry(mascota).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotaExists(id))
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

        // POST: api/Mascotas
        [ResponseType(typeof(Mascota))]
        public async Task<IHttpActionResult> PostMascota(Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mascotas.Add(mascota);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mascota.Id }, mascota);
        }

        // DELETE: api/Mascotas/5
        [ResponseType(typeof(Mascota))]
        public async Task<IHttpActionResult> DeleteMascota(int id)
        {
            Mascota mascota = await db.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }

            db.Mascotas.Remove(mascota);
            await db.SaveChangesAsync();

            return Ok(mascota);
        }
        
        [Route("GetMascotasNombre")]
        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        public IQueryable<Mascota> GetMascotasNombre(string nombre)
        {
            IQueryable<Mascota> mascotas = db.Mascotas.Where(x => x.nombre == nombre);
            return mascotas;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MascotaExists(int id)
        {
            return db.Mascotas.Count(e => e.Id == id) > 0;
        }
    }
}