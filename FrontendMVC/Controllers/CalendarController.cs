using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontendMVC.Models;

namespace FrontendMVC.Controllers
{
    public class CalendarController : Controller
    {
        //
        // GET: /Calendar/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(Login login)
        {
            return View("Create", login);
        }


    }
}
