using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaData;
using TiendaPagos.Models.Cliente;

namespace TiendaPagos.Controllers
{
    public class ClienteController : Controller
    {

        private IClientes _clientes;

        public  ClienteController(IClientes clientes)
        {
            _clientes = clientes;
        }

        public IActionResult Index()
        {
            var clientesModel = _clientes.GetAll();

            var model = new ClientesIndexModel
            {
                Clientes = clientesModel
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var clienteModel = _clientes.GetById(id);

            var model = new ClienteDetailModel
            {
                Clientes = clientesModel
            };

            return View(model);
        }
    }
}