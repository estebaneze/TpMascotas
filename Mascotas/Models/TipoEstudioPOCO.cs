using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class TipoEstudioPOCO
    {
        public TipoEstudioPOCO() { }

        public TipoEstudioPOCO(TipoEstudio est)
        {
            this.Id = est.Id;
            this.descripcion= est.descripcion;
            this.periodo_validez = est.periodo_validez;
        }

        public TipoEstudio toDb()
        {
            return new TipoEstudio()
            {
                Id = this.Id,
                descripcion = this.descripcion,
                periodo_validez = this.periodo_validez,
            };
        }

        public int Id { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> periodo_validez { get; set; }
    }
}