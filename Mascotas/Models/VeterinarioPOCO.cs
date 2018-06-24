using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class VeterinarioPOCO
    {
        public VeterinarioPOCO() { }

        public VeterinarioPOCO(Veterinario vet)
        {
            this.veterinarioId = vet.veterinarioId;
            this.matricula = vet.matricula;
            this.habilitados = vet.habilitados;
        }

        public Veterinario toDb()
        {
            return new Veterinario()
            {
                veterinarioId = this.veterinarioId,
                matricula = this.matricula,
                habilitados = this.habilitados
            };
        }

        public int veterinarioId { get; set; }
        public string matricula { get; set; }
        public Nullable<bool> habilitados { get; set; }
    }
}