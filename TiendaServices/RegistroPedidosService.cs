using Microsoft.EntityFrameworkCore;
using ProductsData;
using System;
using System.Collections.Generic;
using System.Linq;
using TiendaData;
using TiendaData.Models;

namespace TiendaServices
{
    public class RegistroPedidosService : IRegistroPedidos
    {
        private TiendaContext _context;

        public RegistroPedidosService(TiendaContext context)
        {
            _context = context;
        }

        public void Add(RegistroPedidos nuevoRegistroPedidos)
        {
            _context.Add(nuevoRegistroPedidos);
            _context.SaveChanges();
        }

        public void AddDetalle(RegistroPedidosDetalle nuevoRegistroPedidos)
        {
            _context.Add(nuevoRegistroPedidos);
            _context.SaveChanges();
        }


        public IEnumerable<RegistroPedidos> GetAll()
        {
            return _context.RegistroPedidos
                .Include(rp => rp.RegistroPedidosDetalle);
        }

        public RegistroPedidos GetById(int idRegistroPedido)
        {
            return GetAll()
                .FirstOrDefault(registroPedidos => registroPedidos.Id == idRegistroPedido);

        }

        IEnumerable<RegistroPedidos> IRegistroPedidos.GetRegistrosPorProducto(int idProducto)
        {
            return GetAll()
                .Where(registroProducto => registroProducto.IdProducto == idProducto)
                .OrderBy(registroProducto => registroProducto.FechaNovedad); 
        }

        IEnumerable<RegistroPedidos> IRegistroPedidos.GetRegistrosPorCliente(int idCliente)
        {
            return GetAll()
                 .Where(registroProducto => registroProducto.Cedula == idCliente )
                 .OrderBy(registroProducto => registroProducto.FechaNovedad); 
        }

        public int GetEstadoVenta(string nombreEstado)
        {
            return _context.EstadosPedidos
                .FirstOrDefault(ep => ep.Nombre == nombreEstado)
                .Id;
        }

        public string GetNombreEstadoVentaById(int id)
        {
            return _context.EstadosPedidos
                 .FirstOrDefault(ep => ep.Id == id)
                 .Nombre;
        }

        public IEnumerable<RegistroPedidosDetalle> GetDetallePedido(int idPedido)
        {
            return _context.RegistroPedidosDetalle
                .Where(detallePedido => detallePedido.IdRegistroPedido == idPedido);
        }


        public void ActualizarRegistroPedido(int idRegistroPedido, int abonoPago)
        {

            var item = GetById(idRegistroPedido);

            _context.Update(item);

            item.TotalPagado = item.TotalPagado + abonoPago;
            item.PendientePorPagar = item.PendientePorPagar - abonoPago ;

            // Actualiza el estado de la compra si se pagó el monto total
            if (item.TotalPagado == item.ValorTotalCompra)
            {
                ActualizarEstadoRegistroPedido(item, "Finalizado");
            }

            // Añade el registro de abono a la compra hecha con anterioridad
            AñadirTrazabilidadPagoRealizado(item.Id, abonoPago, item.PendientePorPagar);

            _context.SaveChanges();

    }

        private void AñadirTrazabilidadPagoRealizado(int idRegistroPedido, int abonoPago, int pendientePorPagar)
        {
            var now = DateTime.Now;

            var registroPedidoDetalle = new RegistroPedidosDetalle
            {
                IdRegistroPedido = idRegistroPedido,
                TotalPagado = abonoPago,
                FechaNovedad = now,
                PendientePorPagar = pendientePorPagar

            };

            _context.Add(registroPedidoDetalle);
        }

        private void ActualizarEstadoRegistroPedido(RegistroPedidos registroPedidoItem, string nombreEstado)
        {
            _context.Update(registroPedidoItem);

            registroPedidoItem.IdEstado = _context.EstadosPedidos
                .FirstOrDefault(ep => ep.Nombre == nombreEstado)
                .Id;

        }

      
    }
}
