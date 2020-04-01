using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Tiffily"; 
            CurrentPlayer.Money = 1000000;
            CurrentPlayer.CharacterClass = "Healthy";
            CurrentPlayer.Health = 10; //hitpoints
            CurrentPlayer.Money = 1000000; //gold
            CurrentPlayer.Bread = 2;
            CurrentPlayer.ToiletPaper = 6;
            //CurrentPlayer.ExperiencePoints = 0;
            //CurrentPlayer.Level = 1;
            CurrentPlayer.City = "New York City";

        }
    }
}



