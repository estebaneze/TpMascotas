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
    public class VeterinariosController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Veterinarios
        public IQueryable<VeterinarioPOCO> GetVeterinarios()
        {
            var veterinario = from vet in db.Veterinario
                          select new VeterinarioPOCO
                          {
                                veterinarioId = vet.veterinarioId,
                                matricula = vet.matricula,
                                habilitados = vet.habilitados
                            };
            return veterinario;
        }

        // GET: api/Veterinarios/5
        [ResponseType(typeof(VeterinarioPOCO))]
        public async Task<IHttpActionResult> GetVeterinario(int id)
        {
            Veterinario veterinario = await db.Veterinario.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            return Ok(new VeterinarioPOCO(veterinario));
        }

        // PUT: api/Veterinarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVeterinario(int id, VeterinarioPOCO veterinarioParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veterinarioParametro.veterinarioId)
            {
                return BadRequest();
            }

            db.Entry(veterinarioParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarioExists(id))
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

        // POST: api/Veterinarios
        [ResponseType(typeof(VeterinarioPOCO))]
        public async Task<IHttpActionResult> PostVeterinario(VeterinarioPOCO veterinarioParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var veterinario = db.Veterinario.Add(veterinarioParametro.toDb());

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VeterinarioExists(veterinario.veterinarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = veterinario.veterinarioId }, new VeterinarioPOCO(veterinario));
        }

        // DELETE: api/Veterinarios/5
        [ResponseType(typeof(VeterinarioPOCO))]
        public async Task<IHttpActionResult> DeleteVeterinario(int id)
        {
            Veterinario veterinario = await db.Veterinario.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            db.Veterinario.Remove(veterinario);
            await db.SaveChangesAsync();

            return Ok(new VeterinarioPOCO(veterinario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VeterinarioExists(int id)
        {
            return db.Veterinario.Count(e => e.veterinarioId == id) > 0;
        }
    }
}