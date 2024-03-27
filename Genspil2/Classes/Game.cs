using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil14.Classes
{
    internal class Game
    {
        //Attributter:
        public override string ToString() => $"gamename: {Name},numberplayers: min {MinNumberPlayers}  max {MaxNumberPlayers}, age: min {MinAgeGroup} max  {MaxAgeGroup}, price: {Price}, id: {ID}, genre: {Genre}, state: {State}";

        public string Name { get; set; }
        public string Genre { get; set; }
        public string State { get; set; }
        public int ID { get; set; }
        public double Price { get; set; }
        public int MaxNumberPlayers { get; set; }
        public int MinNumberPlayers { get; set; }
        public int MaxAgeGroup { get; set; }
        public int MinAgeGroup { get; set; }

        //metoder:
    }
}
