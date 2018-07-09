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
    public class TamanioController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Tamanio
        public IQueryable<TamanioPOCO> GetTamanio()
        {
            var tamaño = from tam in db.Tamaño
                        select new TamanioPOCO
                        {
                            Id = tam.Id,
                            descripcion = tam.descripcion
                        };

            return tamaño;
        }

        // GET: api/Tamanio/5
        [ResponseType(typeof(TamanioPOCO))]
        public async Task<IHttpActionResult> GetTamanio(int id)
        {
            Tamaño tamaño = await db.Tamaño.FindAsync(id);
            if (tamaño == null)
            {
                return NotFound();
            }

            return Ok(new TamanioPOCO(tamaño));
        }

        // PUT: api/Tamanio/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTamanio(int id, TamanioPOCO tamañoParametro)
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

        // POST: api/Tamanio
        [ResponseType(typeof(TamanioPOCO))]
        public async Task<IHttpActionResult> PostTamanio(TamanioPOCO tamañoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tamaño = db.Tamaño.Add(tamañoParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tamaño.Id }, new TamanioPOCO(tamaño));
        }

        // DELETE: api/Tamanio/5
        [ResponseType(typeof(TamanioPOCO))]
        public async Task<IHttpActionResult> DeleteTamanio(int id)
        {
            Tamaño tamaño = await db.Tamaño.FindAsync(id);
            if (tamaño == null)
            {
                return NotFound();
            }

            db.Tamaño.Remove(tamaño);
            await db.SaveChangesAsync();

            return Ok(new TamanioPOCO(tamaño));
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