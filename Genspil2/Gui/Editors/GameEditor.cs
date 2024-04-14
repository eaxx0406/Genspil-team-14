using Genspil2.Model.Filehandlers;
using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Linq;

namespace Genspil2.Gui.Editors
{
    internal class GameEditor
    {
        public static void EditGame(Overview overview)
        {
            //find spil der skal redigeres 
            Console.WriteLine("Indtast spilId ");
            try
            {
                int id = int.Parse(Console.ReadLine());

                BoardGame boardGame = overview.BoardGameList.FirstOrDefault(c => c.ID == id);

                if (boardGame != null) //kunde fundet
                {
                    //rediger navn
                    Console.WriteLine("Indtast navn");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(boardGame.Name);
                    int cursorheight = Console.CursorTop;
                    Console.SetCursorPosition(0, cursorheight);
                    Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                    string changeNameToo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(changeNameToo) == false)
                    {
                        boardGame.Name = changeNameToo;
                    }

                    //rediger Genre 
                    Console.WriteLine("Indtast genre");
                    foreach (Genre genre in overview.GenreList)
                    {
                        Console.WriteLine(genre.ID + ": " + genre.Name);
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(boardGame.Genre);
                    cursorheight = Console.CursorTop;
                    Console.SetCursorPosition(0, cursorheight);
                    Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                    string changeGenreToo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(changeGenreToo) == false)
                    {
                        boardGame.Genre = changeGenreToo;
                    }

                    //rediger Stand
                    Console.WriteLine("Indtast stand");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(boardGame.State);
                    cursorheight = Console.CursorTop;
                    Console.SetCursorPosition(0, cursorheight);
                    Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                    string changeStateToo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(changeStateToo) == false)
                    {
                        boardGame.State = changeStateToo;
                    }

                    //rediger min players
                    Console.WriteLine("Indtast min spillere");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(boardGame.MinPlayers);
                    cursorheight = Console.CursorTop;
                    Console.SetCursorPosition(0, cursorheight);
                    Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                    string changeMinTo = Console.ReadLine();
                    int changeMinToInt;
                    bool ParseMin = int.TryParse(changeMinTo, out changeMinToInt);
                    if (string.IsNullOrWhiteSpace(changeMinTo) == false && ParseMin)
                    {
                        boardGame.MinPlayers = changeMinToInt;
                    }

                    //rediger max players
                    Console.WriteLine("Indtast maks spillere");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(boardGame.MaxPlayers);
                    cursorheight = Console.CursorTop;
                    Console.SetCursorPosition(0, cursorheight);
                    Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                    string changeMaxTo = Console.ReadLine();
                    int changeMaxToInt;
                    bool ParseMax = int.TryParse(changeMaxTo, out changeMaxToInt);
                    if (string.IsNullOrWhiteSpace(changeMaxTo) == false && ParseMax)
                    {
                        boardGame.MaxPlayers = changeMaxToInt;
                    }

                    //rediger pris
                    Console.WriteLine("Indtast pris spillere");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(boardGame.Price);
                    cursorheight = Console.CursorTop;
                    Console.SetCursorPosition(0, cursorheight);
                    Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                    string changePriceTo = Console.ReadLine();
                    int changePriceToInt;
                    bool ParsePrice = int.TryParse(changePriceTo, out changePriceToInt);
                    if (string.IsNullOrWhiteSpace(changePriceTo) == false && ParsePrice)
                    {
                        boardGame.Price = changePriceToInt;
                    }

                    //rediger lagerstatus
                    Console.WriteLine("Indtast lagerstatus");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(boardGame.Availability);
                    cursorheight = Console.CursorTop;
                    Console.SetCursorPosition(0, cursorheight);
                    Console.ForegroundColor = ConsoleColor.Gray; //sæt tekstfarve til standard
                    string changeAvailabilityTo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(changeAvailabilityTo) == false)
                    {
                        boardGame.Availability = changeAvailabilityTo;
                    }

                    StockFileHandler.DeleteBoardGame(id);
                    StockFileHandler.WriteBoardGamesToTextFile(boardGame.Name, boardGame.ID, boardGame.Genre, boardGame.MinPlayers, boardGame.MaxPlayers, boardGame.State, boardGame.Price, boardGame.Availability);
                }
                else // Spil ikke fundet
                {
                    Console.WriteLine("Spil findes ikke");
                }
            }
            catch (FormatException) { Console.WriteLine("ikke et tal"); }


        }
    }
}
