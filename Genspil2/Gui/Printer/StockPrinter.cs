using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Printer
{
    internal class StockPrinter
    {
        private static TextInfo textCulture = new CultureInfo("da-DK", false).TextInfo; // Change the culture to Danish
        private static double showPrPage = 10;
        private static int standardColumnWidth = 20;
        private static int wideColumnWidth = 35;
        private static int narrowColumnWidth = 10;
        public static void PrintStockOverview(List<BoardGame> boardGames, List<Genre> genres, string sortBy, bool ascending, int pageNumber)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("oversigt over brætspil:");

            //TOP linje
            Console.WriteLine("┌".PadRight(wideColumnWidth, '─') + "┬".PadRight(standardColumnWidth, '─') + "┬".PadRight(standardColumnWidth, '─') + "┬".PadRight(standardColumnWidth, '─') + "┬".PadRight(narrowColumnWidth, '─') + "┬".PadRight(narrowColumnWidth, '─') + "┬".PadRight(standardColumnWidth, '─') + "┐");
            //Sortering
            PrintSorting(sortBy, ascending);

            if (sortBy == "n" && ascending == true)
            {
                int i = 0;
                foreach (BoardGame boardGame in boardGames.OrderBy(x => x.Name))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintGameInfo(boardGame, genres);
                    }
                    i++;
                }
            }
            else if (sortBy == "n" && ascending == false)
            {
                int i = 0;
                foreach (BoardGame boardGame in boardGames.OrderByDescending(x => x.Name))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintGameInfo(boardGame, genres);
                    }
                    i++;
                }
            }
            else if (sortBy == "g" && ascending == true)
            {
                int i = 0;
                foreach (BoardGame boardGame in boardGames.OrderBy(x => genres.First(g => g.ID == int.Parse(x.Genre)).Name ))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintGameInfo(boardGame, genres);
                    }
                    i++;
                }
            }
            else if (sortBy == "g" && ascending == false)
            {
                int i = 0;
                foreach (BoardGame boardGame in boardGames.OrderByDescending(x => genres.First(g => g.ID == int.Parse(x.Genre)).Name))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    { PrintGameInfo(boardGame, genres); }
                    i++;
                }
            }
            else if (sortBy == "p" && ascending == true)
            {
                int i = 0;
                foreach (BoardGame boardGame in boardGames.OrderBy(x => x.Price))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintGameInfo(boardGame, genres);
                    }
                    i++;
                }
            }
            else if (sortBy == "p" && ascending == false)
            {
                int i = 0;
                foreach (BoardGame boardGame in boardGames.OrderByDescending(x => x.Price))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintGameInfo(boardGame, genres);
                    }
                    i++;
                }
            }

            else if (sortBy == "i" && ascending == true)
            {
                int i = 0;
                foreach (BoardGame boardGame in boardGames.OrderBy(x => x.ID))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintGameInfo(boardGame, genres);
                    }
                    i++;
                }
            }
            else if (sortBy == "i" && ascending == false)
            {
                int i = 0;
                foreach (BoardGame boardGame in boardGames.OrderByDescending(x => x.ID))
                {
                    if (i < (showPrPage * pageNumber) && i >= (showPrPage * pageNumber) - showPrPage)
                    {
                        PrintGameInfo(boardGame, genres);
                    }
                    i++;
                }
            }

            //Bund linje
            Console.WriteLine("└".PadRight(wideColumnWidth, '─') + "┴".PadRight(standardColumnWidth, '─') + "┴".PadRight(standardColumnWidth, '─') + "┴".PadRight(standardColumnWidth, '─') + "┴".PadRight(standardColumnWidth, '─') + "┴".PadRight(standardColumnWidth, '─') + "┘");

            Instructionprinter.PrintPagening(boardGames.Count, showPrPage, pageNumber);
            
            Instructionprinter.PrintInstructions("spil");
            Instructionprinter.PrintSorteringInstruktions(" n: sorter efter navn, g:sorter efter genre, p: sorter efter pris, i: sorter efter ID");

        }
        public static void PrintSorting(string sortBy, bool ascending)
        {
            StringBuilder sb = new StringBuilder();

            //sorteret efter navn
            if (sortBy == "n" && ascending == true)
            {
                sb.Append("│Navn ∆".PadRight(wideColumnWidth));
            }
            else if (sortBy == "n" && ascending == false)
            {
                sb.Append("│Navn ∇".PadRight(wideColumnWidth));
            }
            else { sb.Append("│Navn ".PadRight(wideColumnWidth)); }

            //sorteret efter _genre
            if (sortBy == "g" && ascending == true)
            {
                sb.Append("│Genre ∆ ".PadRight(standardColumnWidth));
            }
            else if (sortBy == "g" && ascending == false)
            {
                sb.Append("│Genre ∇".PadRight(standardColumnWidth));
            }
            else { sb.Append("│Genre".PadRight(standardColumnWidth)); }

            sb.Append("│Stand".PadRight(standardColumnWidth) + "│Antal spillere".PadRight(standardColumnWidth));

            //sorteret efter pris
            if (sortBy == "p" && ascending == true)
            {
                sb.Append("│Pris ∆ ".PadRight(narrowColumnWidth));
            }
            else if (sortBy == "p" && ascending == false)
            {
                sb.Append("│Pris ∇".PadRight(narrowColumnWidth));
            }
            else { sb.Append("│Pris".PadRight(narrowColumnWidth)); }

            //sorteret efter ID
            if (sortBy == "i" && ascending == true)
            {
                sb.Append("│ID ∆".PadRight(narrowColumnWidth));
            }
            else if (sortBy == "i" && ascending == false)
            {
                sb.Append("│ID ∇".PadRight(narrowColumnWidth));
            }
            else { sb.Append("│ID ".PadRight(narrowColumnWidth)); }

            sb.Append( "│status".PadRight(standardColumnWidth) + "│");
            Console.WriteLine(sb);
        }

        private static void PrintGameInfo(BoardGame boardGame, List<Genre> genres)
        {
            string name = textCulture.ToTitleCase(boardGame.Name);
            string genreName = textCulture.ToTitleCase(genres.Find(x => x.ID == int.Parse(boardGame.Genre)).Name);
            Console.WriteLine("├".PadRight(wideColumnWidth, '─') + "┼".PadRight(standardColumnWidth, '─') + "┼".PadRight(standardColumnWidth, '─') + "┼".PadRight(standardColumnWidth, '─') + "┼".PadRight(narrowColumnWidth, '─') + "┼".PadRight(narrowColumnWidth, '─') + "┼".PadRight(standardColumnWidth, '─') + "┤");
            Console.WriteLine($"│{name} ".PadRight(wideColumnWidth) + $"│{genreName}".PadRight(standardColumnWidth) + $"│{boardGame.State}".PadRight(standardColumnWidth) + $"│{boardGame.MinPlayers} - {boardGame.MaxPlayers}".PadRight(standardColumnWidth) + $"│{boardGame.Price} kr.".PadRight(narrowColumnWidth) + $"│{boardGame.ID}".PadRight(narrowColumnWidth) + $"│{boardGame.Availability}".PadRight(standardColumnWidth) + "│");
        }
    }
}

