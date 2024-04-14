using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Genspil2.Model.Filehandlers
{
    internal class ReservationFileHandler
    {
        public static string ReservationFilepath = @"..\..\..\Storage\Reservations.txt";

        public static void ReadReservationsFromTextFile(Overview overview)
        {
            var lines = File.ReadLines(ReservationFilepath).ToList();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                string[] values = line.Split(',');

                Customer customerForReservation = CheckIfCustomerAlreadyExist(values,overview);
                BoardGame boardGame = new BoardGame(values[4].ToLower(), 0, values[5], int.Parse(values[6]), int.Parse(values[7]), values[8], int.Parse(values[9]),"ønsket");
                Reservation reservation = new Reservation(customerForReservation, boardGame, values[10], int.Parse(values[11]));
                overview.ReservationList.Add(reservation);
                }
            }
        
        public static void WriteReservationToTextFile(Customer customer, BoardGame boardgame, string notes,int reservationId)
        {
            string CreateText = Environment.NewLine + $"{customer.Name},{customer.Tlf},{customer.Email},{customer.Id},{boardgame.Name},{boardgame.Genre},{boardgame.MinPlayers},{boardgame.MaxPlayers},{boardgame.State},{boardgame.Price},{notes},{reservationId}" ;
            File.AppendAllText(ReservationFilepath, CreateText );
        }

        public static void DeleteReservation(int id)
        {
            List<string> savedReservation = new List<string>();
            var lines = File.ReadLines(ReservationFilepath).ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (int.Parse(values[11]) != id)
                {
                    savedReservation.Add(line);
                }
            }

            File.WriteAllText(ReservationFilepath, "navn,tlf,e-mail,Kid,spilnavn,genre,min,max,status,pris,noter,rId");

            foreach (string line in savedReservation)
            {
                File.AppendAllText(ReservationFilepath, Environment.NewLine + line);
            }
        }

        public static Customer CheckIfCustomerAlreadyExist(string[] values, Overview overview)
        {

            //tjek om kunde allerede er oprettet
            foreach (Customer customerInList in overview.CustomerList)
            {
                if (customerInList.Id == int.Parse(values[3]))
                {
                    return customerInList;
                }
            }
            //hvis kunden ikke eksisterer
            Customer customerForReservation = new Customer(values[0], values[1], values[2], int.Parse(values[3]));
            overview.CustomerList.Add(customerForReservation);
            return customerForReservation;
            
        }
    }
}
