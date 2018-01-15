using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Models;
using url_shortener.Services;

namespace url_shortener.Controllers
{
    [Produces("application/json")]
    [Route("api/shorten")]
    public class UrlShortenerController : Controller
    {
        private readonly IUrlService UrlService;
        public UrlShortenerController(IUrlService urlService)
        {
            this.UrlService = urlService;
        }

        // POST: api/shorten/
        [HttpPost]
        public IActionResult ShortenUrl([FromBody]string url)
        {
            // validate url
            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri parsedUrl))
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = 400,
                    Message = "Whoops! That doesn't appear to be a valid URL.",
                    Data = null
                });
            }
            var shortened = UrlService.ShortenAndSave(parsedUrl);
            return Ok(new ResponseModel
            {
                StatusCode = 200,
                Message = null,
                Data = new { url = shortened, original = url }
            });
        }
    }
}
