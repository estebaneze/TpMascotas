using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class EstudioPOCO
    {
        public EstudioPOCO() { }

        public EstudioPOCO(Estudio est)
        {
            this.Id = est.Id;
            this.mascotaId = est.mascotaId;
            this.tipoEstudioId = est.tipoEstudioId;
            this.fecha_realizacion = est.fecha_realizacion;
            this.veterinarioId = est.veterinarioId;
            this.fecha_vencimiento = est.fecha_vencimiento;
            this.observaciones = est.observaciones;
        }

        public Estudio toDb()
        {
            return new Estudio()
            {
                Id = this.Id,
                mascotaId = this.mascotaId,
                tipoEstudioId = this.tipoEstudioId,
                fecha_realizacion = this.fecha_realizacion,
                veterinarioId = this.veterinarioId,
                fecha_vencimiento = this.fecha_vencimiento,
                observaciones = this.observaciones
            };
        }

        public int Id { get; set; }
        public int mascotaId { get; set; }
        public int tipoEstudioId { get; set; }
        public string tipoEstudioDescripcion { get; set; }
        public System.DateTime fecha_realizacion { get; set; }
        public Nullable<int> veterinarioId { get; set; }
        public string veterinarioNombreApellido { get; set; }
        public Nullable<System.DateTime> fecha_vencimiento { get; set; }
        public string observaciones { get; set; }
    }
}