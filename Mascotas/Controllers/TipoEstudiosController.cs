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
        private MascotasEntities db = new MascotasEntities();

        // GET: api/TipoEstudios
        public IQueryable<TipoEstudioPOCO> GetTipoEstudios()
        {
            var tipoEstudio = from est in db.TipoEstudio
                               select new TipoEstudioPOCO
                               {
                                   Id = est.Id,
                                   descripcion = est.descripcion,
                                   periodo_validez = est.periodo_validez 
                               };

            return tipoEstudio;
        }

        // GET: api/TipoEstudios/5
        [ResponseType(typeof(TipoEstudioPOCO))]
        public async Task<IHttpActionResult> GetTipoEstudio(int id)
        {
            TipoEstudio tipoEstudio = await db.TipoEstudio.FindAsync(id);
            if (tipoEstudio == null)
            {
                return NotFound();
            }

            return Ok(new TipoEstudioPOCO(tipoEstudio));
        }

        // PUT: api/TipoEstudios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoEstudio(int id, TipoEstudioPOCO tipoEstudioParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoEstudioParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoEstudioParametro.toDb()).State = EntityState.Modified;

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
        [ResponseType(typeof(TipoEstudioPOCO))]
        public async Task<IHttpActionResult> PostTipoEstudio(TipoEstudioPOCO tipoEstudioParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoEstudio = db.TipoEstudio.Add(tipoEstudioParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoEstudio.Id }, new TipoEstudioPOCO(tipoEstudio));
        }

        // DELETE: api/TipoEstudios/5
        [ResponseType(typeof(TipoEstudio))]
        public async Task<IHttpActionResult> DeleteTipoEstudio(int id)
        {
            TipoEstudio tipoEstudio = await db.TipoEstudio.FindAsync(id);
            if (tipoEstudio == null)
            {
                return NotFound();
            }

            db.TipoEstudio.Remove(tipoEstudio);
            await db.SaveChangesAsync();

            return Ok(new TipoEstudioPOCO(tipoEstudio));
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
            return db.TipoEstudio.Count(e => e.Id == id) > 0;
        }
    }
}