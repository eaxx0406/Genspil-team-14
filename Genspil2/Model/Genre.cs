using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Model
{
    internal class Genre
    {
        public Genre(string name, int id)
        {
            Name = name;
            ID = id;
        }
        public int ID { get;}
        public string Name { get;}    
    }
}
