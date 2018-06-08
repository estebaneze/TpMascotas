﻿using System;
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
    public class EstadoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Estadoes
        public IQueryable<Estado> GetEstadoes()
        {
            return db.Estadoes;
        }

        // GET: api/Estadoes/5
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> GetEstado(int id)
        {
            Estado estado = await db.Estadoes.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        // PUT: api/Estadoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstado(int id, Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado.Id)
            {
                return BadRequest();
            }

            db.Entry(estado).State = EntityState.Modified;

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

        // POST: api/Estadoes
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> PostEstado(Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estadoes.Add(estado);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = estado.Id }, estado);
        }

        // DELETE: api/Estadoes/5
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> DeleteEstado(int id)
        {
            Estado estado = await db.Estadoes.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            db.Estadoes.Remove(estado);
            await db.SaveChangesAsync();

            return Ok(estado);
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
            return db.Estadoes.Count(e => e.Id == id) > 0;
        }
    }
}