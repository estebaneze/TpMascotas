using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class LocalPOCO
    {
        public LocalPOCO() { }

        public LocalPOCO(Local loc)
        {
            this.Id = loc.Id;
            this.provinciaId = loc.provinciaId;
            this.localidadId = loc.localidadId;
            this.domicilio = loc.domicilio;
            this.razon_social = loc.razon_social;
        }

        public Local toDb()
        {
            return new Local()
            {
                Id = this.Id,
                provinciaId = this.provinciaId,
                localidadId = this.localidadId,
                domicilio = this.domicilio,
                razon_social = this.razon_social,
            };
        }

        public int Id { get; set; }
        public Nullable<int> provinciaId { get; set; }
        public Nullable<int> localidadId { get; set; }
        public string domicilio { get; set; }
        public string razon_social { get; set; }
    }
}