using Genspil2.Gui.Printer;
using Genspil2.Model.Filehandlers;
using Genspil2.Model.Seachers;
using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genspil2.Gui.Creators;
using Genspil2.Gui.Editors;

namespace Genspil2.Gui
{
    internal class Menu
    {
       
        public static void SelectMenuItem(int menuItem, Overview overview)
        {
            switch (menuItem)
            {
                case 0:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case 1:
                    MenuResolver.ResolveStock(overview);
                    break;
                case 2:
                    MenuResolver.ResolveReservation(overview);
                    break;
                case 3:
                    MenuResolver.ResolveCustomer(overview);
                    break;
               
                default:
                    Console.WriteLine("Ikke fundet");
                    Console.Clear();
                    break;
            }
        }
       
    }
}
