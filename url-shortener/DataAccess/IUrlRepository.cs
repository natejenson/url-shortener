using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace url_shortener.DataAccess
{
    public interface IUrlRepository
    {
        bool Save(Uri original, Uri newUrl);
        bool Get(Uri url);
    }
}
