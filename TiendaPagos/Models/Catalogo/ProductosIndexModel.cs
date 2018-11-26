using System.Collections.Generic;
using TiendaData.Models;

namespace TiendaPagos.Models.Catalogo
{
    public class ProductosIndexModel
    {
        public IEnumerable<CategoriaProducto> Categorias { get; set; }

        public IEnumerable<ProductosIndexListingModel> Productos { get; set; }

    }
}
