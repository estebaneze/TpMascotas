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
        private MascotasEntities db = new MascotasEntities();

        // GET: api/TipoContratoes
        public IQueryable<TipoContratoPOCO> GetTipoContratoes()
        {
            var tipoContrato = from con in db.TipoContrato
                         select new TipoContratoPOCO
                         {
                             Id = con.Id,
                             terminos = con.terminos
                         };

            return tipoContrato;
        }

        // GET: api/TipoContratoes/5
        [ResponseType(typeof(TipoContratoPOCO))]
        public async Task<IHttpActionResult> GetTipoContrato(int id)
        {
            TipoContrato tipoContrato = await db.TipoContrato.FindAsync(id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            return Ok(new TipoContratoPOCO(tipoContrato));
        }

        // PUT: api/TipoContratoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoContrato(int id, TipoContratoPOCO tipoContratoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoContratoParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoContratoParametro.toDb()).State = EntityState.Modified;

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
        [ResponseType(typeof(TipoContratoPOCO))]
        public async Task<IHttpActionResult> PostTipoContrato(TipoContratoPOCO tipoContratoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoContrato = db.TipoContrato.Add(tipoContratoParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoContrato.Id }, new TipoContratoPOCO(tipoContrato));
        }

        // DELETE: api/TipoContratoes/5
        [ResponseType(typeof(TipoContratoPOCO))]
        public async Task<IHttpActionResult> DeleteTipoContrato(int id)
        {
            TipoContrato tipoContrato = await db.TipoContrato.FindAsync(id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            db.TipoContrato.Remove(tipoContrato);
            await db.SaveChangesAsync();

            return Ok(new TipoContratoPOCO(tipoContrato));
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
            return db.TipoContrato.Count(e => e.Id == id) > 0;
        }
    }
}