using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaData.Models
{
    public class RegistroPedidosDetalle
    {

        public int Id { get; set; }

        public int IdRegistroPedido { get; set; }

        public double TotalPagado { get; set; }

        public DateTime FechaNovedad { get; set; }
        
    }
}
