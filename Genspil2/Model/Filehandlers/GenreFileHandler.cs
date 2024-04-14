using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Model.Filehandlers
{
    internal class GenreFileHandler
    {
        private const string GenreFilepath = @"..\..\..\Storage\Genres.txt";
        public static void ReadGenresFromTextFile(Overview overview)
        {
            var lines = File.ReadLines(GenreFilepath).ToList();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                Genre genre= new Genre(values[1].ToLower(), int.Parse(values[0]));
                overview.GenreList.Add(genre);
            }
        }


    }
}
