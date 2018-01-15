using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Models;

namespace url_shortener.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/go/")]
        public IActionResult Redirect()
        {
            // TODO: get url Path as argument

            // TODO: create Url lookup service
            // TODO: lookup url path in data store

            // TODO: return 404 or redirect result

            return new RedirectResult("https://github.com/natejenson");
        }
    }
}
