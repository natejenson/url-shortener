using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Services;

namespace url_shortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlService _urlService;
        public HomeController(IUrlService urlService)
        {
            this._urlService = urlService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/{path}")]
        public IActionResult GoToMapping(string path)
        {
            var mapped = _urlService.Get(path);
            if (mapped != null)
            {
                return new RedirectResult(mapped.ToString());
            }
            return NotFound();
        }
    }
}
