using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaData;
using TiendaData.Models;
using TiendaPagos.Models.Catalogo;
using TiendaPagos.Models.Cliente;

namespace TiendaPagos.Controllers
{
    public class ClienteController : Controller
    {

        private IClientes _clientes;
        private IRegistroPedidos _pedidos;
        private IProductosTienda _productos;

        public  ClienteController(IClientes clientes, IRegistroPedidos pedidos, IProductosTienda productos)
        {
            _clientes = clientes;
            _pedidos = pedidos;
            _productos = productos;
        }

        public IActionResult Index()
        {
            var clientesModel = _clientes.GetAll();

            var model = new ClientesIndexModel
            {
                Clientes = clientesModel
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            // Todos los pedidos asociados a un Cliente
            var registroPedidos = _pedidos.GetRegistrosPorCliente(id)
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
                 ClientePedido = _clientes.GetById(id),
                 NombreProducto = _productos.GetNombreProducto(a.IdProducto)                 
             });

            //Información general del cliente
            var clienteModel = _clientes.GetVistaClienteDetallePorId(id);
            var model = new ClienteDetailModel
            {
                Id = clienteModel.Id,
                Cedula = clienteModel.Cedula,
                Celular = clienteModel.Celular,
                Direccion = clienteModel.Direccion,
                PrimerNombre = clienteModel.PrimerNombre,
                SegundoNombre = clienteModel.SegundoNombre,
                PendientePorPagar = clienteModel.PendientePorPagar,
                TotalComprasHechas = clienteModel.TotalComprasHechas,
                TotalPagado = clienteModel.TotalPagado,
                DetallePedidos = registroPedidos

            };
            return View(model);
        }
        
        [HttpPost]        
        public IActionResult ActualizarCliente (ClienteDetailModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteActualizar = new Clientes
                {
                    Cedula = cliente.Cedula,
                    Celular = cliente.Celular,
                    Direccion = cliente.Direccion,
                    PrimerNombre = cliente.PrimerNombre,
                    SegundoNombre    = cliente.SegundoNombre,
                    Id = cliente.Id
                };

                _clientes.ActualizarCliente(clienteActualizar);

                return RedirectToAction("Detail", "Cliente", new { id = cliente.Id });
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}