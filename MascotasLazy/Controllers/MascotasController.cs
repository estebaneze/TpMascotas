using System.Threading.Tasks;
using MascotasLazy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ModeloDatos;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MascotasLazy.Controllers
{
    public class MascotasController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Mascotas
        public IQueryable<MascotaPOCO> Get()
        {
            var mascotas = from mas in db.Mascota
                            select new MascotaPOCO
                            {
                               Id = mas.Id,
                               nombre = mas.nombre,
                               tamañoId = mas.tamañoId,
                               sexo = mas.sexo,
                               razaId = mas.razaId,
                               observaciones = mas.observaciones,
                               color = mas.color,
                               caracter = mas.caracter,
                               avatar = mas.avatar,
                               fecha_nacimiento = mas.fecha_nacimiento
                            };

            return mascotas;
        }

        [Route("GetMascotasNombre")]
        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        public IQueryable<MascotaPOCO> GetMascotasNombre(string nombre)
        {
            var mascotas = this.Get().Where(x => x.nombre == nombre);
            return mascotas;
        }

        // GET: api/Mascotas/5
        [ResponseType(typeof(MascotaPOCO))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var mascota = await db.Mascota.FindAsync(id);

            if (mascota == null)
            {
                return NotFound();
            }

            return Ok(new MascotaPOCO(mascota));                
        }

        // POST: api/Mascotas
        [ResponseType(typeof(MascotaPOCO))]
        public async Task<IHttpActionResult> PostMascota(MascotaPOCO mascotaParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mascota = db.Mascota.Add(mascotaParametro.toDb());
            await db.SaveChangesAsync();
         
            return CreatedAtRoute("DefaultApi", new { id = mascota.Id }, new MascotaPOCO(mascota));
        }

        // PUT: api/Mascotas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMascota(int id, MascotaPOCO mascotaParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mascotaParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(mascotaParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotaExists(id))
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

        // DELETE: api/Mascotas/5
        [ResponseType(typeof(MascotaPOCO))]
        public async Task<IHttpActionResult> DeleteMascota(int id)
        {
            using (var db = new MascotasEntities())
            {
                Mascota mascota = await db.Mascota.FindAsync(id);

                if (mascota == null)
                {
                    return NotFound();
                }

                db.Mascota.Remove(mascota);
                await db.SaveChangesAsync();

                return Ok(new MascotaPOCO(mascota));
            }
        }

        private bool MascotaExists(int id)
        {
            return db.Mascota.Count(e => e.Id == id) > 0;
        }
    }
}
