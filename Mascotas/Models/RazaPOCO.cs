using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class RazaPOCO
    {
        public RazaPOCO() { }

        public RazaPOCO(Raza raz)
        {
            this.Id = raz.Id;
            this.descripcion = raz.descripcion;
        }

        public Raza toDb()
        {
            return new Raza()
            {
                Id = this.Id,
                descripcion = this.descripcion
            };
        }

        public int Id { get; set; }
        public string descripcion { get; set; }
    }
}