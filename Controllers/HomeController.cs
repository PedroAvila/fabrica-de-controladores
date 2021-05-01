using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabricaDeControladores.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;

        public HomeController(): this(new DefaultLogger())
        {

        }
        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        // GET: Home
        public ActionResult Index()
        {
            _logger.Write("En el método de acción Index...");
            return Content("Bienvenidos!!!");
        }
    }
}