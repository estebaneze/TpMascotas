using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class MultimediaPOCO
    {
        public MultimediaPOCO() { }

        public MultimediaPOCO(Multimedia mul)
        {
            this.Id = mul.Id;
            this.mascotaId = mul.mascotaId;
            this.tipo_archivo = mul.tipo_archivo;
            this.ruta = mul.ruta;
            this.fecha_publicacion = mul.fecha_publicacion;
        }

        public Multimedia toDb()
        {
            return new Multimedia()
            {
                Id = this.Id,
                mascotaId = this.mascotaId,
                tipo_archivo = this.tipo_archivo,
                ruta = this.ruta,
                fecha_publicacion = this.fecha_publicacion
            };
        }

        public int Id { get; set; }
        public int mascotaId { get; set; }
        public string tipo_archivo { get; set; }
        public string ruta { get; set; }
        public Nullable<System.DateTime> fecha_publicacion { get; set; }
    }
}