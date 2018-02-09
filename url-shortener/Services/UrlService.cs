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
            // TODO: This will get slow once a significant percentage of word-combos are taken.
            // Ideally, the UrlRepository would know which paths have been taken, and can produce
            // a unique one every time.
            while(true)
            {
                var randomPath = $"{_wordRepository.RandomAdjective()}-{_wordRepository.RandomNoun()}";
                if (_urlRepository.Save(randomPath, original))
                {
                    return new Uri(GetBaseUrl(), randomPath);
                }
            }
        }

        private Uri GetBaseUrl()
        {
            var req = _httpContextAccessor.HttpContext.Request;
            return new Uri($"{req.Scheme}://{req.Host}/");
        }
    }
}
