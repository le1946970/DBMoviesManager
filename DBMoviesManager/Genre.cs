using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMoviesManager
{
    class Genre
    {
        public Genre()
        {
            Code = "";
            Name = "";
            Description = "";
        }
        public Genre(string code, string name, string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
