using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Service.Core
{
    // Build QueryString for Url
    // Future -  Refactor this with NameValueCollection
    public static class OmdbQueryBuilder
    {
        private const string SEARCH= "s";
        private const string TITLE = "t";
        private const string IMDB_ID = "i";
        private const string DATA_TYPE= "r";
        private const string JSON= "json";
        private const string XML = "xml";
        public static string QueryBySearchDataTypeJson(string search)
        {
            return SEARCH + "=" + search + "&" + DATA_TYPE + "=" + JSON;
        }

        public static string QueryByImdbIdDataTypeJson(string imdbId)
        {
            return IMDB_ID + "=" + imdbId + "&" + DATA_TYPE + "=" + JSON;
        }

        public static string QueryByTitleDataTypeJson(string title)
        {
            return TITLE + "=" + title + "&" + DATA_TYPE + "=" + JSON;
        }

    }

    // Build QueryString for Url
    // Future -  Refactor this with NameValueCollection
}
