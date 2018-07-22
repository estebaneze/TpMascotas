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
    public class DonacionesController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Donacion
        public IQueryable<DonacionPOCO> GetDonacions()
        {
            var donacion = from don in db.Donacion
                           join per in db.Persona on don.personaId equals per.Id
                           join mas in db.Mascota on don.mascotaId equals mas.Id

                           select new DonacionPOCO
                          {
                              Id = don.Id,
                              personaId = don.personaId,
                              personaNombreyApellido = per.nombre + ' ' + per.apellido,
                              mascotaId = don.mascotaId,
                              mascotaNombre = mas.nombre,
                              fecha = don.fecha,
                              monto = don.monto
                          };
            return donacion;
        }

        [Route("GetDonacion")]
        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        [ResponseType(typeof(DonacionPOCO))]


        public async Task<IHttpActionResult> GetDonacion(int id)
        {
            Donacion donacion = await db.Donacion.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            return Ok(new DonacionPOCO(donacion));
        }

        // PUT: api/Donacion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDonacion(int id, DonacionPOCO donacionParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donacionParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(donacionParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
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

        // POST: api/Donacion
        [ResponseType(typeof(DonacionPOCO))]
        public async Task<IHttpActionResult> PostDonacion(DonacionPOCO donacionParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donacion = db.Donacion.Add(donacionParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = donacion.Id }, new DonacionPOCO(donacion));
        }

        // DELETE: api/Donacion/5
        [ResponseType(typeof(DonacionPOCO))]
        public async Task<IHttpActionResult> DeleteDonacion(int id)
        {
            Donacion donacion = await db.Donacion.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            db.Donacion.Remove(donacion);
            await db.SaveChangesAsync();

            return Ok(new DonacionPOCO(donacion));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonacionExists(int id)
        {
            return db.Donacion.Count(e => e.Id == id) > 0;
        }
    }
}
