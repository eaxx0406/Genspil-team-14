using Genspil2.Gui.Creators;
using Genspil2.Gui.Printer;
using Genspil2.Model.Filehandlers;
using Genspil2.Model.Seachers;
using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Genspil2.Gui.Editors;
using Genspil2.Gui.Destroyer;

namespace Genspil2.Gui
{
    internal class MenuResolver
    {
        public static void ResolveStock(Overview overview) 
        {

            bool stay = true, ascending = true;
            string sortBy = "n";
            int pageNumber = 1;

            while (stay)
            {
                Console.Clear();
                StockPrinter.PrintStockOverview(overview.BoardGameList, overview.GenreList, sortBy, ascending, pageNumber);

                switch (Console.ReadKey(true).KeyChar.ToString().ToLower())
                {
                    case "c":
                        BoardGame newBoardGame = BoardGameCreator.CreateBoardGame(overview, "");
                        overview.AddToStock(newBoardGame);
                        break;
                    case "d":
                        GameDestroyer.DestoyGame(overview);
                        break;
                    case "s":
                        StockSearcher.SeachForStockItem(overview, sortBy, ascending);
                        Console.ReadKey();
                        break;
                    case "e":
                        GameEditor.EditGame(overview);
                        break;
                    case "x":
                        Console.Clear();
                        stay = false;
                        break;

                    //filterhåndtering
                    case "n":
                        if (sortBy == "n")
                        {
                            if (ascending == true) { ascending = false; }
                            else if (ascending == false) { ascending = true; }
                        }
                        else { sortBy = "n"; }
                        break;
                    case "g":
                        if (sortBy == "g")
                        {
                            if (ascending == true) { ascending = false; }
                            else if (ascending == false) { ascending = true; }
                        }
                        else { sortBy = "g"; }
                        break;
                    case "p":
                        if (sortBy == "p")
                        {
                            if (ascending == true) { ascending = false; }
                            else if (ascending == false) { ascending = true; }
                        }
                        else { sortBy = "p"; }
                        break;
                    case "i":
                        if (sortBy == "i")
                        {
                            if (ascending == true) { ascending = false; }
                            else if (ascending == false) { ascending = true; }
                        }
                        else { sortBy = "i"; }
                        break;
                    //pageing
                    case "+":
                        if (pageNumber <= overview.BoardGameList.Count / 10)
                        {
                            pageNumber++;
                        }
                        break;
                    case "-":
                        if (pageNumber > 1)
                        {
                            pageNumber--;
                        }
                        break;
                }
            }
        }

        public static void ResolveReservation(Overview overview)
        {
            bool stay = true, ascending = true;
            string sortBy = "n";
            int pageNumber = 1;

            while (stay)
            {
                Console.Clear();
                ReservationPrinter.PrintReservations(overview.ReservationList,overview.GenreList,sortBy,ascending,pageNumber);

                switch (Console.ReadKey(true).KeyChar.ToString().ToLower())
                {
                    case "c":
                        Console.Clear();
                        ReservationCreator.CreateReservation(overview);
                        break;
                    case "d":
                        ReservationDestroyer.DestroyReservation(overview);
                        break;
                    case "s": //TODO
                        Console.ReadKey();
                        break;
                    case "x":
                        Console.Clear();
                        stay = false;
                        break;

                    //filterhåndtering
                    case "n":
                        if (sortBy == "n")
                        {
                            if (ascending == true) { ascending = false; }
                            else if (ascending == false) { ascending = true; }
                        }
                        else { sortBy = "n"; }
                        break;
                }

            }
        }

        public static void ResolveCustomer(Overview overview)
        {
            bool stay = true, ascending = true;
            string sortBy = "i";
            int pageNumber = 1;

            while (stay)
            {
                Console.Clear();
                CustomerPrinter.PrintCustomerOverview(overview.CustomerList, sortBy, ascending, pageNumber);

                switch (Console.ReadKey(true).KeyChar.ToString().ToLower())
                {
                    case "c":
                        Console.Clear();
                        Customer NewCustomer = CustomerCreator.CreateCustomer(overview);
                        break;
                    case "d":
                        CustomerDestroyer.DestoyCustomer(overview);
                        break;
                    case "s":
                        CustomerSearcher.SeachForCustomer(overview);
                        Console.ReadKey();
                        break;
                    case "x":
                        Console.Clear();
                        stay = false;
                        break;
                    case "e":
                        Console.WriteLine("Indtast kundeid for at redigere");
                        int idToEdit = Int32.Parse(Console.ReadLine());
                        CustomerEditor.EditCustomer(overview, idToEdit);
                        break;

                    //Filterhåndtering
                    case "n":
                        if (sortBy == "n")
                        {
                            if (ascending == true) { ascending = false; }
                            else if (ascending == false) { ascending = true; }
                        }
                        else { sortBy = "n"; }
                        break;
                    case "i":
                        if (sortBy == "i")
                        {
                            if (ascending == true) { ascending = false; }
                            else if (ascending == false) { ascending = true; }
                        }
                        else { sortBy = "i"; }
                        break;

                    //pageing
                    case "+":
                        if (pageNumber <= overview.CustomerList.Count / 10)
                        {
                            pageNumber++;
                        }
                        break;
                    case "-":
                        if (pageNumber > 1)
                        {
                            pageNumber--;
                        }
                        break;
                }
            }
            
        }
    }
}
