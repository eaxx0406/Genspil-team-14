using Genspil2.Gui.Creators;
using Genspil2.Model.Filehandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil2.Model
{
    internal class Reservation
    {

        public Reservation(Customer customer, BoardGame boardGame, string notes, int id) 
        {
            Customer = customer;
            BoardGame = boardGame;
            Notes = notes;
            ReservationId = id;
        }

        public Customer Customer { get; }
        public BoardGame BoardGame { get; }
        public int ReservationId { get; }

        public string Notes { get; }

    }
}
