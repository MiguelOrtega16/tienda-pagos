using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaPagos.Models.Catalogo
{
    public class ProductosIndexListingModel
    {
        public int Id { get; set; }
        public string UrlImagen { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProductos { get; set; }
        public double Costo { get; set; } 
        public decimal Capacidad { get; set; }
        public string Estado { get; set; }
    }
}
