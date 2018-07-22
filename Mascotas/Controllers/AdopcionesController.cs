
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
    public class AdopcionesController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Adopciones
        public IQueryable<AdopcionPOCO> GetAdopciones()
        {
            var adopcion = from adop in db.Adopcion
                           join per in db.Persona on adop.personaId equals per.Id
                           join per2 in db.Persona on adop.personaAdoptaId equals per2.Id
                           join mas in db.Mascota on adop.mascotaId equals mas.Id
                           join con in db.TipoContrato on adop.tipoContratoId equals con.Id 
                           select new AdopcionPOCO
                                 {
                                     Id = adop.Id,
                                     personaId = adop.personaId,
                                     personaNombreyApellido = per.nombre +  " " + per.apellido,
                                     mascotaId = adop.mascotaId,
                                     mascotaNombre = mas.nombre,
                                     personaAdoptaId = adop.personaAdoptaId,
                                     personaAdoptaNombreyApellido = per2.nombre + " " + per2.apellido,
                                     fecha = adop.fecha,
                                     tipoContratoId = adop.tipoContratoId,
                                     tipoContratoDescripcion = con.terminos

                                    
                                 };

            return adopcion;
        }


        [ResponseType(typeof(AdopcionPOCO))]


        public async Task<IHttpActionResult> GetAdopcion(int id)
        {
            Adopcion adop = await db.Adopcion.FindAsync(id);
            if (adop == null)
            {
                return NotFound();
            }

            return Ok(new AdopcionPOCO(adop));
        }


        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdopcion(int id, AdopcionPOCO adopcionParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adopcionParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(adopcionParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopcionExists(id))
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
        [ResponseType(typeof(AdopcionPOCO))]
        public async Task<IHttpActionResult> PostAdopcion(AdopcionPOCO adopcionParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adop = db.Adopcion.Add(adopcionParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = adop.Id }, new AdopcionPOCO(adop));
        }

        // DELETE: api/Adopcion/5

        [ResponseType(typeof(AdopcionPOCO))]
        public async Task<IHttpActionResult> DeleteAdopcion(int id)
        {
            Adopcion adop = await db.Adopcion.FindAsync(id);
            if (adop == null)
            {
                return NotFound();
            }

            db.Adopcion.Remove(adop);
            await db.SaveChangesAsync();

            return Ok(new AdopcionPOCO(adop));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdopcionExists(int id)
        {
            return db.Adopcion.Count(e => e.Id == id) > 0;
        }
    }
}

