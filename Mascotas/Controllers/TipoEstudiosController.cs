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
    public class TipoEstudiosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TipoEstudios
        public IQueryable<TipoEstudio> GetTipoEstudios()
        {
            return db.TipoEstudios;
        }

        // GET: api/TipoEstudios/5
        [ResponseType(typeof(TipoEstudio))]
        public async Task<IHttpActionResult> GetTipoEstudio(int id)
        {
            TipoEstudio tipoEstudio = await db.TipoEstudios.FindAsync(id);
            if (tipoEstudio == null)
            {
                return NotFound();
            }

            return Ok(tipoEstudio);
        }

        // PUT: api/TipoEstudios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoEstudio(int id, TipoEstudio tipoEstudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoEstudio.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoEstudio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEstudioExists(id))
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

        // POST: api/TipoEstudios
        [ResponseType(typeof(TipoEstudio))]
        public async Task<IHttpActionResult> PostTipoEstudio(TipoEstudio tipoEstudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoEstudios.Add(tipoEstudio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoEstudio.Id }, tipoEstudio);
        }

        // DELETE: api/TipoEstudios/5
        [ResponseType(typeof(TipoEstudio))]
        public async Task<IHttpActionResult> DeleteTipoEstudio(int id)
        {
            TipoEstudio tipoEstudio = await db.TipoEstudios.FindAsync(id);
            if (tipoEstudio == null)
            {
                return NotFound();
            }

            db.TipoEstudios.Remove(tipoEstudio);
            await db.SaveChangesAsync();

            return Ok(tipoEstudio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoEstudioExists(int id)
        {
            return db.TipoEstudios.Count(e => e.Id == id) > 0;
        }
    }
}