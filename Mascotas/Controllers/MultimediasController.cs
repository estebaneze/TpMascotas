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
    public class MultimediasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Multimedias
        public IQueryable<Multimedia> GetMultimedias()
        {
            return db.Multimedias;
        }

        // GET: api/Multimedias/5
        [ResponseType(typeof(Multimedia))]
        public async Task<IHttpActionResult> GetMultimedia(int id)
        {
            Multimedia multimedia = await db.Multimedias.FindAsync(id);
            if (multimedia == null)
            {
                return NotFound();
            }

            return Ok(multimedia);
        }

        // PUT: api/Multimedias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMultimedia(int id, Multimedia multimedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != multimedia.Id)
            {
                return BadRequest();
            }

            db.Entry(multimedia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultimediaExists(id))
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

        // POST: api/Multimedias
        [ResponseType(typeof(Multimedia))]
        public async Task<IHttpActionResult> PostMultimedia(Multimedia multimedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Multimedias.Add(multimedia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = multimedia.Id }, multimedia);
        }

        // DELETE: api/Multimedias/5
        [ResponseType(typeof(Multimedia))]
        public async Task<IHttpActionResult> DeleteMultimedia(int id)
        {
            Multimedia multimedia = await db.Multimedias.FindAsync(id);
            if (multimedia == null)
            {
                return NotFound();
            }

            db.Multimedias.Remove(multimedia);
            await db.SaveChangesAsync();

            return Ok(multimedia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MultimediaExists(int id)
        {
            return db.Multimedias.Count(e => e.Id == id) > 0;
        }
    }
}