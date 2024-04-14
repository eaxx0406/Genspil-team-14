using Genspil2.Gui;
using Genspil2.Gui.Printer;
using Genspil2.Model.Filehandlers;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Genspil2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Overview Overview = new Overview();

            //load textfiles
            StockFileHandler.ReadBoardGamesFromTextFile(Overview);
            CustomerFileHandler.ReadCustomerFromTextFile(Overview);
            ReservationFileHandler.ReadReservationsFromTextFile(Overview);
            GenreFileHandler.ReadGenresFromTextFile(Overview);


            bool MainMenuSelected = false;
            
            while (MainMenuSelected == false)
            {
                bool errorCaught = false;
                int Menupunkt = 0;
                Console.Clear();
                MainMenuPrinter.ShowMainMenu();
                try 
                { 
                    Menupunkt = Int32.Parse(Console.ReadKey(true).KeyChar.ToString());
                }
               catch (FormatException) { 
                    MainMenuSelected = false;
                    errorCaught = true;
                }
                if (errorCaught == false) { Menu.SelectMenuItem(Menupunkt, Overview); }
               

            }
        }
    }
}
