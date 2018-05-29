//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Adopcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adopcion()
        {
            this.AdopcionEstado = new HashSet<AdopcionEstado>();
        }
    
        public int Id { get; set; }
        public int personaId { get; set; }
        public int mascotaId { get; set; }
        public int personaAdoptaId { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<int> tipoContratoId { get; set; }
    
        public virtual Mascota Mascota { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Persona Persona1 { get; set; }
        public virtual TipoContrato TipoContrato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdopcionEstado> AdopcionEstado { get; set; }
    }
}
