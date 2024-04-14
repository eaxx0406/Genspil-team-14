using Genspil2.Model.Filehandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Destroyer
{
    internal class GameDestroyer
    {
        public static void DestoyGame(Overview overview) {
            Console.WriteLine("Indtast spilID for at slette");
            try
            {
                int id = Int32.Parse(Console.ReadLine());
                StockFileHandler.DeleteBoardGame(id);
                overview.RemoveFromStock(id);
            }
            catch (FormatException) { Console.WriteLine("Indtast et tal"); }
        }
    }
}
