using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneToMany.Data;
using OneToMany.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToMany.API
{
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        private ApplicationDbContext _db;
        [HttpGet]
        public List<Genre> Get()
        {
            List<Genre> genres = (from g in _db.Genres select g).ToList();
            return genres;
        }
        //[HttpGet("{id}")]

        //public IActionResult Get(int id)
        //{
        //    Genre genre = (from g in _db.Genres where g.Id == id select g).FirstOrDefault();

        //    if (genre != null)
        //    {
        //        return Ok(genre);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        public GenresController(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
