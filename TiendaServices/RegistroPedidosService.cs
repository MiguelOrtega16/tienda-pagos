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

    
        public IEnumerable<RegistroPedidos> GetAll()
        {
            return _context.RegistroPedidos
                  .Include(registroPedidos => registroPedidos.Cliente)
                  .Include(registroPedidos => registroPedidos.EstadosPedidos)
                  .Include(registroPedidos => registroPedidos.RegistroPedidosDetalle);
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
                .OrderBy(registroProducto => registroProducto.RegistroPedidosDetalle.FechaNovedad); ;
        }

        IEnumerable<RegistroPedidos> IRegistroPedidos.GetRegistrosPorCliente(int idCliente)
        {
            return GetAll()
                 .Where(registroProducto => registroProducto.Cliente.Cedula == idCliente || registroProducto.Cliente.Id == idCliente)
                 .OrderBy(registroProducto => registroProducto.RegistroPedidosDetalle.FechaNovedad); ;
        }

        public void ActualizarRegistroPedido(int idRegistroPedido)
        {
            throw new NotImplementedException();
        }
  
        private void ActualizarEstadoRegistroPedido(int idRegistroPedido, string nombreEstado)
        {
            var item = _context.RegistroPedidos
                  .FirstOrDefault(registroPedidos => registroPedidos.Id == idRegistroPedido);

            _context.Update(item);

            item.EstadosPedidos = _context.EstadosPedidos
                .FirstOrDefault(ep => ep.Nombre == nombreEstado);

            _context.SaveChanges();
        }
    }
}
