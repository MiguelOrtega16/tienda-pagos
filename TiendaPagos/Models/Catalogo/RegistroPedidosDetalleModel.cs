using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaData.Models;

namespace TiendaPagos.Models.Catalogo
{
    public class RegistroPedidosDetalleModel : RegistroPedidos
    {
        public Clientes ClientePedido { get; set; }
        public string NombreEstado { get; set; }

        
    }
}
