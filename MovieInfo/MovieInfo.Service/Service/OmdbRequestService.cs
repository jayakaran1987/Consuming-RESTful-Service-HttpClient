using MovieInfo.Service.Core;
using MovieInfo.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Service.Service
{
    public class OmdbRequestService : BaseClient, IOmdbRequestService
    {
        // Also we can keep this api string web config App setting 
        public const string omdbUrl = "http://www.omdbapi.com/?";

        public OmdbRequestService()
            : base(omdbUrl)
        {
        }

        // Omdb Request goes here
        // Created some request like SearchMovie, GetMovieByIMDBId, GetMovieByTitle
        // We can create more in future Example - GetMovieByIMDBIdAndYear, GetMovieByTitleAndPlot, etc

        public Task<MovieSearchList> SearchMovie(string search)
        {
            // async method, client can use await
            // query string builded from OmdbQueryBuilder
            return ExtractDataFromAPI<MovieSearchList>(OmdbQueryBuilder.QueryBySearchDataTypeJson(search));
        }

        public Task<Movie> GetMovieByIMDBId(string imdbID)
        {
            return ExtractDataFromAPI<Movie>(OmdbQueryBuilder.QueryByImdbIdDataTypeJson(imdbID));
        }

        public Task<Movie> GetMovieByTitle(string title)
        {
            return ExtractDataFromAPI<Movie>(OmdbQueryBuilder.QueryByTitleDataTypeJson(title));
        }

    }
}
