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
    public class LocalidadesController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Localidades
        public IQueryable<LocalidadPOCO> GetEstados()
        {
            var localidad = from loc in db.Localidad
                            join prov in db.Provincia on loc.provinciaId equals prov.Id
                            select new LocalidadPOCO
                        {
                            Id = loc.Id,
                            nombre = loc.nombre,
                            provinciaNombre = prov.nombre,
                            provinciaId = loc.provinciaId
                        };

            return localidad;
        }


        [ResponseType(typeof(LocalidadPOCO))]


        public async Task<IHttpActionResult> GetLocalidad(int id)
        {
            Localidad loc = await db.Localidad.FindAsync(id);
            if (loc == null)
            {
                return NotFound();
            }

            return Ok(new LocalidadPOCO(loc));
        }


        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLocalidad(int id, LocalidadPOCO localidadParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != localidadParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(localidadParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadExists(id))
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

        // POST: api/Localidad
        [ResponseType(typeof(LocalidadPOCO))]
        public async Task<IHttpActionResult> PostLocalidad(LocalidadPOCO localidadParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loc = db.Localidad.Add(localidadParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = loc.Id }, new LocalidadPOCO(loc));
        }

        // DELETE: api/Localidad/5

        [ResponseType(typeof(LocalidadPOCO))]
        public async Task<IHttpActionResult> DeleteLocalidad(int id)
        {
            Localidad loc = await db.Localidad.FindAsync(id);
            if (loc == null)
            {
                return NotFound();
            }

            db.Localidad.Remove(loc);
            await db.SaveChangesAsync();

            return Ok(new LocalidadPOCO(loc));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocalidadExists(int id)
        {
            return db.Localidad.Count(e => e.Id == id) > 0;
        }
    }
}


