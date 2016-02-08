using AutoMapper;
using MovieInfo.Service.Model;
using MovieInfo.Service.Service;
using MovieInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieInfo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOmdbRequestService _omdpService;
        public HomeController(IOmdbRequestService omdpService)
        {
            // Dependency Injection
            _omdpService = omdpService;
        }
        public ActionResult Index()
        {
            return View();
        }

        // In future we can replace this with API Controller 
        // Curenttly Angular Client call this method and return Json result
        // Used AutoMapper for Mapping
        public async Task<ActionResult> SearchMovieDetails(string searchTerm)
        {
            try
            {
                var result = await _omdpService.SearchMovie(searchTerm);
                return Json(Mapper.Map<IEnumerable<MovieSearch>, IEnumerable<MovieViewModel>>(result.Search), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }


        public async Task<ActionResult> SearchMovieDetailsForListView(string searchTerm)
        {
            try
            {
                if (searchTerm != null && searchTerm != "")
                {
                    var result = await _omdpService.SearchMovie(searchTerm);
                    return Json(Mapper.Map<IEnumerable<MovieSearch>, IEnumerable<MovieViewModel>>(result.Search), JsonRequestBehavior.AllowGet);
                }
                else 
                {
                    // Defalt loading page 
                    // In future we can replace with New Movies / Latest Movies
                    var result = await _omdpService.SearchMovie("Bat");
                    return Json(Mapper.Map<IEnumerable<MovieSearch>, IEnumerable<MovieViewModel>>(result.Search), JsonRequestBehavior.AllowGet);
                }
              
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
           
        }

        [HttpPost]
        public async Task<ActionResult> GetMovieById(string ImdbId)
        {
            try
            {
                var result = await _omdpService.GetMovieByIMDBId(ImdbId);
                return Json(Mapper.Map<Movie, MovieViewModel>(result), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
           
        }

        


    }
}