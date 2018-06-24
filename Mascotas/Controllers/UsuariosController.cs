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
    public class UsuariosController : ApiController
    {
        private MascotasEntities db = new MascotasEntities();

        // GET: api/Usuarios
        public IQueryable<UsuarioPOCO> GetUsuarios()
        {
            var usuario = from usr in db.Usuario
                              select new UsuarioPOCO
                              {
                                    usuarioId = usr.usuarioId,
                                    contraseña = usr.contraseña,
                                    habilitado = usr.habilitado,
                                    ultima_conexion = usr.ultima_conexion,
                                };
            return usuario;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(UsuarioPOCO))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(new UsuarioPOCO(usuario));
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, UsuarioPOCO usuarioParmetro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioParmetro.usuarioId)
            {
                return BadRequest();
            }

            db.Entry(usuarioParmetro.toDb()).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(UsuarioPOCO))]
        public async Task<IHttpActionResult> PostUsuario(UsuarioPOCO usuarioParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = db.Usuario.Add(usuarioParametro.toDb());

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioExists(usuario.usuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuario.usuarioId }, new UsuarioPOCO(usuario));
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(UsuarioPOCO))]
        public async Task<IHttpActionResult> DeleteUsuario(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
            await db.SaveChangesAsync();

            return Ok(new UsuarioPOCO(usuario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.usuarioId == id) > 0;
        }
    }
}