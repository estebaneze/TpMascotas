﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModeloDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MascotasEntities : DbContext
    {
        public MascotasEntities()
            : base("name=MascotasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adopcion> Adopcion { get; set; }
        public virtual DbSet<AdopcionEstado> AdopcionEstado { get; set; }
        public virtual DbSet<Donacion> Donacion { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estudio> Estudio { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Multimedia> Multimedia { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Raza> Raza { get; set; }
        public virtual DbSet<Tamaño> Tamaño { get; set; }
        public virtual DbSet<TipoContrato> TipoContrato { get; set; }
        public virtual DbSet<TipoEstudio> TipoEstudio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Veterinario> Veterinario { get; set; }
        public virtual DbSet<Visita> Visita { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
