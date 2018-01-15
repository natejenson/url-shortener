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

        public bool Get(Uri url)
        {
            throw new NotImplementedException();
        }

        public bool Save(Uri original, Uri newUrl)
        {
            throw new NotImplementedException();
        }
    }
}
