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
    public class EstadosController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Estados
        public IQueryable<EstadoPOCO> GetEstados()
        {
            var estado = from est in db.Estado
                           select new EstadoPOCO
                           {
                               Id = est.Id,
                               descripcion = est.descripcion
                           };

            return estado;
        }


        [ResponseType(typeof(EstadoPOCO))]


        public async Task<IHttpActionResult> GetEstado(int id)
        {
            Estado est = await db.Estado.FindAsync(id);
            if (est == null)
            {
                return NotFound();
            }

            return Ok(new EstadoPOCO(est));
        }


        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstado(int id, EstadoPOCO estadoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(estadoParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estado
        [ResponseType(typeof(EstadoPOCO))]
        public async Task<IHttpActionResult> PostEstado(EstadoPOCO estadoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var est = db.Estado.Add(estadoParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = est.Id }, new EstadoPOCO(est));
        }

        // DELETE: api/Estado/5

        [ResponseType(typeof(EstadoPOCO))]
        public async Task<IHttpActionResult> DeleteEstado(int id)
        {
            Estado est = await db.Estado.FindAsync(id);
            if (est == null)
            {
                return NotFound();
            }

            db.Estado.Remove(est);
            await db.SaveChangesAsync();

            return Ok(new EstadoPOCO(est));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoExists(int id)
        {
            return db.Estado.Count(e => e.Id == id) > 0;
        }
    }
}

