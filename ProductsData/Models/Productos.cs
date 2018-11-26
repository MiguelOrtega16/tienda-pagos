using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TiendaData.Models
{
   public class Productos
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        [Required]
        public Estados Estados { get; set; }

        [Required]
        public double Costo { get; set; }

        [Required]
        public decimal Capacidad { get; set; }

        [Required]
        public int CantidadProducto{ get; set; }

        public string UrlImagen { get; set; }

        [Required]
        public string DescripcionProducto { get; set; }

        public CategoriaProducto CategoriaProducto { get; set; }

    }
}
