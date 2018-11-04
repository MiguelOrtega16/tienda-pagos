using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TiendaData.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        [DisplayName("Nombres")]
        public string PrimerNombre { get; set; }
        [DisplayName("Apellidos")]
        public string SegundoNombre { get; set; }
        [DisplayName("Direccion")]
        public string Direccion { get; set; }
        [DisplayName("Celular")]
        public string Celular { get; set; }
        [DisplayName("Cédula")]
        public int Cedula { get; set; }
       // public virtual IdentificadorComprador IdentificadorComprador { get; set; }
      //  public virtual RegistroPedidos RegistroPedidos { get; set; }

    }
}
