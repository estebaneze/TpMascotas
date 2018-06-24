using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class TamañoPOCO
    {
        public TamañoPOCO() { }

        public TamañoPOCO(Tamaño tam)
        {
            this.Id = tam.Id;
            this.descripcion = tam.descripcion;
        }

        public Tamaño toDb()
        {
            return new Tamaño()
            {
                Id = this.Id,
                descripcion = this.descripcion
            };
        }

        public int Id { get; set; }
        public string descripcion { get; set; }
    }
}