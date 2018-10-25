using System;
using System.Collections.Generic;
using System.Text;
using TiendaData.Models;

namespace TiendaData
{
    public interface IRegistroPedidos
    {

        IEnumerable<RegistroPedidos> GetAll();

        
        void Add(RegistroPedidos nuevoRegistroPedidos);
        void ActualizarRegistroPedido(int idRegistroPedido, int abonoPago);
        //void ActualizarEstadoRegistroPedido(int idRegistroPedido, string nombreEstado);

        RegistroPedidos GetById(int idRegistroPedido);
        IEnumerable<RegistroPedidos> GetRegistrosPorProducto(int idProducto);
        IEnumerable<RegistroPedidos> GetRegistrosPorCliente(int idCliente);
        IEnumerable<RegistroPedidosDetalle> GetDetallePedido(int idPedido);



    }
}
