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
    public class AdopcionEstadoController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/adopcionEstado
        public IQueryable<AdopcionEstadoPOCO> GetAdopcionEstados()
        {
            var adopcionEstado = from adop in db.AdopcionEstado
                                 join est in db.Estado on adop.estadoId equals est.Id
                                
            select new AdopcionEstadoPOCO
                        {
                            Id = adop.Id,
                            adopcionId = adop.adopcionId,
                            estadoId = adop.estadoId,
                            estadoDescripcion = est.descripcion

                        };

            return adopcionEstado;
        }


        [ResponseType(typeof(AdopcionEstadoPOCO))]


        public async Task<IHttpActionResult> GetAdopcionEstado(int id)
        {
            AdopcionEstado adop = await db.AdopcionEstado.FindAsync(id);
            if (adop == null)
            {
                return NotFound();
            }

            return Ok(new AdopcionEstadoPOCO(adop));
        }

        
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdopcionEstado(int id, AdopcionEstadoPOCO adopcionEstadoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adopcionEstadoParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(adopcionEstadoParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopcionEstadoExists(id))
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
        [ResponseType(typeof(AdopcionEstadoPOCO))]
        public async Task<IHttpActionResult> PostAdopcionEstado(AdopcionEstadoPOCO adopcionEstadoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adop = db.AdopcionEstado.Add(adopcionEstadoParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = adop.Id }, new AdopcionEstadoPOCO(adop));
        }

        // DELETE: api/Razas/5

        [ResponseType(typeof(AdopcionEstadoPOCO))]
        public async Task<IHttpActionResult> DeleteAdopcionEstado(int id)
        {
            AdopcionEstado adop = await db.AdopcionEstado.FindAsync(id);
            if (adop == null)
            {
                return NotFound();
            }

            db.AdopcionEstado.Remove(adop);
            await db.SaveChangesAsync();

            return Ok(new AdopcionEstadoPOCO(adop));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdopcionEstadoExists(int id)
        {
            return db.AdopcionEstado.Count(e => e.Id == id) > 0;
        }
    }
}









