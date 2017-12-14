using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain
{
    public static class Synonyms
    {
        private static readonly Dictionary<string,List<string>> SynonymMap = new Dictionary<string, List<string>>
        {
            {"75 large", new List<string> {"$75"} }
        };
        public static List<string> GetSynonyms(string phrase)
        {
            return SynonymMap[phrase];
        }

        public static void UpdateSynonym(string phrase, string synonym)
        {
            SynonymMap[phrase] = new List<string>{synonym};
        }



    }
}
