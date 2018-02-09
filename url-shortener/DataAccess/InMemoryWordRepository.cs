using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace url_shortener.DataAccess
{
    public class InMemoryWordRepository : IWordRepository
    {
        public string RandomAdjective()
        {
            return "fancy";
        }

        public string RandomNoun()
        {
            return "unicorn";
        }
    }
}
