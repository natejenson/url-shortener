using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using url_shortener.DataAccess;

namespace url_shortener.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository UrlRepository;
        public UrlService(IUrlRepository urlRepository)
        {
            this.UrlRepository = urlRepository;
        }

        public Uri Get(Uri url)
        {
           return UrlRepository.Get(url);
        }

        public Uri ShortenAndSave(Uri original)
        {
            var shortened = new Uri("https://duckduckgo.com/?q=github");
            UrlRepository.Save(original, shortened);
            return shortened;
        }
    }
}
