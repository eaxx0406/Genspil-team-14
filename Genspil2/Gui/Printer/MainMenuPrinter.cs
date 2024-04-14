using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Printer
{
    internal class MainMenuPrinter
    {
        private static readonly int MenuWidth = Console.WindowWidth / 2 ;
        private static readonly int TotalMenuWidth = MenuWidth + MarginMenuPoints;
        private static readonly int Margin = (Console.WindowWidth / 2) - (TotalMenuWidth/2);
        private static readonly int MarginMenuPoints = 10;
        private static readonly string[] TextLines = { "Se lageroversigt", "Se reservationer",  "Se Kundeliste" };

        //Print Menu
        public static void ShowMainMenu()
        {
            string replay = "Genspils hovedmenu:";
            Console.WriteLine(replay.PadLeft(MenuWidth + (replay.Length / 2)));
            Console.WriteLine("");

            //toplinje 
            Console.WriteLine("".PadRight(Margin) + "┌".PadRight(TotalMenuWidth, '─') + "┐");
            Console.WriteLine("".PadRight(Margin) + "│".PadRight(TotalMenuWidth) + "│");

            //menupunkter
            int menuPoint = 1;
            foreach (string line in TextLines)
            {
                Console.WriteLine("".PadRight(Margin) + "│".PadRight(MarginMenuPoints) + $"{menuPoint}) {line}".PadRight(MenuWidth - MarginMenuPoints) + "│");
                menuPoint++;
            }

            //Bundlinje 
            Console.WriteLine("".PadRight(Margin) + "│".PadRight(TotalMenuWidth) + "│");
            Console.WriteLine("".PadRight(Margin) + "└".PadRight(TotalMenuWidth, '─') + "┘");

            //instruktioner
            string instructions = "(Tryk menupunkt for at fortsætte)";
            Console.WriteLine();
            Console.WriteLine(instructions.PadLeft(MenuWidth + (instructions.Length / 2)));
        }
    }
}
