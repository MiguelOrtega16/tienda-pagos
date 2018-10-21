using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaData.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public int Cedula { get; set; }
       // public virtual IdentificadorComprador IdentificadorComprador { get; set; }
      //  public virtual RegistroPedidos RegistroPedidos { get; set; }

    }
}
