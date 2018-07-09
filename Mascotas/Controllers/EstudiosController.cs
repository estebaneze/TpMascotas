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
    public class EstudiosController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Estudios
        public IQueryable<EstudioPOCO> GetEstudios()
        {
            var estudio = from est in db.Estudio
                          join vet in db.Veterinario on est.veterinarioId equals vet.veterinarioId
                          join per in db.Persona on vet.veterinarioId equals per.Id
                          join test in db.TipoEstudio on est.tipoEstudioId equals test.Id
                          select new EstudioPOCO
                          {
                                Id = est.Id,
                                mascotaId = est.mascotaId,
                                tipoEstudioId = est.tipoEstudioId,
                                tipoEstudioDescripcion = test.descripcion,
                                fecha_realizacion = est.fecha_realizacion,
                                veterinarioId = est.veterinarioId,
                                veterinarioNombreApellido = per.apellido + " " + per.nombre + " (mat." + vet.matricula + ")",
                                fecha_vencimiento = est.fecha_vencimiento,
                                observaciones = est.observaciones
                           };
            return estudio;
        }

        [Route("GetEstudioMascota")]
        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        public IQueryable<EstudioPOCO> GetEstudiosMascota(int id)
        {
            var estudio = this.GetEstudios().Where(x => x.mascotaId == id);
            return estudio;
        }

        // GET: api/Estudios/5
        [ResponseType(typeof(EstudioPOCO))]
        public IHttpActionResult GetEstudio(int id)
        {
            var estudio = this.GetEstudios().Where(x => x.Id == id).FirstOrDefault();
            if (estudio == null)
            {
                return NotFound();
            }

            return Ok(estudio);
        }

        // PUT: api/Estudios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstudio(int id, EstudioPOCO estudioParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudioParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(estudioParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudioExists(id))
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

        // POST: api/Estudios
        [ResponseType(typeof(EstudioPOCO))]
        public async Task<IHttpActionResult> PostEstudio(EstudioPOCO estudioParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estudio = db.Estudio.Add(estudioParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = estudio.Id }, new EstudioPOCO(estudio));
        }

        // DELETE: api/Estudios/5
        [ResponseType(typeof(EstudioPOCO))]
        public async Task<IHttpActionResult> DeleteEstudio(int id)
        {
            Estudio estudio = await db.Estudio.FindAsync(id);
            if (estudio == null)
            {
                return NotFound();
            }

            db.Estudio.Remove(estudio);
            await db.SaveChangesAsync();

            return Ok(new EstudioPOCO(estudio));
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudioExists(int id)
        {
            return db.Estudio.Count(e => e.Id == id) > 0;
        }
    }
}