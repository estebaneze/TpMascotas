using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mascotas.Models
{
    public class UsuarioPOCO
    {
        public UsuarioPOCO() { }

        public UsuarioPOCO(Usuario usr)
        {
            this.usuarioId = usr.usuarioId;
            this.contraseña = usr.contraseña;
            this.habilitado = usr.habilitado;
            this.ultima_conexion = usr.ultima_conexion;
        }

        public Usuario toDb()
        {
            return new Usuario()
            {
                usuarioId= this.usuarioId,
                contraseña = this.contraseña,
                habilitado = this.habilitado,
                ultima_conexion = this.ultima_conexion
            };
        }

        public int usuarioId { get; set; }
        public string contraseña { get; set; }
        public Nullable<bool> habilitado { get; set; }
        public Nullable<System.DateTime> ultima_conexion { get; set; }
    }
}