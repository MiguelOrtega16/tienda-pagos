using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaData.Models;

namespace TiendaPagos.Models.Cliente
{
    public class ClienteDetailModel
    {
        public Clientes Cliente { get; set; }
        public int TotalComprasHechas { get; set; }
        public int UltimoProductoComprado { get; set; }
        public double PendientePorPagar { get; set; }
        public double TotalPagado { get; set; }

    }
}
