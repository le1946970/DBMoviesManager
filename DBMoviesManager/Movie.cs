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

        }
        public Movie(int id, string title, int year, int length, double rating, string image, string genre)
        {
            ID = id;
            Title = title;
            Year = year;
            Length = length;
            Rating = rating;
            Image = image;
            Genre = genre;
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
    }
}
