using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class DonacionPOCO
    {
        public DonacionPOCO() { }

        public DonacionPOCO(Donacion don)
        {
            this.Id = don.Id;
            this.personaId = don.personaId;
            this.mascotaId = don.mascotaId;
            this.fecha = don.fecha;
            this.monto = don.monto;
        }

        public Donacion toDb()
        {
            return new Donacion()
            {
                Id = this.Id,
                personaId = this.personaId,
                mascotaId = this.mascotaId,
                fecha = this.fecha,
                monto = this.monto
            };
        }

        public int Id { get; set; }
        public int personaId { get; set; }
        public int mascotaId { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<decimal> monto { get; set; }
    }
}