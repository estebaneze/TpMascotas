using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class AdopcionPOCO
    {
        public AdopcionPOCO() { }

        public AdopcionPOCO(Adopcion ado)
        {
            this.Id = ado.Id;
            this.personaId = ado.personaId;
            this.mascotaId = ado.mascotaId;
            this.fecha = ado.fecha;
            this.tipoContratoId = ado.tipoContratoId;
            this.personaAdoptaId = ado.personaAdoptaId;
        }

        public Adopcion toDb()
        {
            return new Adopcion()
            {
                Id = this.Id,
                personaId = this.personaId,
                mascotaId = this.mascotaId,
                fecha = this.fecha,
                tipoContratoId = this.tipoContratoId,
                personaAdoptaId = this.personaAdoptaId,
            };
        }

        public int Id { get; set; }
        
        public int personaId { get; set; }

        public string personaNombreyApellido { get; set; }


        public int personaAdoptaId { get; set; }

        public string personaAdoptaNombreyApellido { get; set; }

        public int mascotaId { get; set; }

        public string mascotaNombre { get; set; }

        public System.DateTime fecha { get; set; }

        public Nullable<int> tipoContratoId { get; set; }

        public string tipoContratoDescripcion { get; set; }
    }
}