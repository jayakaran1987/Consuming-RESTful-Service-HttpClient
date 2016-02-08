using MovieInfo.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Service.Service
{
    public interface IOmdbRequestService
    {
        Task<MovieSearchList> SearchMovie(string search);
        Task<Movie> GetMovieByIMDBId(string imdbID);
        Task<Movie> GetMovieByTitle(string title);
    }
}
