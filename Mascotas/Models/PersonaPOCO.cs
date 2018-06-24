using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class PersonaPOCO
    {
        public PersonaPOCO() { }

        public PersonaPOCO(Persona per)
        {
            this.Id = per.Id;
            this.dni = per.dni;
            this.apellido = per.apellido;
            this.nombre = per.nombre;
            this.fecha_nacimiento = per.fecha_nacimiento;
            this.cbu = per.cbu;
            this.calificacion = per.calificacion;
            this.localidadId = per.localidadId;
            this.domicilio = per.domicilio;
            this.email = per.email;
        }

        public Persona toDb()
        {
            return new Persona()
            {
                Id = this.Id,
                dni = this.dni,
                apellido = this.apellido,
                nombre = this.nombre,
                fecha_nacimiento = this.fecha_nacimiento,
                cbu = this.cbu,
                calificacion = this.calificacion,
                localidadId = this.localidadId,
                domicilio = this.domicilio,
                email = this.email
            };      
        }

        public int Id { get; set; }
        public string dni { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string cbu { get; set; }
        public Nullable<double> calificacion { get; set; }
        public Nullable<int> localidadId { get; set; }
        public string domicilio { get; set; }
        public string email { get; set; }
    }
}