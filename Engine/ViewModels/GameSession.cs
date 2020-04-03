using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }
        public World CurrentWorld { get; set; }
        public QuestionStatus CurrentQuestionStatus { get; set; }
        public Question CurrentQuestion { get; set; }

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

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);

            QuestionFactory qfactory = new QuestionFactory();
            CurrentQuestion = qfactory.CreateQuestion();

            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1);


        }
    }
}



