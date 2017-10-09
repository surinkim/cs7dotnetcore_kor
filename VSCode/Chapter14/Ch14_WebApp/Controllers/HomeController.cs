using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ch14_WebApp.Models;
using Packt.CS7;

namespace Ch14_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private Northwind db;
        public HomeController(Northwind injectedContext)
        {
            db = injectedContext;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                VisitorCount = (new Random()).Next(1, 1001),
                Products = db.Products.ToArray()
            };
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
