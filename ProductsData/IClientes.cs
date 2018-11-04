using System;
using System.Collections.Generic;
using System.Text;
using TiendaData.Models;

namespace TiendaData
{
    public interface IClientes
    {
        IEnumerable<Clientes> GetAll();
        Clientes GetById(int id);
        Clientes GetByCedula(int cedula);


        void Add(Clientes nuevoCliente);

        string GetNombresCliente(int cedula);
        int GetCedula(int id);

    }
}
