using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaData.Models;

namespace TiendaPagos.Models.Catalogo
{
    public class VentasUpdateModel : RegistroPedidos
    {
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public double AbonoPedido { get; set; }
        public IEnumerable<RegistroPedidosDetalle> registroPedidosDetalle { get; set; }
    }
}
