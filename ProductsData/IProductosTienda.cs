using System;
using System.Collections.Generic;
using System.Text;
using TiendaData.Models;

namespace TiendaData
{
    public interface IProductosTienda
    {
        IEnumerable<Productos> GetAll();
        Productos GetById(int id);

        void Add(Productos nuevoProducto);

        string GetNombreProducto(int id);
        int GetCantidadProducto(int id);
        double GetPrecioProducto(int id);
        decimal GetCapacidadProducto(int id);
        string GetEstadoProducto(int id);

        

    }
}
