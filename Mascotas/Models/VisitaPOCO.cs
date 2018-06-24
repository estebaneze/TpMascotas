using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class VisitaPOCO
    {
        public VisitaPOCO() { }

        public VisitaPOCO(Visita vis)
        {
            this.Id = vis.Id;
            this.veterinarioId = vis.veterinarioId;
            this.mascotaId = vis.mascotaId;
            this.fecha = vis.fecha;
            this.monto = vis.monto;
        }

        public Visita toDb()
        {
            return new Visita()
            {
                Id = this.Id,
                veterinarioId = this.veterinarioId,
                mascotaId = this.mascotaId,
                fecha = this.fecha,
                monto = this.monto
            };
        }

        public int Id { get; set; }
        public int veterinarioId { get; set; }
        public int mascotaId { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<decimal> monto { get; set; }
    }
}