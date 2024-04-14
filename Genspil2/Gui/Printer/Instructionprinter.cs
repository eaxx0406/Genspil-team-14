using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Printer
{
    internal class Instructionprinter
    {
        private static int width = 130;
        public static void PrintInstructions(string type)
        {
            //navigation
            Console.WriteLine();
            Console.WriteLine("┌".PadRight(width, '─') + "┐");

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"│ C:Opret {type}, D:Slet {type}, S:Søg {type},");
            if (type != "reservation") 
            {
                stringBuilder.Append($" E: rediger {type},"); 
            }
            stringBuilder.Append(" X:Vend tilbage til hovedmenu");
            Console.WriteLine(stringBuilder.ToString().PadRight(width) + "│");

            Console.WriteLine("└".PadRight(width, '─') + "┘");
            }
        

        public static void PrintSorteringInstruktions(string sortInstruktions) 
        {
            //sorteringsstyring
            Console.WriteLine();
            Console.WriteLine("┌".PadRight(width, '─') + "┐");
            Console.WriteLine($"│{sortInstruktions} (tryk igen for at ændre sorteringen)".PadRight(width) + '│');
            Console.WriteLine("└".PadRight(width, '─') + "┘");
        }

        public static void PrintPagening(int listLen,double showPrPage,int pageNumber ) 
        {
            double pages = ((listLen) / showPrPage);
            double lastPage = Math.Ceiling(pages);

            Console.WriteLine($"side {pageNumber} af {lastPage} (viser {showPrPage} kunder pr. side)");
        }
    }
}
