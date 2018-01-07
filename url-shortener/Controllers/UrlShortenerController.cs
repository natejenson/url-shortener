using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Models;

namespace url_shortener.Controllers
{
    [Produces("application/json")]
    [Route("api/shorten")]
    public class UrlShortenerController : Controller
    {   
        // POST: api/shorten/
        [HttpPost]
        public IActionResult Post([FromBody]string url)
        {
            // validate url
            Uri parsedUrl;
            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out parsedUrl))
            {
                return new ObjectResult(new ResponseModel
                {
                    StatusCode = 400,
                    Message = "Whoops! That doesn't appear to be a valid URL.",
                    Data = null
                });
            }
            return new ObjectResult(new ResponseModel
            {
                StatusCode = 200,
                Message = null,
                Data = new { url = parsedUrl, original = url }
            });
        }

        public Uri Shorten(Uri url)
        {
            return new Uri("https://duckduckgo.com/?q=github");
        }
    }
}
