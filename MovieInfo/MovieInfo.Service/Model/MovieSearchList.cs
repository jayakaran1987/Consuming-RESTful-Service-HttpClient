using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Service.Model
{
    public class MovieSearchList
    {
        // defined from OMDb API
        public MovieSearch[] Search { get; set; }
        public int TotalResults { get; set; }
        public bool Response { get; set; }
        public string Error { get; set; }
    }

    public class MovieSearch
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
