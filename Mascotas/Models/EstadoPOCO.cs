using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class EstadoPOCO
    {
        public EstadoPOCO() { }

        public EstadoPOCO(Estado est)
        {
            this.Id = est.Id;
            this.descripcion = est.descripcion;
        }

        public Estado toDb()
        {
            return new Estado()
            {
                Id = this.Id,
                descripcion = this.descripcion
            };
        }

        public int Id { get; set; }
        public string descripcion { get; set; }
    }
}