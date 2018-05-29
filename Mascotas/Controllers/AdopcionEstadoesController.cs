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
    public class AdopcionEstadoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AdopcionEstadoes
        public IQueryable<AdopcionEstado> GetAdopcionEstadoes()
        {
            return db.AdopcionEstadoes;
        }

        // GET: api/AdopcionEstadoes/5
        [ResponseType(typeof(AdopcionEstado))]
        public async Task<IHttpActionResult> GetAdopcionEstado(int id)
        {
            AdopcionEstado adopcionEstado = await db.AdopcionEstadoes.FindAsync(id);
            if (adopcionEstado == null)
            {
                return NotFound();
            }

            return Ok(adopcionEstado);
        }

        // PUT: api/AdopcionEstadoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdopcionEstado(int id, AdopcionEstado adopcionEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adopcionEstado.Id)
            {
                return BadRequest();
            }

            db.Entry(adopcionEstado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopcionEstadoExists(id))
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

        // POST: api/AdopcionEstadoes
        [ResponseType(typeof(AdopcionEstado))]
        public async Task<IHttpActionResult> PostAdopcionEstado(AdopcionEstado adopcionEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdopcionEstadoes.Add(adopcionEstado);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = adopcionEstado.Id }, adopcionEstado);
        }

        // DELETE: api/AdopcionEstadoes/5
        [ResponseType(typeof(AdopcionEstado))]
        public async Task<IHttpActionResult> DeleteAdopcionEstado(int id)
        {
            AdopcionEstado adopcionEstado = await db.AdopcionEstadoes.FindAsync(id);
            if (adopcionEstado == null)
            {
                return NotFound();
            }

            db.AdopcionEstadoes.Remove(adopcionEstado);
            await db.SaveChangesAsync();

            return Ok(adopcionEstado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdopcionEstadoExists(int id)
        {
            return db.AdopcionEstadoes.Count(e => e.Id == id) > 0;
        }
    }
}