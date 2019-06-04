using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TiendaData;
using TiendaData.Models;
using TiendaPagos.Models;
using TiendaPagos.Models.Catalogo;
using TiendaPagos.Models.Pedidos;

namespace TiendaPagos.Controllers
{
    public class CatalogoController : Controller
    {
        private IProductosTienda _productos;
        private IRegistroPedidos _pedidos;
        private IClientes _clientes;

        public CatalogoController(IProductosTienda productos, IRegistroPedidos pedidos, IClientes clientes)
        {
            _productos = productos;
            _pedidos = pedidos;
            _clientes = clientes;
        }

        public IActionResult Index()
        {
            var productosModels = _productos.GetAll();
            var categoriasProductos = _productos.GetCategorias();

            var listarResultados = productosModels
                .Select(result => new ProductosIndexListingModel
                {
                    Id = result.Id,
                    UrlImagen = result.UrlImagen,
                    CantidadProductos = _productos.GetCantidadProducto(result.Id),
                    NombreProducto = _productos.GetNombreProducto(result.Id),
                    Costo = _productos.GetPrecioProducto(result.Id),
                    Capacidad = _productos.GetCapacidadProducto(result.Id),
                    Estado = _productos.GetEstadoProducto(result.Id),
                    Categoria =  result.CategoriaProducto

                });

            var model = new ProductosIndexModel
            {
                Categorias = categoriasProductos,
                Productos = listarResultados
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var producto = _productos.GetById(id);
            if (producto == null)
            {
                return new NotFoundViewResult("NotFound");
            }
            var registroPedidos = _pedidos.GetRegistrosPorProducto(id)
                .Select(a => new RegistroPedidosDetalleModel
                {
                    Id = a.Id,
                    Cedula = a.Cedula,
                    CantidadProducto = a.CantidadProducto,
                    IdEstado = a.IdEstado,
                    TotalPagado = a.TotalPagado,
                    PendientePorPagar = a.PendientePorPagar,
                    ValorTotalCompra = a.ValorTotalCompra,
                    FechaNovedad = a.FechaNovedad,
                    NombreEstado = _pedidos.GetNombreEstadoVentaById(a.IdEstado),
                    ClientePedido = _clientes.GetByCedula(a.Cedula)
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
                registroPedidosProductos = registroPedidos
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
                IdProducto = registroPedidos.IdProducto,
                descripcionProducto = descripcionProducto,
                CantidadProducto = registroPedidos.CantidadProducto,
                Cliente = _clientes.GetByCedula(registroPedidos.Cedula),
                IdEstado = registroPedidos.IdEstado,
                FechaNovedad = registroPedidos.FechaNovedad,
                nombreProducto = nombreProducto,
                PendientePorPagar = registroPedidos.PendientePorPagar,
                TotalPagado = registroPedidos.TotalPagado,
                ValorTotalCompra = registroPedidos.ValorTotalCompra,
                RegistroPedidosDetalle = listarDetallePedidos

            };
            return View(model);
        }

        public IActionResult AñadirVenta(int id)
        {
            var infoProducto = _productos.GetById(id);

            var model = new AñadirVentaModel
            {
                IdProducto = infoProducto.Id,
                descripcionProducto = infoProducto.DescripcionProducto,
                nombreProducto = infoProducto.NombreProducto,
                PrecioProducto = infoProducto.Costo,
                UrlImagen = infoProducto.UrlImagen,
                CantidadProductoDisponible = infoProducto.CantidadProducto
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AñadirAbonoVenta(int id, int abonoPedido)
        {
            _pedidos.ActualizarRegistroPedido(id, abonoPedido);
            return RedirectToAction("UpdateVenta", "Catalogo", new { id = id });
        }

        [HttpPost]
        public IActionResult GetDatosCliente(int cedulaId)
        {
            var cliente = _clientes.GetByCedula(cedulaId);
            return Json(cliente);

        }

        [HttpPost]
        public IActionResult GuardarVenta(AñadirVentaModel registroVenta)
        {

            var pendientePorPagar = registroVenta.ValorTotalCompra - registroVenta.ValorAbonado;
            string nombreEstado = (pendientePorPagar == 0) ? "Finalizado" : "Pendiente";
            var now = DateTime.Now;
            var estadoVenta = _pedidos.GetEstadoVenta(nombreEstado);

            var nuevaVenta = new RegistroPedidos
            {
                IdProducto = registroVenta.IdProducto,
                CantidadProducto = registroVenta.CantidadComprada,
                FechaNovedad = now,
                ValorTotalCompra = registroVenta.ValorTotalCompra,
                TotalPagado = registroVenta.ValorAbonado,
                PendientePorPagar = pendientePorPagar,
                IdEstado = estadoVenta,
                Cedula = registroVenta.Cliente.Cedula
            };
            _pedidos.Add(nuevaVenta);

            var nuevaVentaDetalle = new RegistroPedidosDetalle
            {
               IdRegistroPedido = nuevaVenta.Id,
               PendientePorPagar = pendientePorPagar,
               TotalPagado = registroVenta.ValorAbonado,
               FechaNovedad = now
            };
            
            _pedidos.AddDetalle(nuevaVentaDetalle);
            _productos.RestarCantidadProducto(registroVenta.IdProducto, registroVenta.CantidadComprada);

            return RedirectToAction("Detail", "Catalogo", new { id = registroVenta.IdProducto });
        }



    }


}

