using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class LocalidadPOCO
    {
        public LocalidadPOCO() { }

        public LocalidadPOCO(Localidad loc)
        {
            this.Id = loc.Id;
            this.provinciaId = loc.provinciaId;
            this.nombre = loc.nombre;
        }

        public Localidad toDb()
        {
            return new Localidad()
            {
                Id = this.Id,
                provinciaId = this.provinciaId,
                nombre = this.nombre
            };
        }

        public int Id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> provinciaId { get; set; }
        public string provinciaNombre { get; set; }
    }
}