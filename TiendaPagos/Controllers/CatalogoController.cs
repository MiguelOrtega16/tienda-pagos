using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TiendaData;
using TiendaData.Models;
using TiendaPagos.Models.Catalogo;

namespace TiendaPagos.Controllers
{
    public class CatalogoController : Controller
    {
        private IProductosTienda _productos;
        private IRegistroPedidos _pedidos;

        public CatalogoController(IProductosTienda productos, IRegistroPedidos pedidos)
        {
            _productos = productos;
            _pedidos = pedidos;
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
            var registroPedidos = _pedidos.GetRegistrosPorProducto(id)
                .Select(a => new RegistroPedidos
                {
                    Id = a.Id,
                    Cliente = a.Cliente,
                    CantidadProducto = a.CantidadProducto,
                    EstadosPedidos= a.EstadosPedidos,
                    TotalPagado = a.TotalPagado,
                    PendientePorPagar = a.PendientePorPagar,
                    ValorTotalCompra = a.ValorTotalCompra,
                    FechaNovedad = a.FechaNovedad              
                });


    

            var model = new ProductosDetailModel
            {
                IdProducto = id,
                NombreProducto = producto.NombreProducto,
                CantidadProductos = producto.CantidadProducto,
                Capacidad = producto.Capacidad,
                DescripcionProducto = producto.DescripcionProducto,
                Costo = producto.Costo,
                Estado = producto.Estados.Nombre,
                UrlImagen = producto.UrlImagen,
                registroPedidosProductos =  registroPedidos
            };
            return View(model);
        }

        public IActionResult UpdateVenta(int id)
        {

            var registroPedidos = _pedidos.GetById(id);

            var listarDetallePedidos = _pedidos.GetDetallePedido(id);
   
            var nombreProducto = _productos.GetNombreProducto(registroPedidos.IdProducto);

            var descripcionProducto = _productos.GetDescripcionProducto(registroPedidos.IdProducto);
 

            var model = new VentasUpdateModel
            {
               Id = registroPedidos.Id,
               IdProducto   = registroPedidos.IdProducto,
               descripcionProducto = descripcionProducto,
               CantidadProducto = registroPedidos.CantidadProducto,
               Cliente = registroPedidos.Cliente,
               EstadosPedidos = registroPedidos .EstadosPedidos,
               FechaNovedad = registroPedidos.FechaNovedad,
               nombreProducto = nombreProducto,
               PendientePorPagar = registroPedidos.PendientePorPagar,
               TotalPagado = registroPedidos.TotalPagado,
               ValorTotalCompra = registroPedidos.ValorTotalCompra,
               registroPedidosDetalle = listarDetallePedidos

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AñadirAbonoVenta( int id, int abonoPedido)
        {
            _pedidos.ActualizarRegistroPedido(id, abonoPedido);
            return RedirectToAction("Detail", id);
        }
  
    }


}

