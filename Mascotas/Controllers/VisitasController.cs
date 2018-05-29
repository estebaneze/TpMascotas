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
    public class VisitasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Visitas
        public IQueryable<Visita> GetVisitas()
        {
            return db.Visitas;
        }

        // GET: api/Visitas/5
        [ResponseType(typeof(Visita))]
        public async Task<IHttpActionResult> GetVisita(int id)
        {
            Visita visita = await db.Visitas.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            return Ok(visita);
        }

        // PUT: api/Visitas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVisita(int id, Visita visita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visita.Id)
            {
                return BadRequest();
            }

            db.Entry(visita).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(id))
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

        // POST: api/Visitas
        [ResponseType(typeof(Visita))]
        public async Task<IHttpActionResult> PostVisita(Visita visita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visitas.Add(visita);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = visita.Id }, visita);
        }

        // DELETE: api/Visitas/5
        [ResponseType(typeof(Visita))]
        public async Task<IHttpActionResult> DeleteVisita(int id)
        {
            Visita visita = await db.Visitas.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            db.Visitas.Remove(visita);
            await db.SaveChangesAsync();

            return Ok(visita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitaExists(int id)
        {
            return db.Visitas.Count(e => e.Id == id) > 0;
        }
    }
}