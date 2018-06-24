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
    public class RazasController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Razas
        public IQueryable<RazaPOCO> GetRazas()
        {
            var razas = from raz in db.Raza
                            select new RazaPOCO
                            {
                                Id = raz.Id,
                                descripcion = raz.descripcion
                            };

            return razas;
        }

        // GET: api/Razas/5
        [ResponseType(typeof(RazaPOCO))]
        public async Task<IHttpActionResult> GetRaza(int id)
        {
            Raza raza = await db.Raza.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }

            return Ok(new RazaPOCO(raza));
        }

        // PUT: api/Razas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRaza(int id, RazaPOCO razaParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != razaParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(razaParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazaExists(id))
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
        [ResponseType(typeof(RazaPOCO))]
        public async Task<IHttpActionResult> PostRaza(RazaPOCO razaParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var raza = db.Raza.Add(razaParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = raza.Id }, new RazaPOCO(raza));
        }

        // DELETE: api/Razas/5
        [ResponseType(typeof(RazaPOCO))]
        public async Task<IHttpActionResult> DeleteRaza(int id)
        {
            Raza raza = await db.Raza.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }

            db.Raza.Remove(raza);
            await db.SaveChangesAsync();

            return Ok(new RazaPOCO(raza));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RazaExists(int id)
        {
            return db.Raza.Count(e => e.Id == id) > 0;
        }
    }
}