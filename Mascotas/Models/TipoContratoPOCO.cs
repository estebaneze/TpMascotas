using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class TipoContratoPOCO
    {
        public TipoContratoPOCO() { }

        public TipoContratoPOCO(TipoContrato con)
        {
            this.Id = con.Id;
            this.terminos = con.terminos;
        }

        public TipoContrato toDb()
        {
            return new TipoContrato()
            {
                Id = this.Id,
                terminos = this.terminos
            };
        }

        public int Id { get; set; }
        public string terminos { get; set; }
    }
}