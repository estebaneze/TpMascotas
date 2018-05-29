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

namespace Mascotas.Controllers
{
    public class VeterinariosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Veterinarios
        public IQueryable<Veterinario> GetVeterinarios()
        {
            return db.Veterinarios;
        }

        // GET: api/Veterinarios/5
        [ResponseType(typeof(Veterinario))]
        public async Task<IHttpActionResult> GetVeterinario(int id)
        {
            Veterinario veterinario = await db.Veterinarios.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            return Ok(veterinario);
        }

        // PUT: api/Veterinarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVeterinario(int id, Veterinario veterinario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veterinario.veterinarioId)
            {
                return BadRequest();
            }

            db.Entry(veterinario).State = EntityState.Modified;

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
        [ResponseType(typeof(Veterinario))]
        public async Task<IHttpActionResult> PostVeterinario(Veterinario veterinario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Veterinarios.Add(veterinario);

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

            return CreatedAtRoute("DefaultApi", new { id = veterinario.veterinarioId }, veterinario);
        }

        // DELETE: api/Veterinarios/5
        [ResponseType(typeof(Veterinario))]
        public async Task<IHttpActionResult> DeleteVeterinario(int id)
        {
            Veterinario veterinario = await db.Veterinarios.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            db.Veterinarios.Remove(veterinario);
            await db.SaveChangesAsync();

            return Ok(veterinario);
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
            return db.Veterinarios.Count(e => e.veterinarioId == id) > 0;
        }
    }
}