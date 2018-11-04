using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using TiendaData;
using TiendaData.Models;
using ProductsData;
using System.Linq;

namespace TiendaServices
{
   public class ClientesService : IClientes
    {
        private TiendaContext _context;

        public ClientesService(TiendaContext context)
        {
            _context = context;
        }

        public void Add(Clientes nuevoCliente)
        {
            _context.Add(nuevoCliente);
            _context.SaveChanges();
        }

        public IEnumerable<Clientes> GetAll()
        {
            return _context.Clientes;
        }

        public Clientes GetByCedula(int cedula)
        {
            return GetAll()
                .FirstOrDefault(cliente => cliente.Cedula == cedula);
        }

        public Clientes GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(cliente => cliente.Id == id);
        }



        public int GetCedula(int id)
        {
            return GetById(id)
                .Cedula;
                
        }

        public string GetNombresCliente(int cedula)
        {
            var cliente = GetByCedula(cedula);
            return cliente.PrimerNombre + " " + cliente.SegundoNombre;

        }
    }
}
