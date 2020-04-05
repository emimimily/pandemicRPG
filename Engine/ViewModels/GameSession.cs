using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels
{
    public class GameSession : INotifyPropertyChanged
    {
        private Location _currentLocation;
        private QuestionStatus _currentQuestionStatus;
        private Question _currentQuestion;
        private bool _hasButton2 = true;
        private bool _hasButton1 = true;
        private bool _hasUpDown = false;

        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged("CurrentLocation");
            }
        }
        public World CurrentWorld { get; set; }
        public QuestionStatus CurrentQuestionStatus
        {
            get { return _currentQuestionStatus; }
            set
            {
                _currentQuestionStatus = value;
                OnPropertyChanged("CurrentQuestionStatus");
            }
        }
        //public Question CurrentQuestion { get; set; }
        public Question CurrentQuestion
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value;
                OnPropertyChanged("CurrentQuestion");
            }
        }

        
        public bool HasButton2
        {
            get { return _hasButton2; }
            set
            {
                _hasButton2 = value;
                OnPropertyChanged("HasButton2");
            }
        }

        public bool HasButton1
        {
            get { return _hasButton1; }
            set
            {
                _hasButton1 = value;
                OnPropertyChanged("HasButton1");
            }
        }

        public bool HasUpDown
        {
            get { return _hasUpDown; }
            set
            {
                _hasUpDown = value;
                OnPropertyChanged("HasUpDown");
            }
        }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Tiffily"; 
            CurrentPlayer.Money = 1000000;
            CurrentPlayer.CharacterClass = "Healthy";
            CurrentPlayer.Health = 10; //hitpoints
            CurrentPlayer.Bread = 2;
            CurrentPlayer.ToiletPaper = 6;
            CurrentPlayer.City = "New York City";

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);

            QuestionFactory qfactory = new QuestionFactory();
            CurrentQuestion = qfactory.CreateQuestion();

            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1);


        }
        public void WorkYes()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Yes", randomNumber(10, 2));
        }
        public void WorkNo()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "No", 1);
        }
        public void WorkWash()
        {
            //CurrentLocation=
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
        }

        public void FiredOk()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
        }

        public void StoreYes()
        {
            //CurrentLocation=
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Regular", "Any", "Any", "Any", 1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int randomNumber(int percentage, int totalPossible)
        {
            Random rnd = new Random();
            int randomRoll = rnd.Next(1, 11);
            if (totalPossible == 2)
            {
                if (randomRoll <= percentage)
                {
                    return 1;
                }
                return 2;
            }
            return -1;
        }
        
    }
}



