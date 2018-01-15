using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace url_shortener.DataAccess
{
    public interface IUrlRepository
    {
        Uri Get(Uri url);

        /// <summary>
        /// Save the url mapping.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="newUrl"></param>
        /// <returns></returns>
        bool Save(Uri original, Uri newUrl);
    }
}
