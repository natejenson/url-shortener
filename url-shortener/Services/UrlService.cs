using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using url_shortener.DataAccess;

namespace url_shortener.Services
{
    public class UrlService
    {
        private readonly IUrlRepository UrlRepository;
        public UrlService(IUrlRepository urlRepository)
        {
            this.UrlRepository = urlRepository;
        }

        // Shorten the given URL and save its mapping.
        public Uri ShortenAndSave(Uri original)
        {
            var shortened = new Uri("https://duckduckgo.com/?q=github");
            UrlRepository.Save(original, shortened);
            return shortened;
        }
    }
}
