using Genspil2.Gui;
using Genspil2.Gui.Creators;
using Genspil2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil2
{
    internal class Overview
    {
        public List<BoardGame> BoardGameList = new List<BoardGame>();
        public List<Customer> CustomerList = new List<Customer>();
        public List<Reservation> ReservationList = new List<Reservation>();
        public List<Genre> GenreList = new List<Genre>();

        public Customer GetCustomer(int id)
        {
            foreach (Customer customer in CustomerList)
            {
                if (customer.Id == id)
                { return customer; }
            }
            return CustomerCreator.CreateCustomer(this);
        }

        public void AddToStock(BoardGame boardgame)
        {
            BoardGameList.Add(boardgame);
        }

        public void AddToReservations(Reservation reservation)
        {
            ReservationList.Add(reservation);
        }
        public void RemoveFromStock(int id)
        {
            BoardGame gameToDelete = BoardGameList.FirstOrDefault(game => game.ID == id);
            if (gameToDelete != null)
            {
                BoardGameList.Remove(gameToDelete);
            }
        }

        public void RemoveFromCustomer(int id)
        {

            var customerToDelete = CustomerList.FirstOrDefault(c => c.Id == id);
            if (customerToDelete != null)
            {
                CustomerList.Remove(customerToDelete);
            }
        }
        public void RemoveFromReservations(int id)
        {
            Reservation reservationToDelete = ReservationList.FirstOrDefault(x => x.ReservationId == id);
            if (reservationToDelete != null)
            {
                ReservationList.Remove(reservationToDelete);
            }
        }
    }
}
