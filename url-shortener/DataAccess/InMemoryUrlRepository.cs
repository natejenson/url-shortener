using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace url_shortener.DataAccess
{
    public class InMemoryUrlRepository : IUrlRepository
    {
        private ConcurrentDictionary<string, string> repo;

        public InMemoryUrlRepository()
        {
            this.repo = new ConcurrentDictionary<string, string>();
        }

        public Uri Get(Uri url)
        {
            throw new NotImplementedException();
        }

        public bool Save(Uri original, Uri newUrl)
        {
            if(!repo.TryAdd(original.ToString(), newUrl.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
