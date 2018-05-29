using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Mascotas.Models
{
    // Para agregar datos de perfil al usuario, agregue más propiedades a la clase ApplicationUser. Para obtener más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ModeloDatos.Mascota> Mascotas { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Raza> Razas { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Tamaño> Tamaño { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Veterinario> Veterinarios { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Persona> Personas { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Localidad> Localidads { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Estudio> Estudios { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.TipoEstudio> TipoEstudios { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Visita> Visitas { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Adopcion> Adopcions { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.TipoContrato> TipoContratoes { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.AdopcionEstado> AdopcionEstadoes { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Estado> Estadoes { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Donacion> Donacions { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Local> Locals { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Provincia> Provincias { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Multimedia> Multimedias { get; set; }
    }
}