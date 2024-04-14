using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil2.Model.Filehandlers
{
    internal class StockFileHandler
    {
        private const string StockFilepath = @"..\..\..\Storage\StockOverview.txt";


        public static void ReadBoardGamesFromTextFile(Overview overview)
        {
            var lines = File.ReadLines(StockFilepath).ToList();
            lines.RemoveAt(0);
           
                foreach (var line in lines)
                {
                    string[] values = line.Split(',');
                    try
                    {
                        BoardGame boardGame = new BoardGame(values[0].ToLower(), int.Parse(values[1]), values[2], int.Parse(values[3]), int.Parse(values[4]), values[5], int.Parse(values[6]), values[7]);
                        overview.AddToStock(boardGame);
                    }
                    catch (IndexOutOfRangeException) { }
                }
            
           
        }
        public static BoardGame WriteBoardGamesToTextFile(string name, int id, string genre, int min, int max, string state, int price, string status)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string CreateText = $"{name},{id},{genre},{min},{max},{state},{price},{status}";
            File.AppendAllText(StockFilepath, Environment.NewLine + CreateText);
            BoardGame boardGame = new BoardGame(name, id, genre, min, max, state, price, status);
            return boardGame;
        }

        public static void DeleteBoardGame(int id)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<string> savedGames = new List<string>();
            List<string> lines = File.ReadLines(StockFilepath).ToList();
            lines.RemoveAt(0);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                try
                {
                    if (int.Parse(values[1]) != id)
                    {
                        savedGames.Add(line);
                    }
                }
                catch (IndexOutOfRangeException) { }
            }

            File.WriteAllText(StockFilepath, "navn,id,genre,min,max,status,pris" + Environment.NewLine);

            foreach (string line in savedGames)
            {
                File.AppendAllText(StockFilepath,  line + Environment.NewLine);
            }
        }
    }
}
