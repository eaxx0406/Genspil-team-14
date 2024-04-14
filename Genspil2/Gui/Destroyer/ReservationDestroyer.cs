using Genspil2.Model.Filehandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Destroyer
{
    internal class ReservationDestroyer
    {
        public static void DestroyReservation(Overview overview) 
        {
            int id;
            Console.WriteLine("Indtast ReservationsID for at slette");
            id = Int32.Parse(Console.ReadLine());
            ReservationFileHandler.DeleteReservation(id);
            overview.RemoveFromReservations(id);
        }
    }
}
