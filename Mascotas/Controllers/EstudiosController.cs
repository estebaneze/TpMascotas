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
    public class EstudiosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Estudios
        public IQueryable<Estudio> GetEstudios()
        {
            return db.Estudios;
        }

        // GET: api/Estudios/5
        [ResponseType(typeof(Estudio))]
        public async Task<IHttpActionResult> GetEstudio(int id)
        {
            Estudio estudio = await db.Estudios.FindAsync(id);
            if (estudio == null)
            {
                return NotFound();
            }

            return Ok(estudio);
        }

        // PUT: api/Estudios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstudio(int id, Estudio estudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudio.Id)
            {
                return BadRequest();
            }

            db.Entry(estudio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudioExists(id))
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

        // POST: api/Estudios
        [ResponseType(typeof(Estudio))]
        public async Task<IHttpActionResult> PostEstudio(Estudio estudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estudios.Add(estudio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = estudio.Id }, estudio);
        }

        // DELETE: api/Estudios/5
        [ResponseType(typeof(Estudio))]
        public async Task<IHttpActionResult> DeleteEstudio(int id)
        {
            Estudio estudio = await db.Estudios.FindAsync(id);
            if (estudio == null)
            {
                return NotFound();
            }

            db.Estudios.Remove(estudio);
            await db.SaveChangesAsync();

            return Ok(estudio);
        }

        [Route("GetEstudioMascota")]
        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        public IQueryable<Estudio> GetEstudiosMascota(int id)
        {
            return db.Estudios.Where(x => x.mascotaId == id).OrderByDescending(y => y.fecha_realizacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudioExists(int id)
        {
            return db.Estudios.Count(e => e.Id == id) > 0;
        }
    }
}