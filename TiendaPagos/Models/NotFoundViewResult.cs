using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TiendaPagos.Models
{
    public class NotFoundViewResult : ViewResult
    {
        public NotFoundViewResult(string viewName)
        {
            ViewName = viewName;
            StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}
