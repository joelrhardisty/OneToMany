using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneToMany.ViewModels
{
    public class MovieWithGenreId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int GenreId { get; set; }
    }
}
    