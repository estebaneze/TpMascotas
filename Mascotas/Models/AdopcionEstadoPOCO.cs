using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class AdopcionEstadoPOCO
    {
        public AdopcionEstadoPOCO() { }

        public AdopcionEstadoPOCO(AdopcionEstado ado)
        {
            this.Id = ado.Id;
            this.adopcionId = ado.adopcionId;
            this.estadoId = ado.estadoId;
        }

        public AdopcionEstado toDb()
        {
            return new AdopcionEstado()
            {
                Id = this.Id,
                adopcionId = this.adopcionId,
                estadoId = this.estadoId
            };
        }

        public int Id { get; set; }
        public int adopcionId { get; set; }
        public int estadoId { get; set; }
        public string estadoDescripcion { get; set; }
    }
}