using Genspil2.Gui.Printer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Model.Seachers
{
    internal class StockSearcher
    {

        private static TextInfo textCulture = new CultureInfo("da-DK", false).TextInfo; // Change the culture to Danish
        public static void SeachForStockItem(Overview overview, string sortby,bool ascending)
        {
            List<BoardGame> boardGameToSearchCriteria = new List<BoardGame>();
            List<BoardGame> boardGameToExclude = new List<BoardGame>();

            //søgning udfra navn/_genre
            Console.WriteLine("Indtast navn/genre (eller efterlad tomt): ");
            string searchForGameName = Console.ReadLine().ToLower();
            
            if (String.IsNullOrWhiteSpace(searchForGameName) == false) // Hvis bruger indtaster et spilnavn
            {
                foreach (BoardGame boardGame in overview.BoardGameList)
                {
                    string genreName = textCulture.ToTitleCase(overview.GenreList.Find(x => x.ID == int.Parse(boardGame.Genre)).Name);
                    if (boardGame.Name.Contains(searchForGameName)) //tilføj spil der matcher søgekriterer udfra navn
                    {
                        boardGameToSearchCriteria.Add(boardGame); 
                    }
                    else if (genreName.Contains(searchForGameName)) //tilføj spil der matcher søgekriterer udfra _genre
                    { 
                        boardGameToSearchCriteria.Add(boardGame); 
                    }
                }
            }
            else  // Hvis bruger ikke indtaster et spilnavn tilføj alle spil
            {
                foreach (BoardGame boardGame in overview.BoardGameList)
                {
                     boardGameToSearchCriteria.Add(boardGame);  
                }
            }

            //søgning udfra pris 
            Console.WriteLine("Indtast makspris (eller efterlad tomt): ");
            string searchForPrice = Console.ReadLine().ToLower();

            if (String.IsNullOrWhiteSpace(searchForPrice) == false) // tjek om bruger har indtastet priskritere
            {
                int intsearchForPrice = int.Parse(searchForPrice); 
                foreach (BoardGame boardGame in boardGameToSearchCriteria)
                {
                    if (boardGame.Price > intsearchForPrice) // Hvis prisen på et spil er højere end den ønskede pris, tilføj spillet til excludelisten 
                    {
                        boardGameToExclude.Add(boardGame);
                    }
                }
            }

            // søgning udfra spillerantal 
            Console.WriteLine("Indtast spillerantal (eller efterlad tomt): ");
            string searchForPlayerNumber = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(searchForPlayerNumber) == false) // tjek om bruger har indtastet spillerkritere
            {
                int intsearchForPlayerNumber = int.Parse(searchForPlayerNumber);
                foreach (BoardGame boardGame in boardGameToSearchCriteria)
                {
                    if (boardGame.MinPlayers > intsearchForPlayerNumber || boardGame.MaxPlayers < intsearchForPlayerNumber) // Hvis spillet ikke matcher, tilføjes spillet til excludelisten 
                    {
                        boardGameToExclude.Add(boardGame);
                    }
                }
            }


            //slet alle spil på "boardGameToExclude" fra "boardGameToSearchCriteria" 
            foreach (BoardGame boardGame in boardGameToExclude)
            {
                boardGameToSearchCriteria.Remove(boardGame);
            }
            
            //Vis de spil der passer på søgekriterer 
            Console.Clear();
            if (boardGameToSearchCriteria.Count > 0)
            {
                StockPrinter.PrintStockOverview(boardGameToSearchCriteria, overview.GenreList, sortby, ascending, 1);
            }
            else { Console.WriteLine("Ingen spil matcher søgekritererne prøv igen !! "); }
            
        }
    }
}
