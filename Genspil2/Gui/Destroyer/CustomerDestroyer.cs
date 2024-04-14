using Genspil2.Model.Filehandlers;
using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Destroyer
{
    internal class CustomerDestroyer
    {
        public static void DestoyCustomer(Overview overview)
        {
            Console.WriteLine("Indtast KundeID for at slette");
            int idtodelete = Int32.Parse(Console.ReadLine());
            Console.WriteLine("OBS! er du sikker på du vil slette kunden og alle kundens reservationer? (y for at bekræfte)");
            string verify = Console.ReadLine().ToLower();
            if (verify == "y")
            {
                CustomerFileHandler.DeleteCustomer(idtodelete);
                List<Reservation> reservationsTodelete = new List<Reservation>();
                foreach (Reservation reservation in overview.ReservationList)
                {
                    if (reservation.Customer.Id == idtodelete)
                    {
                        ReservationFileHandler.DeleteReservation(reservation.ReservationId);
                        reservationsTodelete.Add(reservation);
                    }
                }
                foreach (Reservation reservation in reservationsTodelete) { overview.ReservationList.Remove(reservation); }
                overview.RemoveFromCustomer(idtodelete);
            }
        }
    }
}
