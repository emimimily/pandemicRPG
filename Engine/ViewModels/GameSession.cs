using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;
using Engine.EventArgs;
using Engine.Functions;

namespace Engine.ViewModels
{
    public class GameSession : INotifyPropertyChanged
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        #region Properties

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
        public Day CurrentDay { get; set; }
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

        GSFunctions gsf = new GSFunctions();

        #endregion

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "Tiffily",
                CharacterClass = "",
                Job = "",
                Bread = 2,
                ToiletPaper = 3m,
                City = "",
                Mode = "",
                Stage = "Regular",
                InfectionChance = 0,
                InfectionSeverity = 0,
                ConfirmedInfection = false
            };

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();


            QuestionFactory qfactory = new QuestionFactory();
            CurrentQuestion = qfactory.CreateQuestion();

            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "None", "Regular", "Any", "Any", "Yes", 1);

            CurrentFamilyHealth = new FamilyHealth
            {
                CharacterHealth = 90,
                MomHealth = 67,
                DadHealth = 62,
                SpouseHealth = 95,
                DaughterHealth = 90,
                SonHealth = 90
            };

            CurrentDay = new Day();

        }
        public void ModeEasy()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "None", "Regular", "Any", "Any", "Yes", 2);
            CurrentPlayer.Mode = "Easy";
            CurrentPlayer.Job = "Banker";
            CurrentPlayer.CharacterClass = "Healthy";
            CurrentPlayer.Money = 100;
        }

        public void ModeHard()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "None", "Regular", "Any", "Any", "Yes", 3);
            CurrentPlayer.Mode = "Hard";
            CurrentPlayer.Job = "Customer Representative";
            CurrentPlayer.CharacterClass = "Obese";
            CurrentPlayer.Money = 50;
        }

        public void CityLondon()
        {
            CurrentDay.Date = "3/21/20";
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", CurrentPlayer.Stage, "Any", "Any", "Yes", 1);
            CurrentLocation = CurrentWorld.LocationAt(3, 0);
            CurrentPlayer.City = "London";

        }
        public void CityLosAngeles()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", CurrentPlayer.Stage, "Any", "Any", "Yes", 1);
            CurrentLocation = CurrentWorld.LocationAt(-3, 0);
            CurrentPlayer.City = "Los Angeles";
        }
        public void CityWuhan()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", CurrentPlayer.Stage, "Any", "Any", "Yes", 1);
            CurrentLocation = CurrentWorld.LocationAt(3, -2);
            CurrentPlayer.City = "Wuhan";
        }
        public void CityNewYork()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", CurrentPlayer.Stage, "Any", "Any", "Yes", 1);
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            CurrentPlayer.City = "New York City";
        }
        public void WorkYes()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", gsf.randomNumber(0, 2, 2)); //index, %, possible
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            CurrentPlayer.InfectionChance = 1; //.1
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void WorkNo()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "No", 1);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void WorkWashYes()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, true);
        }
        public void WorkWashNo()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            CurrentPlayer.InfectionChance += .2;
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void FiredOk()
        {
            CurrentPlayer.Job = "None";
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void StoreYes()
        {
            if (CurrentPlayer.Stage == "Regular")
            {
                CurrentPlayer.InfectionChance += 1; //.1
            }
            else
            {
                CurrentPlayer.InfectionChance += 1; //.15
            }
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 1);
            if (CurrentLocation.Name == "Work") { CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate - 1); }
            else
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void StoreNo()
        {
            if (CurrentLocation.Name == "Work") { CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1); CurrentPlayer.InfectionChance = .1; }
            if (CurrentPlayer.ToiletPaper >= .1m)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", gsf.randomNumber(1, 1, 2));
            }
            else
            {
                int index = gsf.randomNumber(1, 1, 2);
                if (index == 2)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index);
                }
                else if (index == 3)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index + 1);
                    HasCheckMe = true;
                    HasCheckSpouse = true;
                    HasCheckMother = true;
                    HasCheckFather = true;
                    HasCheckDaughter = true;
                    HasCheckSon = true;
                }
            }
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void BreadOk()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 2);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void BreadMoney()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 3);
        }
        public void TPOk()
        {
            if (CurrentPlayer.ToiletPaper >= .1m)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", gsf.randomNumber(1, 1, 2));
                CurrentPlayer.InfectionChance = .1;
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
            else
            {
                int index = gsf.randomNumber(1, 1, 2);
                if (index == 2)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index);
                    CurrentPlayer.InfectionChance = .1;
                    CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                }
                else if (index == 3)
                {
                    CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                    CurrentPlayer.InfectionChance = .1;
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index + 1);
                    HasCheckMe = true;
                    HasCheckSpouse = true;
                    HasCheckMother = true;
                    HasCheckFather = true;
                    HasCheckDaughter = true;
                    HasCheckSon = true;

                }
            }
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void TPMoney()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 4);
        }
        public void PartyYes()
        {
            if (CurrentPlayer.Stage == "Regular")
            {
                CurrentPlayer.InfectionChance += .1;
            }
            else
            {
                CurrentPlayer.InfectionChance += .3;
            }
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
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
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
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }
        public void HomeWashYes()
        {
            CurrentPlayer.InfectionChance = 0;
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 4);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, true);
        }
        public void HomeWashNo()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 4);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
        }

        public void DinnerOk()
        {
            CurrentDay.Date = gsf.nextDay(CurrentDay.Date);
            bool quarantineTomorrow = false;
            if(CurrentPlayer.City=="London" && CurrentDay.Date == "3/23/20") //london quarantine
            {
                CurrentPlayer.Stage = "Quarantine";
                quarantineTomorrow = true;
                if (CurrentPlayer.Job == "Customer Representative" || CurrentPlayer.Job == "Banker")  //person w/ job quarantine message
                { 
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Yes", 1);
                    CurrentPlayer.Job = "None";
                }
                else
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Yes", 2); //person w/o job quarantine message
                }
            }
            else if (CurrentPlayer.Job == "Customer Representative" || CurrentPlayer.Job == "Banker")
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1); //regular next day w/job
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2); //regular next day w/o job
            }

            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false); //update infection
            if (CurrentPlayer.InfectionSeverity > 0)
            {
                CurrentPlayer.InfectionSeverity = gsf.infectionDay(CurrentPlayer.InfectionSeverity, false, CurrentPlayer.CharacterClass);
            }

            if(CurrentPlayer.InfectionSeverity >= 16 && !quarantineTomorrow) //infection message
            {
                if (CurrentPlayer.ConfirmedInfection == false)
                {
                    switch (CurrentPlayer.InfectionSeverity)
                    {
                        case 16:
                            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16", "Any", 1);
                            break;
                        case 17:
                            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "17", "Any", 2);
                            break;
                        case 18:
                            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "18", "Any", 3);
                            break;
                        case 19:
                            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "19", "Any", 4);
                            break;
                        case 20:
                            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5);
                            break;
                    }
                }
            }
        }

        public void DinnerBread()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 5);
        }

        public void SocialDistanceOk()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Any", 3);
        }

        public void TestYes()
        {
            CurrentLocation=CurrentWorld.LocationAt(CurrentLocation.XCoordinate-1, CurrentLocation.YCoordinate);
            if (gsf.testChance(CurrentPlayer.Stage)) { CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 6); } else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 7);
            }
        }
        public void TestNo()
        {
            if (CurrentPlayer.Job == "None")
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1);
            }
            
        }
        public void NotEnoughTests()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            if (CurrentPlayer.Job == "None")
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }


    }
}