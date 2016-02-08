using AutoMapper;
using MovieInfo.Service.Model;
using MovieInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieInfo.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Movie, MovieViewModel>();
            Mapper.CreateMap<MovieSearch, MovieViewModel>();
        }
    }
}