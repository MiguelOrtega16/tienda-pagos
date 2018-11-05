using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaData.Models;
using TiendaPagos.Models.Catalogo;

namespace TiendaPagos.Models.Cliente
{
    public class ClienteDetailModel : VistaClienteDetalle
    {
        public IEnumerable<RegistroPedidosDetalleModel> DetallePedidos { get; set; }
    }
}
