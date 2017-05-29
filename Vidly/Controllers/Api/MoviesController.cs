using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movies, MovieDto>);
        }

        // Get /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movies == null)
                return NotFound();

            return Ok(Mapper.Map<Movies, MovieDto>(movies));
        }

        // POST /api/moviess
        [HttpPost]
        public IHttpActionResult CreateMovies(MovieDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movies = Mapper.Map<MovieDto, Movies>(moviesDto);
            _context.Movies.Add(movies);
            _context.SaveChanges();

            moviesDto.id = movies.id;

            Uri uri;

            //Esta lógica falla. Se habría de revisar.
            if (Request.RequestUri.ToString().Last().Equals("/"))
            {
                uri = new Uri(Request.RequestUri + "" + movies.id);
            }
            else
            {
                uri = new Uri(Request.RequestUri + "/" + movies.id);
            }

            return Created(uri, moviesDto);
        }

        // PUT /api/moviess/1
        [HttpPut]
        public void UpdateMovies(int id, MovieDto moviesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var moviesInDb = _context.Movies.SingleOrDefault(c => c.id == id);

            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(moviesDto, moviesInDb);

            _context.SaveChanges();
        }

        // DELETE /api/moviess/1
        [HttpDelete]
        public void DeleteMovies(int id)
        {
            var moviesInDb = _context.Movies.SingleOrDefault(c => c.id == id);

            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(moviesInDb);
            _context.SaveChanges();
        }
    }
}
