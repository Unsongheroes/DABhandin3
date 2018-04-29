using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAB33.DAL;
using DAB33.Models;

namespace DAB33.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var uow = new UnitOfWork<Person>().InitializeDatabase();
            return View();
        }
    }
}
