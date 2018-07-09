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
    public class VisitasController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Visitas
        public IQueryable<VisitaPOCO> GetVisitas()
        {
            var visitas = from vis in db.Visita
                              select new VisitaPOCO
                                {
                                    Id = vis.Id,
                                    veterinarioId = vis.veterinarioId,
                                    mascotaId = vis.mascotaId,
                                    fecha = vis.fecha,
                                    monto = vis.monto
                                };

            return visitas;
        }

        // GET: api/Visitas/5
        [ResponseType(typeof(VisitaPOCO))]
        public async Task<IHttpActionResult> GetVisita(int id)
        {
            Visita visita = await db.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            return Ok(new VisitaPOCO(visita));
        }

        // PUT: api/Visitas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVisita(int id, VisitaPOCO visitaParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitaParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(visitaParametro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(id))
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

        // POST: api/Visitas
        [ResponseType(typeof(VisitaPOCO))]
        public async Task<IHttpActionResult> PostVisita(VisitaPOCO visitaParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var visita = visitaParametro.toDb();
            db.Visita.Add(visita);

            foreach (var est in visitaParametro.estudio)
            {
                TipoEstudio tipoEstudio = db.TipoEstudio.Find(est.tipoEstudioId);
                Estudio estudio = new Estudio();

                var mesesValidoTipoEstudio = tipoEstudio.periodo_validez.HasValue ? tipoEstudio.periodo_validez.Value : 0;

                estudio.mascotaId = visitaParametro.mascotaId;
                estudio.observaciones = est.observaciones;
                estudio.tipoEstudioId = est.tipoEstudioId;
                estudio.veterinarioId = visitaParametro.veterinarioId;
                estudio.fecha_realizacion = DateTime.Now;
                estudio.fecha_vencimiento = visita.fecha.AddMonths(mesesValidoTipoEstudio);
                
                db.Estudio.Add(estudio);
            }

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = visita.Id }, new VisitaPOCO(visita));
        }

        // DELETE: api/Visitas/5
        [ResponseType(typeof(VisitaPOCO))]
        public async Task<IHttpActionResult> DeleteVisita(int id)
        {
            Visita visita = await db.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            db.Visita.Remove(visita);
            await db.SaveChangesAsync();

            return Ok(new VisitaPOCO(visita));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitaExists(int id)
        {
            return db.Visita.Count(e => e.Id == id) > 0;
        }
    }
}