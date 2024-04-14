using Genspil2.Model.Filehandlers;
using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Creators
{
    internal class BoardGameCreator
    {
        public static BoardGame CreateBoardGame(Overview overview, string availability)
        {
            Console.WriteLine("Opret et spil");
            int id = 0, min = 0, max = 0, price = 0;
            string name = "";
            bool boardGameNameEntered = false;

            //Spilnavn
            while (boardGameNameEntered == false)
            {
                Console.WriteLine("Indtast spilnavn: ");
                name = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(name) == false) { boardGameNameEntered = true; } //Bruger har indtastet navn korrekt
                else if (availability == "ønsket") { boardGameNameEntered = true; } //Spillet er en reservation og behøver ikke et navn
            }

            //SpilId
            if (availability != "ønsket")
            { id = overview.BoardGameList.Max(x => x.ID) + 1; }

            //Vælg _genre
            string genreId;
            Console.WriteLine("Vælg genre: ");
            foreach (Genre genre in overview.GenreList)
            {
                Console.WriteLine(genre.ID  + ": " + genre.Name);
            }
            try
            {
                genreId = Console.ReadKey(true).KeyChar.ToString();
                int genreIdInt = int.Parse(genreId);
                if (genreIdInt < 0 && genreIdInt >= overview.GenreList.Count) { genreId = "7"; }
            }
            catch (FormatException) { genreId = "7"; }

            //Spillerantal
            if (genreId == "1") { min = 2; max = 12; }
            else if (genreId == "2") { min = 2; max = 5; }
            else if (genreId == "3") { min = 3; max = 7; }
            else if (genreId == "4") { min = 2; max = 100;}
            else if (genreId == "5") { min = 2; max = 4; }
            else if (genreId == "6") { min = 3; max = 6; }
            else
            {   //min
                Console.WriteLine("Indtast mindst antal spillere: ");
                try { min = int.Parse(Console.ReadLine()); }
                catch (FormatException) { min = 0; }
                //max
                Console.WriteLine("Indtast maks antal spillere: ");
                try { max = int.Parse(Console.ReadLine()); }
                catch (FormatException) { max = 100; }
            }

            //stand
            Console.WriteLine("Indtast stand: ");
            string state = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(state)) { state = "Ikke angivet"; }

            //price 
            Console.WriteLine("Indtast pris: ");
            try { price = int.Parse(Console.ReadLine()); }
            catch (FormatException) { price = 0; }
            if (price < 0) { price = 0; }

            //availability 
            if (state == "til reparation") { availability = "til reparation"; }
            else if (availability != "ønsket")
            {
                Console.WriteLine("Indtast status: (Standard \"på lager\") ");
                availability = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(availability)) { availability = "På lager"; }
            }

            if (availability != "ønsket")
            {
                BoardGame newBoardGame = StockFileHandler.WriteBoardGamesToTextFile(name, id, genreId, min, max, state, price, availability);
                return newBoardGame;
            }
            else
            {
                BoardGame newBoardGame = new BoardGame(name, id, genreId, min, max, state, price, "ønsket");
                return newBoardGame;
            }

        }
    }
}
