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
    public class TipoContratoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TipoContratoes
        public IQueryable<TipoContrato> GetTipoContratoes()
        {
            return db.TipoContratoes;
        }

        // GET: api/TipoContratoes/5
        [ResponseType(typeof(TipoContrato))]
        public async Task<IHttpActionResult> GetTipoContrato(int id)
        {
            TipoContrato tipoContrato = await db.TipoContratoes.FindAsync(id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            return Ok(tipoContrato);
        }

        // PUT: api/TipoContratoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoContrato(int id, TipoContrato tipoContrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoContrato.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoContrato).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoContratoExists(id))
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

        // POST: api/TipoContratoes
        [ResponseType(typeof(TipoContrato))]
        public async Task<IHttpActionResult> PostTipoContrato(TipoContrato tipoContrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoContratoes.Add(tipoContrato);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoContrato.Id }, tipoContrato);
        }

        // DELETE: api/TipoContratoes/5
        [ResponseType(typeof(TipoContrato))]
        public async Task<IHttpActionResult> DeleteTipoContrato(int id)
        {
            TipoContrato tipoContrato = await db.TipoContratoes.FindAsync(id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            db.TipoContratoes.Remove(tipoContrato);
            await db.SaveChangesAsync();

            return Ok(tipoContrato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoContratoExists(int id)
        {
            return db.TipoContratoes.Count(e => e.Id == id) > 0;
        }
    }
}