using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TiendaData.Models;

namespace TiendaPagos.Models.Pedidos
{
    public class AñadirVentaModel
    {
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public string UrlImagen { get; set; }
        public double PrecioProducto { get; set; }
        public int CantidadProductoDisponible { get; set; }
        public int CantidadComprada { get; set; }
        public Clientes Cliente { get; set; }
        [DisplayName("Total Compra")]
        public int ValorTotalCompra { get; set; }
        [DisplayName("Total Pagado")]
        public int ValorAbonado { get; set; }

    }
}
