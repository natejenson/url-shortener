using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace url_shortener.DataAccess
{
    public interface IUrlRepository
    {
        Uri Get(string path);

        /// <summary>
        /// Save the url mapping.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="url"></param>
        /// <returns>False if the path already exists, true otherwise.</returns>
        bool Save(string path, Uri url);
    }
}
