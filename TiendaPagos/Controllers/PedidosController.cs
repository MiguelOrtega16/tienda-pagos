using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaPagos.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaPagos.Controllers
{
    public class PedidosController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
    
            return new NotFoundViewResult("ComingSoon");
        }
    }
}
