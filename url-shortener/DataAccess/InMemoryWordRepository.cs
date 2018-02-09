using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace url_shortener.DataAccess
{
    public class InMemoryWordRepository : IWordRepository
    {
        private readonly IList<string> _adjectives;
        private readonly IList<string> _nouns;
        public InMemoryWordRepository()
        {
            _adjectives = LoadJson("data/adjectives.json");
            _nouns = LoadJson("data/nouns.json");
        }

        public string RandomAdjective() => RandomWord(_adjectives);

        public string RandomNoun() => RandomWord(_nouns);

        private T RandomWord<T>(IList<T> collection)
        {
            return collection[new Random().Next(0, collection.Count)];
        }

        private IList<string> LoadJson(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<IList<string>>(json);
            }
        }
    }
}
