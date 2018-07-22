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
    public class LocalesController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Locales
        public IQueryable<LocalPOCO> GetEstados()
        {
            var local = from loc in db.Local
                        join prov in db.Provincia on loc.provinciaId equals prov.Id
                        join loca in db.Localidad on loc.localidadId equals loca.Id
                        select new LocalPOCO
                         {
                             Id = loc.Id,
                             provinciaId = loc.provinciaId,
                             provinciaNombre = prov.nombre,
                             localidadId = loc.localidadId,
                             localidadNombre = loca.nombre,
                             domicilio = loc.domicilio,
                             razon_social = loc.razon_social
                          };

            return local;
        }


        [ResponseType(typeof(LocalPOCO))]


        public async Task<IHttpActionResult> GetLocal(int id)
        {
            Local loc = await db.Local.FindAsync(id);
            if (loc == null)
            {
                return NotFound();
            }

            return Ok(new LocalPOCO(loc));
        }


        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLocal(int id, LocalPOCO localParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != localParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(localParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalExists(id))
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

        // POST: api/Local
        [ResponseType(typeof(LocalPOCO))]
        public async Task<IHttpActionResult> PostLocal(LocalPOCO localParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loc = db.Local.Add(localParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = loc.Id }, new LocalPOCO(loc));
        }

        // DELETE: api/Local/5

        [ResponseType(typeof(LocalPOCO))]
        public async Task<IHttpActionResult> DeleteLocal(int id)
        {
            Local loc = await db.Local.FindAsync(id);
            if (loc == null)
            {
                return NotFound();
            }

            db.Local.Remove(loc);
            await db.SaveChangesAsync();

            return Ok(new LocalPOCO(loc));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocalExists(int id)
        {
            return db.Local.Count(e => e.Id == id) > 0;
        }
    }
}

