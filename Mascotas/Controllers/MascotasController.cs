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
    public class MascotasController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Mascotas
        public IQueryable<MascotaPOCO> GetMascotas()
        {
            var mascotas = from mas in db.Mascota
                           join raz in db.Raza on mas.razaId equals raz.Id
                           join tam in db.Tamaño on mas.tamañoId equals tam.Id
                           select new MascotaPOCO
                           {
                               Id = mas.Id,
                               nombre = mas.nombre,
                               tamanioId = mas.tamañoId,
                               tamanioDescripcion = tam.descripcion,
                               sexo = mas.sexo,
                               razaId = mas.razaId,
                               razaDescripcion = raz.descripcion,
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
            var mascotas = this.GetMascotas().Where(x => x.nombre == nombre);
            return mascotas;
        }

        // GET: api/Mascotas/5
        [ResponseType(typeof(MascotaPOCO))]
        public IHttpActionResult GetMascota(int id)
        {
            var mascota = this.GetMascotas().Where(x => x.Id == id).FirstOrDefault();
            if (mascota == null)
            {
                return NotFound();
            }

            return Ok(mascota);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MascotaExists(int id)
        {
            return db.Mascota.Count(e => e.Id == id) > 0;
        }
    }
}