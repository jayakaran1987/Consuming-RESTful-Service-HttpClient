using MovieInfo.Service.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Test
{
    [TestFixture]
    public class OmdbRequestTest
    {
        private IOmdbRequestService omdbService;

        [SetUp]
        public void SetUp()
        {
            this.omdbService = new OmdbRequestService();
        }
        [Test]

        // Test Case for SearchMovie - OmdbRequestService - Response True
        public void SearchMovieTest()
        {
            var target = omdbService.SearchMovie("Dragon");

            var result = Task.Run(() => target).Result;

            Assert.IsTrue(result.TotalResults > 0);
            Assert.IsNotNull(result.Search.First().Title);
            Assert.IsTrue(result.Search.Where(r => r.Title.ToLower().Contains("dragon")).Count() > 0);
            Assert.IsNotNull(result.Search.First().ImdbId);
            Assert.IsNotNull(result.Search.First().Type);
            Assert.IsNotNull(result.Search.First().Year);
        }

        // Test Case for SearchMovie - OmdbRequestService - Response False
        [Test]
        public void SearchMovieErrorReponseTest()
        {
            var target = omdbService.SearchMovie(" ");

            var result = Task.Run(() => target).Result;

            Assert.That(result.Response, Is.EqualTo(false));
            Assert.IsNotNull(result.Error);
        }

        // Test Case for GetMovieByIMDBIdTest - OmdbRequestService - Response True
        [Test]
        public void GetMovieByIMDBIdTest()
        {
            /*
             {"Title":"How to Train Your Dragon","Year":"2010","Rated":"PG","Released":"26 Mar 2010","Runtime":"98 min","Genre":"Animation, Adventure, 
             * Family","Director":"Dean DeBlois, Chris Sanders","Writer":"William Davies (screenplay), Dean DeBlois (screenplay), Chris Sanders (screenplay), C
             * ressida Cowell (book)","Actors":"Jay Baruchel, Gerard Butler, Craig Ferguson, America Ferrera","Plot":"A hapless young Viking who aspires to hunt dragons,
             * becomes the unlikely friend of a young dragon himself, and learns there may be more to the creatures than he assumed.","Language":"English","Country":"USA",
             * "Awards":"Nominated for 2 Oscars. Another 24 wins & 57 nominations.","Poster":"http://ia.media-imdb.com/images/M/MV5BMjA5NDQyMjc2NF5BMl5BanBnXkFtZTcwMjg5ODcyMw@@._V1_SX300.jpg",
             * "Metascore":"74","imdbRating":"8.2","imdbVotes":"450,613","imdbID":"tt0892769","Type":"movie","Response":"True"}
             
             */

            var target = omdbService.GetMovieByIMDBId("tt0892769");

            var result = Task.Run(() => target).Result;

            Assert.That(result.ImdbId, Is.EqualTo("tt0892769"));
            Assert.That(result.Year, Is.EqualTo("2010"));
            Assert.That(result.Title, Is.EqualTo("How to Train Your Dragon"));
            Assert.That(result.Type, Is.EqualTo("movie"));
        }

        // Test Case for GetMovieByIMDBIdTest - OmdbRequestService - Response False
        [Test]
        public void GetMovieByIMDBIdErrorReponseTest()
        {
            var target = omdbService.GetMovieByIMDBId(" ");

            var result = Task.Run(() => target).Result;

            Assert.That(result.Response, Is.EqualTo(false));
            Assert.IsNotNull(result.Error);
        }

        // Test Case for GetMovieByTitleTest - OmdbRequestService - Response True
        [Test]
        public void GetMovieByTitleTest()
        {
            /*
             * {"Title":"Enter the Dragon","Year":"1973","Rated":"R","Released":"19 Aug 1973","Runtime":"102 min","Genre":"Action, Crime, Drama","Director":"Robert Clouse",
             * "Writer":"Michael Allin","Actors":"Bruce Lee, John Saxon, Jim Kelly, Ahna Capri","Plot":"A martial artist agrees to spy on a reclusive crime lord using his invitation to
             * a tournament there as cover.","Language":"English, Cantonese","Country":"Hong Kong, USA","Awards":"1 win.",
             * "Poster":"http://ia.media-imdb.com/images/M/MV5BMTI0Mjg5MjgwNV5BMl5BanBnXkFtZTYwNjE1NjU5._V1_SX300.jpg","Metascore":"N/A","imdbRating":"7.7","imdbVotes":"74,865",
             * "imdbID":"tt0070034","Type":"movie","Response":"True"}
             */

            var target = omdbService.GetMovieByTitle("Enter the Dragon");

            var result = Task.Run(() => target).Result;

            Assert.That(result.ImdbId, Is.EqualTo("tt0070034"));
            Assert.That(result.Year, Is.EqualTo("1973"));
            Assert.That(result.Title, Is.EqualTo("Enter the Dragon"));
            Assert.That(result.Type, Is.EqualTo("movie"));
        }


        // Test Case for GetMovieByTitleTest - OmdbRequestService - Response False
        [Test]
        public void GetMovieByTitleErrorReponseTest()
        {
            var target = omdbService.GetMovieByTitle(" ");

            var result = Task.Run(() => target).Result;

            Assert.That(result.Response, Is.EqualTo(false));
            Assert.IsNotNull(result.Error);
        }
    }
}
