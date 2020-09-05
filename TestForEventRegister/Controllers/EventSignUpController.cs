using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestForEventRegister.Controllers
{
    public class EventSignUpController : Controller
    {
        // GET: EventSignUp
        public ActionResult Event()
        {
            dbEventSet db = new dbEventSet();
            var EventsFrount = from t in (new dbEventSet()).tEventSet
                         select t;
            return View(EventsFrount);
        }
    }
}