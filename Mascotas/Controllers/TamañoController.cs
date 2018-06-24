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
    public class TamañoController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Tamaño
        public IQueryable<TamañoPOCO> GetTamaño()
        {
            var tamaño = from tam in db.Tamaño
                        select new TamañoPOCO
                        {
                            Id = tam.Id,
                            descripcion = tam.descripcion
                        };

            return tamaño;
        }

        // GET: api/Tamaño/5
        [ResponseType(typeof(TamañoPOCO))]
        public async Task<IHttpActionResult> GetTamaño(int id)
        {
            Tamaño tamaño = await db.Tamaño.FindAsync(id);
            if (tamaño == null)
            {
                return NotFound();
            }

            return Ok(new TamañoPOCO(tamaño));
        }

        // PUT: api/Tamaño/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTamaño(int id, TamañoPOCO tamañoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tamañoParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(tamañoParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TamañoExists(id))
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

        // POST: api/Tamaño
        [ResponseType(typeof(TamañoPOCO))]
        public async Task<IHttpActionResult> PostTamaño(TamañoPOCO tamañoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tamaño = db.Tamaño.Add(tamañoParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tamaño.Id }, new TamañoPOCO(tamaño));
        }

        // DELETE: api/Tamaño/5
        [ResponseType(typeof(TamañoPOCO))]
        public async Task<IHttpActionResult> DeleteTamaño(int id)
        {
            Tamaño tamaño = await db.Tamaño.FindAsync(id);
            if (tamaño == null)
            {
                return NotFound();
            }

            db.Tamaño.Remove(tamaño);
            await db.SaveChangesAsync();

            return Ok(new TamañoPOCO(tamaño));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TamañoExists(int id)
        {
            return db.Tamaño.Count(e => e.Id == id) > 0;
        }
    }
}