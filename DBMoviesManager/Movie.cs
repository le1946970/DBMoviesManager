using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMoviesManager
{
    class Movie
    {
        public Movie()
        {
            ID = 0;
            Title = "";
            Year = 0;
            Length = "";
            Rating = 0;
            Image = "";
        }
        public Movie(int id, string title, int year, string length, double rating, string image)
        {
            ID = id;
            Title = title;
            Year = year;
            Length = length;
            Rating = rating;
            Image = image;
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Length { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        //public List<Genre> genreList { get; set; }
    }
}
