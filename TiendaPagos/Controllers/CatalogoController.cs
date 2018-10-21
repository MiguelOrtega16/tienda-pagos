using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TiendaData;
using TiendaPagos.Models.Catalogo;

namespace TiendaPagos.Controllers
{
    public class CatalogoController : Controller
    {
        private IProductosTienda _productos;
        public CatalogoController(IProductosTienda productos)
        {
            _productos = productos;
        }

        public IActionResult Index()
        {
            var productosModels = _productos.GetAll();

            var listarResultados = productosModels
                .Select(result => new ProductosIndexListingModel
                {
                    Id = result.Id,
                    UrlImagen = result.UrlImagen,
                    CantidadProductos = _productos.GetCantidadProducto(result.Id),
                    NombreProducto = _productos.GetNombreProducto(result.Id),
                    Costo = _productos.GetPrecioProducto(result.Id),
                    Capacidad = _productos.GetCapacidadProducto(result.Id),
                    Estado    = _productos.GetEstadoProducto(result.Id)

                });

            var model = new ProductosIndexModel
            {
                Productos = listarResultados
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var producto = _productos.GetById(id);

    

            var model = new ProductosDetailModel
            {
                IdProducto = id,
                NombreProducto = producto.NombreProducto,
                CantidadProductos = producto.CantidadProducto,
                Capacidad = producto.Capacidad,
                DescripcionProducto = producto.DescripcionProducto,
                Costo = producto.Costo,
                Estado = producto.Estados.Nombre,
                UrlImagen = producto.UrlImagen
            };
            return View(model);
        }
    }
}
