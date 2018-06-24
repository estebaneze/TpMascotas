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
    public class PersonasController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Personas
        public IQueryable<PersonaPOCO> GetPersonas()
        {
            var persona = from per in db.Persona
                          select new PersonaPOCO
                          {
                                Id = per.Id,
                                dni = per.dni,
                                apellido = per.apellido,
                                nombre = per.nombre,
                                fecha_nacimiento = per.fecha_nacimiento,
                                cbu = per.cbu,
                                calificacion = per.calificacion,
                                localidadId = per.localidadId,
                                domicilio = per.domicilio,
                                email = per.email
                            };
            return persona;
        }

        [Route("GetPersonaDNI")]
        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        [ResponseType(typeof(PersonaPOCO))]
        public async Task<IHttpActionResult> GetPersonaDNI(string dni)
        {
            Persona persona = await db.Persona.Where(x => x.dni == dni).FirstOrDefaultAsync();

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(new PersonaPOCO(persona));
        }

        // GET: api/Personas/5
        [ResponseType(typeof(PersonaPOCO))]
        public async Task<IHttpActionResult> GetPersona(int id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(new PersonaPOCO(persona));
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersona(int id, PersonaPOCO personaParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personaParametro.Id)
            {
                return BadRequest();
            }

            db.Entry(personaParametro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        [ResponseType(typeof(PersonaPOCO))]
        public async Task<IHttpActionResult> PostPersona(PersonaPOCO personaParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persona = db.Persona.Add(personaParametro.toDb());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, new PersonaPOCO(persona));
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(PersonaPOCO))]
        public async Task<IHttpActionResult> DeletePersona(int id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Persona.Remove(persona);
            await db.SaveChangesAsync();

            return Ok(new PersonaPOCO(persona));
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Persona.Count(e => e.Id == id) > 0;
        }
    }
}