﻿using System;
using System.Collections.Generic;
using System.Text;
using TiendaData.Models;

namespace TiendaData
{
    public interface IProductosTienda
    {
        IEnumerable<Productos> GetAll();
        Productos GetById(int id);

        IEnumerable<CategoriaProducto> GetCategorias();

        void Add(Productos nuevoProducto);
        void RestarCantidadProducto(int id, int cantidadProducto);

        string GetNombreProducto(int id);
        int GetCantidadProducto(int id);
        string GetDescripcionProducto(int id);
        double GetPrecioProducto(int id);
        decimal GetCapacidadProducto(int id);
        string GetEstadoProducto(int id);



    }
}
