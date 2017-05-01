using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneToMany.Data;
using OneToMany.Models;
using OneToMany.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToMany.API
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;

        [HttpGet]
        public List<Movie> Get()
        {
            List<Movie> movies = (from m in _db.Movies
                                  select new Movie
                                  {
                                      Id = m.Id,
                                      Title = m.Title,
                                      Director = m.Director,
                                      Genre = m.Genre
                                  }).ToList();
            return movies;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Movie mov = (from m in _db.Movies
                         where m.Id == id
                         select new Movie
                         {
                             Id = id,
                             Title = m.Title,
                             Director = m.Director,
                             Genre = m.Genre
                         }).FirstOrDefault();
            if (mov != null)
            {
                return Ok(mov);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] MovieWithGenreId movieFromView)
        {
            Movie movieToAdd = new Movie
            {
                Title = movieFromView.Title,
                Director = movieFromView.Director,
                Id = movieFromView.Id,
                Genre = (from g in _db.Genres
                         where g.Id == movieFromView.GenreId
                         select g).FirstOrDefault()
        };
            if (movieToAdd != null)
            {
                return BadRequest();
            }
            else
            {
                if (movieToAdd.Id == 0)
                {
                    _db.Movies.Add(movieToAdd);
                    _db.SaveChanges();
                    return Ok(movieToAdd);
                }
                else
                {
                    _db.Movies.Update(movieToAdd);
                    _db.SaveChanges();
                    return Ok(movieToAdd);
                }
            }

            //if (movieToAdd != null)
            //{
            //    _db.Movies.Add(movieToAdd);
            //    _db.SaveChanges();
            //    return Ok(movieToAdd);
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Movie movie = (from m in _db.Movies
                           where m.Id == id select m).FirstOrDefault();
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
                return Ok(movie);
            }
            else
            {
                return NotFound();
            }
        }
    public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
