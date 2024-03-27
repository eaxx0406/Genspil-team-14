using Genspil14.Classes;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Xml.Linq;

namespace Genspil14
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Hej Team 14
            Console.WriteLine("Hej Team 14, Velkommen til Genspil!!");

            //testspil
            Game testgame = new Game();
            testgame.Name = "testspil";
            testgame.MaxNumberPlayers = 6;
            testgame.MinNumberPlayers = 2;
            testgame.MaxAgeGroup = 10;
            testgame.MinAgeGroup = 5;
            testgame.ID = 2;
            testgame.Price = 50;
            testgame.Genre = "Familie game";
            testgame.State = "Perfect";

            Console.WriteLine(testgame.ToString());
        }
    }
}

