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

        // POST: /shorten/
        [HttpPost]
        [Route("/")]
        public IActionResult ShortenUrl(string url)
        {
            var view = View("Index");
            // validate url
            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri parsedUrl))
            {
                ViewData["error"] = "Whoops! That doesn't appear to be a valid URL...";
                return view;
            }
            var shortened = _urlService.ShortenAndSave(parsedUrl);
            ViewData["shortened"] = shortened.AbsoluteUri.ToString();

            return view;
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
