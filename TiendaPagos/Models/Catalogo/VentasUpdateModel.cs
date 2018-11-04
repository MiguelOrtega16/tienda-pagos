using System.Collections.Generic;
using TiendaData.Models;

namespace TiendaPagos.Models.Catalogo
{
    public class VentasUpdateModel : RegistroPedidos
    {
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public double AbonoPedido { get; set; }
        public Clientes Cliente { get; set; }
        public IEnumerable<RegistroPedidosDetalle> RegistroPedidosDetalle { get; set; }
    }
}
