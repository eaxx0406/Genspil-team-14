using Genspil2.Model.Filehandlers;
using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2.Gui.Creators
{
    internal class ReservationCreator
    {
        public static void CreateReservation(Overview overview)
        {
            int customerId, reservationsId;
            bool enteredId;
            string notes;
            Customer customer;
            BoardGame boardGame;
           
            Console.WriteLine("Opret en reservation");

            Console.WriteLine("Allerede oprettet som kunde? indtast id:");
            enteredId = int.TryParse(Console.ReadLine(), out customerId);
            if (enteredId) //bruger indtaster et tal
            {
                customer = overview.GetCustomer(customerId); //tjek om kundeidet findes i systemet
            }
            else
            {
                customer = CustomerCreator.CreateCustomer(overview); //Brugeren indtaster ikke ID og skal derfor oprettes som kunde
            }
            Console.WriteLine("Indtast beskrivelse af dit drømmespil ");
            boardGame = BoardGameCreator.CreateBoardGame(overview, "ønsket"); //opretter et "ønske"spil 

            Console.WriteLine("Indtast eventuelle noter");
            notes = Console.ReadLine();

            //id
            reservationsId =overview.ReservationList.Max(x => x.ReservationId) + 1;

            //opret reservation i system
            Reservation reservation = new Reservation(customer, boardGame, notes, reservationsId);
            overview.ReservationList.Add(reservation);
            ReservationFileHandler.WriteReservationToTextFile(customer, boardGame, notes, reservationsId);

        }
    }
}
