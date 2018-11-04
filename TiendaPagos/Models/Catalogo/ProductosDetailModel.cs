using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaData.Models;

namespace TiendaPagos.Models.Catalogo
{
    public class ProductosDetailModel
    {
        public int IdProducto { get; set; }
        public string UrlImagen { get; set; }
        public string NombreProducto { get; set; }
        public decimal Capacidad { get; set; }
        public int CantidadProductos { get; set; }
        public double Costo { get; set; }
        public string DescripcionProducto { get; set; }
        public string Estado { get; set; }

        public IEnumerable<RegistroPedidosDetalleModel> registroPedidosProductos { get; set; }


    }

}
