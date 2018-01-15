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

        public Uri Get(string path)
        {
           return UrlRepository.Get(path);
        }

        public Uri ShortenAndSave(Uri original)
        {
            var baseUrl = new Uri("http://localhost:50178/");
            var randomPath = "fancy-unicorn";
            var shortened = new Uri(baseUrl, randomPath);
            UrlRepository.Save(randomPath, original);
            return shortened;
        }
    }
}
