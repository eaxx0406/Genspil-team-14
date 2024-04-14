using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Genspil2.Model.Filehandlers;

namespace Genspil2.Model
{
    internal class BoardGame
    {
        private string _genre;
        private int _minPlayers;
        private int _maxPlayers;
        private int _price;
        public BoardGame(string gameName, int id, string genre, int minPlayers, int maxPlayers, string state, int price, string availability)
        {
            Name = gameName;
            ID = id;
            Genre = genre;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            State = state;
            Price = price;
            Availability = availability;
        }

        public string Name { get; set; }
        public int ID { get; }
        public string Genre
        {
            get { return _genre; }  
            set 
            { 
                if (int.Parse(value) > 0 && int.Parse(value) <= 7)
                    {
                        _genre = value;
                    } 
            }
        }
        public int MinPlayers
        {
            get { return _minPlayers; }
            set
            {
                if (value > 0)
                {
                    _minPlayers = value;
                }
                else { _minPlayers = 0; }
            }
        }
        public int MaxPlayers
        {
            get { return _maxPlayers; }
            set
            {
                if (value > 0 && value < _minPlayers)
                {
                    _maxPlayers = value;
                }
                else { _maxPlayers = 100; }
            }
        }
        public string State { get; set; }
        public int Price
        {
            get { return _price; }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else { _price = 0; }
            }
        }
        public string Availability { get; set; }

    }
}
