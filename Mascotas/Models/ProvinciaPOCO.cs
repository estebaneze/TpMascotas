using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class ProvinciaPOCO
    {
        public ProvinciaPOCO() { }

        public ProvinciaPOCO(Provincia pro)
        {
            this.Id = pro.Id;
            this.nombre = pro.nombre;
        }

        public Provincia toDb()
        {
            return new Provincia()
            {
                Id = this.Id,
                nombre = this.nombre
            };
        }

        public int Id { get; set; }
        public string nombre { get; set; }
    }
}