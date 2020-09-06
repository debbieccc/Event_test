using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestForEventRegister.Controllers
{
    public class BackCargoController : Controller
    {
        // GET: BackCargo
        public ActionResult Cargo_B()
        {
            dbEventSet db = new dbEventSet();
            var package = from t in (new dbEventSet()).tCargo
                          select t;
            return View(package);

            
        }

        public ActionResult Index()
        {            
            return View();
        }
    }
}