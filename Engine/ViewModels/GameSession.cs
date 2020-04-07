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
        private bool _hasCheckMe = false;
        private bool _hasCheckSpouse = false;
        private bool _hasCheckMother = false;
        private bool _hasCheckFather = false;
        private bool _hasCheckDaughter = false;
        private bool _hasCheckSon = false;

        public Player CurrentPlayer { get; set; }
        public FamilyHealth CurrentFamilyHealth { get; set; }
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

        public bool HasCheckMe
        {
            get { return _hasCheckMe; }
            set
            {
                _hasCheckMe = value;
                OnPropertyChanged("HasCheckMe");
            }
        }

        public bool HasCheckSpouse
        {
            get { return _hasCheckSpouse; }
            set
            {
                _hasCheckSpouse = value;
                OnPropertyChanged("HasCheckSpouse");
            }
        }

        public bool HasCheckMother
        {
            get { return _hasCheckMother; }
            set
            {
                _hasCheckMother = value;
                OnPropertyChanged("HasCheckMother");
            }
        }

        public bool HasCheckFather
        {
            get { return _hasCheckFather; }
            set
            {
                _hasCheckFather = value;
                OnPropertyChanged("HasCheckFather");
            }
        }

        public bool HasCheckDaughter
        {
            get { return _hasCheckDaughter; }
            set
            {
                _hasCheckDaughter = value;
                OnPropertyChanged("HasCheckDaughter");
            }
        }

        public bool HasCheckSon
        {
            get { return _hasCheckSon; }
            set
            {
                _hasCheckSon = value;
                OnPropertyChanged("HasCheckSon");
            }
        }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Tiffily"; 
            CurrentPlayer.Money = 50;
            CurrentPlayer.CharacterClass = "Healthy";
            CurrentPlayer.Job = "";
            //CurrentPlayer.Health = 10; //hitpoints
            CurrentPlayer.Bread = 2;
            CurrentPlayer.ToiletPaper = 3m;
            CurrentPlayer.City = "";
            CurrentPlayer.Mode = "";

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            //CurrentLocation = CurrentWorld.LocationAt(0, 0);

            QuestionFactory qfactory = new QuestionFactory();
            CurrentQuestion = qfactory.CreateQuestion();

            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "None", "Regular", "Any", "Any", "Yes", 1);

            CurrentFamilyHealth = new FamilyHealth();
            CurrentFamilyHealth.CharacterHealth = 90;
            CurrentFamilyHealth.MomHealth = 60;
            CurrentFamilyHealth.DadHealth = 60;
            CurrentFamilyHealth.SpouseHealth = 90;
            CurrentFamilyHealth.DaughterHealth = 90;
            CurrentFamilyHealth.SonHealth = 60;

        }
        public void ModeEasy()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "None", "Regular", "Any", "Any", "Yes", 2);
            CurrentPlayer.Mode = "Easy";
            CurrentPlayer.Job = "Banker";
        }

        public void ModeHard()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "None", "Regular", "Any", "Any", "Yes", 3);
            CurrentPlayer.Mode = "Hard";
            CurrentPlayer.Job = "Customer Representative";
        }

        public void CityLondon()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1);
            CurrentLocation = CurrentWorld.LocationAt(3, 0);
            CurrentPlayer.City = "London";
        }
        public void CityLosAngeles()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1);
            CurrentLocation = CurrentWorld.LocationAt(-3, 0);
            CurrentPlayer.City = "Los Angeles";
        }
        public void CityWuhan()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1);
            CurrentLocation = CurrentWorld.LocationAt(3, -2);
            CurrentPlayer.City = "Wuhan";
        }
        public void CityNewYork()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1);
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            CurrentPlayer.City = "New York City";
        }
        public void WorkYes()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", randomNumber(0, 2, 2)); //index, %, possible
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }
        public void WorkNo()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "No", 1);
        }
        public void WorkWashYes()
        {
            //CurrentLocation=
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
        }
        public void WorkWashNo()
        {
            //CurrentLocation=
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
        }
        public void FiredOk()
        {
            CurrentPlayer.Job = "None";
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
        }
        public void StoreYes()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 1);
            if(CurrentLocation.Name=="Work") { CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate+1, CurrentLocation.YCoordinate - 1); } else
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
            
        }
        public void StoreNo()
        {
            if (CurrentLocation.Name == "Work") { CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1); }
            if (CurrentPlayer.ToiletPaper >= .1m)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", randomNumber(1, 1, 2));
            }
            else
            {
                int index = randomNumber(1, 1, 2);
                if (index == 2)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index);
                }else if (index == 3)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index+1);
                    HasCheckMe = true;
                    HasCheckSpouse = true;
                    HasCheckMother = true;
                    HasCheckFather = true;
                    HasCheckDaughter = true;
                    HasCheckSon = true;
                }
            }

        }
        public void BreadOk()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 2);
        }
        public void BreadMoney()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 3);
        }
        public void TPOk()
        {
            if (CurrentPlayer.ToiletPaper >= .1m)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", randomNumber(1, 1, 2));
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
            else
            {
                int index = randomNumber(1, 1, 2);
                if (index == 2)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index);
                    CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                }
                else if (index == 3)
                {
                    CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index + 1);
                    HasCheckMe = true;
                    HasCheckSpouse = true;
                    HasCheckMother = true;
                    HasCheckFather = true;
                    HasCheckDaughter = true;
                    HasCheckSon = true;
                    
                }
            }
        }
        public void TPMoney()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 4);
        }
        public void PartyYes()
        {
            if (CurrentPlayer.ToiletPaper >= .1m)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 3);
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 4);
                HasCheckMe = true;
                HasCheckSpouse = true;
                HasCheckMother = true;
                HasCheckFather = true;
                HasCheckDaughter = true;
                HasCheckSon = true;
            }
        }
        public void PartyNo()
        {
            if (CurrentPlayer.ToiletPaper >= .1m)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 3);
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 4);
                HasCheckMe = true;
                HasCheckSpouse = true;
                HasCheckMother = true;
                HasCheckFather = true;
                HasCheckDaughter = true;
                HasCheckSon = true;
            }
        }
        public void HomeWashYes()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 4);
        }
        public void HomeWashNo()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 4);
        }

        public void DinnerOk()
        {
            if (CurrentPlayer.Job == "Customer Representative" || CurrentPlayer.Job == "Banker") { CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1); } else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            }

        }

        public void DinnerBread()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 5);
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int randomNumber(int index, int percentage, int totalPossible)
        {
            Random rnd = new Random();
            int randomRoll = rnd.Next(1, 11);
            if (totalPossible == 2)
            {
                if (randomRoll <= percentage)
                {
                    return index+1;
                }
                return index+2;
            }
            return -1;
        }
        
    }
}