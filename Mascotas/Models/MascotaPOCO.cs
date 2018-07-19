using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class MascotaPOCO
    {
        public MascotaPOCO() { }

        public MascotaPOCO(Mascota mas)
        {
            this.Id = mas.Id;
            this.nombre = mas.nombre;
            this.tamanioId = mas.tamañoId;
            this.sexo = mas.sexo;
            this.razaId = mas.razaId;
            this.observaciones = mas.observaciones;
            this.color = mas.color;
            this.caracter = mas.caracter;
            this.avatar = mas.avatar;
            this.fecha_nacimiento = mas.fecha_nacimiento;
        }

        public Mascota toDb()
        {
            return new Mascota()
            {
                Id = this.Id,
                nombre = this.nombre,
                tamañoId = this.tamanioId,
                sexo = this.sexo,
                razaId = this.razaId,
                observaciones = this.observaciones,
                color = this.color,
                caracter = this.caracter,
                avatar = this.avatar,
                fecha_nacimiento = this.fecha_nacimiento
            };
        }

        public int Id { get; set; }

        public Nullable<int> razaId { get; set; }
        public string razaDescripcion { get; set; }

        public string nombre { get; set; }
        public string sexo { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string edad
        {
            get
            {
                int dias = (int)(DateTime.Today - fecha_nacimiento.Value).TotalDays;
                int años = dias / 365;
                int meses = (dias % 365) / 31;

                switch (años)
                {
                    case 0: return string.Format("{0} Meses", meses);
                    case 1: return string.Format("{0} Año", años);
                    default: return string.Format("{0} Años", años);
                }
            }
        }
        public string color { get; set; }

        public Nullable<int> tamanioId { get; set; }
        public string tamanioDescripcion { get; set; }

        public string caracter { get; set; }
        public string observaciones { get; set; }
        public string avatar { get; set; }
        public string tipoContratoDescripcion { get; set; }
    }
}