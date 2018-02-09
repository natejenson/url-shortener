using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using url_shortener.DataAccess;

namespace url_shortener.Services
{
    public class UrlService : IUrlService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlRepository _urlRepository;
        private readonly IWordRepository _wordRepository;
        public UrlService(IHttpContextAccessor httpContextAccessor,
            IUrlRepository urlRepository, 
            IWordRepository wordRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _urlRepository = urlRepository;
            _wordRepository = wordRepository;
        }

        public Uri Get(string path)
        {
           return _urlRepository.Get(path);
        }

        public Uri ShortenAndSave(Uri original)
        {
            var randomPath = $"{_wordRepository.RandomAdjective()}-{_wordRepository.RandomNoun()}";
            var shortened = new Uri(GetBaseUrl(), randomPath);
            _urlRepository.Save(randomPath, original);
            return shortened;
        }

        private Uri GetBaseUrl()
        {
            var req = _httpContextAccessor.HttpContext.Request;
            return new Uri($"{req.Scheme}://{req.Host}/");
        }
    }
}
