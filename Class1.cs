using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Class1
    {

        
        public override string ToString() => $"{{gamenamer: {Name}, maxnumberplayers: {MaxNumberPlayers}, minnumberplayers: {MinNumberPlayers}, agemax: {MaxAgeGroup}, agemin: {MinAgeGroup}, price: {Price}, id: {ID}, genre: {Genre}, state: {State}}}";

        public string Name { get; set; }
        public string Genre { get; set; }
        public string State { get; set; }
        public int ID { get; set; }
        public double Price { get; set; }
        public int MaxNumberPlayers { get; set; }
        public int MinNumberPlayers { get; set; }
        public int MaxAgeGroup { get; set; }
        public int MinAgeGroup { get; set; }











       




    }
}
