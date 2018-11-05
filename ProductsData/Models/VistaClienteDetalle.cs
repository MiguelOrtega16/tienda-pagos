using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TiendaData.Models
{
    public class VistaClienteDetalle
    {

        public int Id { get; set; }
        [DisplayName("Nombres")]
        public string PrimerNombre { get; set; }
        [DisplayName("Apellidos")]
        public string SegundoNombre { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DisplayName("Celular")]
        public string Celular { get; set; }
        [DisplayName("Cédula")]
        public int Cedula { get; set; }
        [DisplayName("Total Compras")]
        public int TotalComprasHechas { get; set; }
        [DisplayName("Pendiente por Pagar")]
        public int PendientePorPagar { get; set; }
        [DisplayName("Total Pagado")]
        public int TotalPagado { get;  set; }
    }
}
