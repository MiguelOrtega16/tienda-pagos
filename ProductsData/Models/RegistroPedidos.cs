using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TiendaData.Models
{
    public class RegistroPedidos
    {
        public int Id { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int CantidadProducto { get; set; }

        [DisplayName("Total Pagado"), Required, Range(1, Int32.MaxValue)]
        public int TotalPagado { get; set; }

        [Required, Range(0, Int32.MaxValue)]
        public int PendientePorPagar { get; set; }

        [DisplayName("Total Compra"),Required, Range(1, Int32.MaxValue)]
        public int ValorTotalCompra { get; set; }

        [Required]
        public DateTime FechaNovedad { get; set; }

        public int IdEstado  { get; set; }

        public int Cedula { get; set; }

        // public virtual Clientes Cliente { get; set; }

         public virtual RegistroPedidosDetalle RegistroPedidosDetalle { get; set; }
    }
}
