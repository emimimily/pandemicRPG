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
        public event EventHandler<UpdateMessageEventArgs> OnUpdateRaised;
        #region Properties
        #region Properties

        private Location _currentLocation;
        private QuestionStatus _currentQuestionStatus;
        private Question _currentQuestion;
        private DailyUpdate _currentDailyUpdate;
        private Updates _currentUpdates;

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

        public Updates CurrentUpdates
        {
            get { return _currentUpdates; }
            set
            {
                _currentUpdates = value;
                OnPropertyChanged("Updates");
            }
        }
        public DailyUpdate CurrentDailyUpdate
        {
            get { return _currentDailyUpdate; }
            set
            {
                _currentDailyUpdate = value;
                OnPropertyChanged("CurrentDailyUpdate");
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
                ConfirmedInfection = false,
                DaysSinceTested = 0,
                Tested = false,
                Hospitalized = false,
                DaysSinceStart = 0,
                Karma = 50,
                BodyGif = "/Engine;component/Images/Body/body1.gif"

            };

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();


            QuestionFactory qfactory = new QuestionFactory();
            CurrentQuestion = qfactory.CreateQuestion();

            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "None", "Regular", "Any", "Any", "Yes", 1);

            UpdateFactory ufactory = new UpdateFactory();
            CurrentUpdates = ufactory.CreateUpdate();
            
            

            CurrentFamilyHealth = new FamilyHealth
            {
                CharacterHealth = 90,
                MomHealth = 67,
                DadHealth = 62,
                SpouseHealth = 95,
                DaughterHealth = 90,
                SonHealth = 90,

                CharacterInfected = false,
                MomInfected = false,
                DadInfected = false,
                SpouseInfected = false,
                DaughterInfected = false,
                SonInfected = false,

                CharacterAlive = true,
                MomAlive = true,
                DadAlive = true,
                SpouseAlive = true,
                DaughterAlive = true,
                SonAlive = true,

                CharacterImage = "/Engine;component/Images/Family/player.png",
                MomImage="/Engine;component/Images/Family/mom.png",
                DadImage= "/Engine;component/Images/Family/dad.png",
                SpouseImage ="/Engine;component/Images/Family/spouse.png",
                DaughterImage= "/Engine;component/Images/Family/daughter.png",
                SonImage = "/Engine;component/Images/Family/son.png" 
            };

            CurrentDay = new Day();

            CurrentPlayer.NextDayMessages = new List<QuestionStatus> { CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1) };
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
            CurrentDay.Date = "3/8/20";
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation = CurrentWorld.LocationAt(3, 0);
            CurrentPlayer.City = "London";
            CurrentPlayer.DailyIncome = 96;
            CurrentDailyUpdate = CurrentUpdates.UpdateAt("London", 1);

        }
        public void CityLosAngeles()
        {
            CurrentDay.Date = "3/11/20";
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation = CurrentWorld.LocationAt(-3, 0);
            CurrentPlayer.City = "Los Angeles";
            CurrentPlayer.DailyIncome = 168;
            CurrentDailyUpdate = CurrentUpdates.UpdateAt("Los Angeles", 1);
        }
        public void CityWuhan()
        {
            CurrentDay.Date = "1/15/20";
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation = CurrentWorld.LocationAt(3, -2);
            CurrentPlayer.City = "Wuhan";
            CurrentPlayer.DailyIncome = 24;
            CurrentDailyUpdate = CurrentUpdates.UpdateAt("Wuhan", 1);

        }
        public void CityNewYork()
        {
            CurrentDay.Date = "3/14/20";
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            CurrentPlayer.City = "New York City";
            CurrentPlayer.DailyIncome = 96;
            CurrentDailyUpdate = CurrentUpdates.UpdateAt("New York City", 1);
            RaiseUpdate(CurrentDay.Date);
            RaiseUpdate(CurrentDailyUpdate.CaseUpdate);
            
        }
        public void WorkYes() //1
        {
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", gsf.randomNumber(0, 2, 2)); //index, %, possible
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            CurrentPlayer.InfectionChance = .1-(CurrentPlayer.Karma/2000); //.1
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >=1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
        }
        public void WorkNo() //1
        {
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            if (CurrentPlayer.ConfirmedInfection == true)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "16+", "Yes", 1);
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "No", 1);
            }
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
        }
        public void WorkWashYes()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, true);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
            if (CurrentPlayer.Karma <= 95) { CurrentPlayer.Karma += 5; }
        }
        public void WorkWashNo()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            CurrentPlayer.InfectionChance += .2 - (CurrentPlayer.Karma / 2000);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
            if (CurrentPlayer.Karma >= 5) { CurrentPlayer.Karma -= 5; }
        }
        public void FiredOk()
        {
            CurrentPlayer.Job = "None";
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
            CurrentPlayer.Money += CurrentPlayer.DailyIncome * CurrentPlayer.DaysSinceStart;
        }
        public void StoreYes()
        {
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            if (CurrentPlayer.Stage == "Regular")
            {
                CurrentPlayer.InfectionChance += .1 - (CurrentPlayer.Karma / 2000); //.1
            }
            else if(CurrentPlayer.Stage=="Quarantine")
            {
                CurrentPlayer.InfectionChance += .15 - (CurrentPlayer.Karma / 2000); //.15
                if (CurrentPlayer.Karma >= 5) { CurrentPlayer.Karma -= 5; }
            }
            else
            {
                CurrentPlayer.InfectionChance += .20 - (CurrentPlayer.Karma / 2000); //.20
                if (CurrentPlayer.Karma >= 10) { CurrentPlayer.Karma -= 10; }
            }
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 1);
            if (CurrentLocation.Name == "Work") { CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate - 1); }
            else
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
        }
        public void StoreNo()
        {
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
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
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
        }
        public void BreadOk()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 2);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
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
                CurrentPlayer.InfectionChance = .1 - (CurrentPlayer.Karma / 2000);
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
            else
            {
                int index = gsf.randomNumber(1, 1, 2);
                if (index == 2)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", index);
                    CurrentPlayer.InfectionChance = .1 - (CurrentPlayer.Karma / 2000);
                    CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                }
                else if (index == 3)
                {
                    CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                    CurrentPlayer.InfectionChance = .1 - (CurrentPlayer.Karma / 2000);
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
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
        }
        public void TPMoney()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Store", "Any", "Any", "Any", "Any", "Any", 4);
        }
        public void PartyYes()
        {
            if (CurrentPlayer.Stage == "Regular")
            {
                CurrentPlayer.InfectionChance += .1 - (CurrentPlayer.Karma / 2000);
                if (CurrentPlayer.Karma >= 5) { CurrentPlayer.Karma -= 5; }
            }
            else if(CurrentPlayer.Stage=="Quarantine")
            {
                CurrentPlayer.InfectionChance += .3 - (CurrentPlayer.Karma / 2000);
                if (CurrentPlayer.Karma >= 20) { CurrentPlayer.Karma -= 20; }
            }
            else
            {
                CurrentPlayer.InfectionChance += .5 - (CurrentPlayer.Karma / 2000);
                if (CurrentPlayer.Karma >= 50) { CurrentPlayer.Karma -= 50; }
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
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
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
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
        }
        public void HomeWashYes()
        {
            if (CurrentPlayer.Karma <= 95) { CurrentPlayer.Karma += 5; }
            CurrentPlayer.InfectionChance = 0;
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 4);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, true);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
        }
        public void HomeWashNo()
        {
            if (CurrentPlayer.Karma >= 5) { CurrentPlayer.Karma -= 5; }
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 4);
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity >= 1)
            {
                CurrentFamilyHealth.CharacterInfected = true;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/infect_player.png";
            }
            else
            {
                CurrentFamilyHealth.CharacterInfected = false;
                CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            }
        }

        public void DinnerOk()
        {
            //CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentDay.Date = gsf.nextDay(CurrentDay.Date);
            CurrentDailyUpdate = CurrentUpdates.UpdateAt(CurrentPlayer.City, CurrentDailyUpdate.Index+1);
            RaiseUpdate(CurrentDay.Date);
            RaiseUpdate(CurrentDailyUpdate.CaseUpdate);

            CurrentPlayer.DaysSinceStart++;
            if(CurrentPlayer.Stage!="Regular" && CurrentPlayer.City == "London" && CurrentPlayer.Job!="None")
            {
                CurrentPlayer.Money += 79; //80% of income
            }
            bool quarantineTomorrow = false;
            if (CurrentPlayer.InfectionSeverity == 19)
            {
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5));
                CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
                CurrentPlayer.NextDayMessages.RemoveAt(0);
                return;
            }
            if(CurrentPlayer.City == "London" && CurrentDay.Date == "3/16/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if(CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "1/23/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "3/22/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "3/19/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (quarantineTomorrow == true) //quarantinetomorrow
            {
                if (CurrentPlayer.Job == "Customer Representative" || CurrentPlayer.Job == "Banker")  //person w/ job quarantine message
                {
                    CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Yes", 1));
                    CurrentPlayer.Job = "None";
                    CurrentPlayer.Money += CurrentPlayer.DailyIncome * CurrentPlayer.DaysSinceStart;
                }
                else
                {
                    CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Yes", 2)); //person w/o job quarantine message
                }
            }

            bool crisisTomorrow = false;
            if (CurrentPlayer.City == "London" && CurrentDay.Date == "3/31/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "1/23/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "4/5/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "4/2/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if(crisisTomorrow == true)
            {
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Crisis", "Any", "Any", "Yes", 1));
            }
            bool surviveTomorrow = false;
            if (CurrentPlayer.City == "London" && CurrentDay.Date == "4/22/20") { surviveTomorrow = true; }
            if (CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "2/29/20") {  surviveTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "4/25/20") { surviveTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "4/28/20") { surviveTomorrow = true; }
            if (surviveTomorrow == true)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Crisis", "Any", "Any", "Yes", 2);
                return;
            }
            //INFECTED
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false); //update infection
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity > 0)
            {
                CurrentPlayer.InfectionSeverity = gsf.infectionDay(CurrentPlayer.InfectionSeverity, false, CurrentPlayer.CharacterClass);
            }

            if (CurrentPlayer.Tested == true) { 
                CurrentPlayer.DaysSinceTested++; }
            if (CurrentPlayer.InfectionSeverity >= 16) //infection message
            {
                if (CurrentPlayer.ConfirmedInfection == false && CurrentPlayer.Tested==false)
                {
                    switch (CurrentPlayer.InfectionSeverity)
                    {
                        case 16:
                            CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16", "Any", 1));
                            //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16", "Any", 1); //get tested
                            break;
                        case 17:
                            CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "17", "Any", 2));
                            //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "17", "Any", 2);
                            break;
                        case 18:
                            CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "18", "Any", 3));
                            //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "18", "Any", 3);
                            break;
                        case 19:
                            CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "19", "Any", 4));
                            //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "19", "Any", 4);
                            break;
                        case 20: //should only be there if obese
                            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5);
                            return;
                            //CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5));
                            //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5);
                            //break;
                        default:
                            CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5));
                            //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5);
                            break;
                    }
                }
            }
            if (CurrentPlayer.DaysSinceTested == 2)
            {
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 8));
                //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 8); //get confirmed positive
            }
            if (CurrentPlayer.ConfirmedInfection == true && CurrentPlayer.Hospitalized == false)
            {
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+ ", "Any", 9));
                //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+ ", "Any", 9); //get to the hospital
            }
            if ((CurrentPlayer.Job == "Customer Representative" || CurrentPlayer.Job == "Banker") && !quarantineTomorrow) //REGULAR
            {
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1)); //regular next day w/job
            }
            else
            {
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2)); //regular next day w/o job
            }
            //FAMILY SICKNESS AND HEALTH //1. update healths
            List<int> Healths = new List<int> { CurrentFamilyHealth.CharacterHealth, CurrentFamilyHealth.SpouseHealth, CurrentFamilyHealth.MomHealth, CurrentFamilyHealth.DadHealth, CurrentFamilyHealth.DaughterHealth, CurrentFamilyHealth.SonHealth };
            List<bool> Infections = new List<bool> { CurrentFamilyHealth.CharacterInfected, CurrentFamilyHealth.SpouseInfected, CurrentFamilyHealth.MomInfected, CurrentFamilyHealth.DadInfected, CurrentFamilyHealth.DaughterInfected, CurrentFamilyHealth.SonInfected };
            bool obesity = false;
            if (CurrentPlayer.CharacterClass == "Obese") { obesity = true; }
            List<int> newHealths = gsf.updateHealths(Healths, Infections, obesity);
            CurrentFamilyHealth.CharacterHealth = newHealths[0];
            CurrentFamilyHealth.SpouseHealth = newHealths[1];
            CurrentFamilyHealth.MomHealth = newHealths[2];
            CurrentFamilyHealth.DadHealth = newHealths[3];
            CurrentFamilyHealth.DaughterHealth = newHealths[4];
            CurrentFamilyHealth.SonHealth = newHealths[5];
            //2. update infections
            if (CurrentFamilyHealth.CharacterInfected == true) 
            {
                Infections=gsf.updateInfections(Infections);
            }
            CurrentFamilyHealth.SpouseInfected = Infections[1];
            CurrentFamilyHealth.MomInfected = Infections[2];
            CurrentFamilyHealth.DadInfected = Infections[3];
            CurrentFamilyHealth.DaughterInfected = Infections[4];
            CurrentFamilyHealth.SonInfected = Infections[5];
            if (CurrentPlayer.InfectionSeverity > 0) { CurrentFamilyHealth.CharacterInfected = true; } else { CurrentFamilyHealth.CharacterInfected = false; }
            //3.5. update infections2
            Infections = gsf.updateInfections2(Infections);
            CurrentFamilyHealth.SpouseInfected = Infections[1];
            CurrentFamilyHealth.MomInfected = Infections[2];
            CurrentFamilyHealth.DadInfected = Infections[3];
            CurrentFamilyHealth.DaughterInfected = Infections[4];
            CurrentFamilyHealth.SonInfected = Infections[5];
            //3. update alive
            List<string> Images = new List<string> { CurrentFamilyHealth.CharacterImage, CurrentFamilyHealth.SpouseImage, CurrentFamilyHealth.MomImage, CurrentFamilyHealth.DadImage, CurrentFamilyHealth.DaughterImage, CurrentFamilyHealth.SonImage };
            List<bool> Living = new List<bool> { CurrentFamilyHealth.CharacterAlive, CurrentFamilyHealth.SpouseAlive, CurrentFamilyHealth.MomAlive, CurrentFamilyHealth.DadAlive, CurrentFamilyHealth.DaughterAlive, CurrentFamilyHealth.SonAlive };
            Living = gsf.updateAlive(Healths, Living);
            CurrentFamilyHealth.CharacterAlive = Living[0];
            CurrentFamilyHealth.SpouseAlive = Living[1];
            CurrentFamilyHealth.MomAlive = Living[2];
            CurrentFamilyHealth.DadAlive = Living[3];
            CurrentFamilyHealth.DaughterAlive = Living[4];
            CurrentFamilyHealth.SonAlive = Living[5];
            //4. update images
            Images = gsf.updateImages(Images, Living, Infections);
            CurrentFamilyHealth.CharacterImage = Images[0];
            CurrentFamilyHealth.SpouseImage = Images[1];
            CurrentFamilyHealth.MomImage = Images[2];
            CurrentFamilyHealth.DadImage = Images[3];
            CurrentFamilyHealth.DaughterImage = Images[4];
            CurrentFamilyHealth.SonImage = Images[5];

            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);


        }

        public void DinnerBread()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 5);
        }

        public void SocialDistanceOk() //1 quarantine message
        {
            if (CurrentPlayer.NextDayMessages.Count > 0)
            {
                CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
                CurrentPlayer.NextDayMessages.RemoveAt(0);
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Any", 3);
            }
            
        }
        public void CrisisOk()
        {
            if (CurrentPlayer.NextDayMessages.Count > 0)
            {
                CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
                CurrentPlayer.NextDayMessages.RemoveAt(0);
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Any", 3);
            }
        }

        public void TestYes() //1
        {
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation =CurrentWorld.LocationAt(CurrentLocation.XCoordinate-1, CurrentLocation.YCoordinate);
            if (gsf.testChance(CurrentPlayer.Stage)) { CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 6); CurrentPlayer.Tested = true; } else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 7);
            }
        }
        public void TestNo() //1
        {
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
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

        public void EmergencyYes() //not confirmed infection
        { //1
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            if (gsf.hospitalizationChance(CurrentPlayer.Stage) == true)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                CurrentPlayer.Hospitalized = true; //chance
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 9); //"You were admitted to the hospital."
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Crisis", "Any", "16+", "Any", 1); //The hospital does not have enough ventilators to accomodate you."
            }
        }

        public void EmergencyNo() //not confirmed infection
        { //1
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            if (CurrentPlayer.Stage == "Regular")
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1); //"Do you want to go to work?"
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Any", 3); //Do you want to go to the store? You should maintain social distancing."
            }
        }

        public void HospitalizedYes()
        { //1
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentPlayer.ConfirmedInfection = true;
            if (gsf.hospitalizationChance(CurrentPlayer.Stage) == true)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                CurrentPlayer.Hospitalized = true; //chance
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 9); //"You were admitted to the hospital."
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Crisis", "Any", "16+", "Any", 1); //The hospital does not have enough ventilators to accomodate you."
            }
        }

        public void HospitalizedNo()
        { //1
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentPlayer.ConfirmedInfection = true;
            if (CurrentPlayer.Stage == "Regular")
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1); //"Do you want to go to work?"
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Any", 3); //Do you want to go to the store? You should maintain social distancing."
            }
        }

        public void AdmittedOk()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "16+", "Any", 1); //You miserably spent your day in the hospital.
        }

        public void NotAdmittedOk()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            if (CurrentPlayer.Stage == "Regular")
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1); //"Do you want to go to work?"
            }
            else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Any", 3); //Do you want to go to the store? You should maintain social distancing."
            }
        }

        public void HospitalMiserable()
        {
            CurrentPlayer.NextDayMessages.Clear();
            CurrentDay.Date = gsf.nextDay(CurrentDay.Date);
            CurrentDailyUpdate = CurrentUpdates.UpdateAt(CurrentPlayer.City, CurrentDailyUpdate.Index+1);
            RaiseUpdate(CurrentDay.Date);
            RaiseUpdate(CurrentDailyUpdate.CaseUpdate);
            CurrentPlayer.DaysSinceStart++;
            if (CurrentPlayer.Stage != "Regular" && CurrentPlayer.City == "London" && CurrentPlayer.Job != "None")
            {
                CurrentPlayer.Money += 79; //80% of income
            }
            bool quarantineTomorrow = false;
            if (CurrentPlayer.City == "London" && CurrentDay.Date == "3/16/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "1/23/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "3/22/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "3/19/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (quarantineTomorrow == true) //quarantinetomorrow
            {
                if (CurrentPlayer.Job == "Customer Representative" || CurrentPlayer.Job == "Banker")  //person w/ job quarantine message
                {
                    CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Yes", 1));
                    CurrentPlayer.Job = "None";
                    CurrentPlayer.Money += CurrentPlayer.DailyIncome * CurrentPlayer.DaysSinceStart;
                }
                else
                {
                    CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "No", 1)); //person w/o job quarantine message
                }
            }
            bool crisisTomorrow = false;
            if (CurrentPlayer.City == "London" && CurrentDay.Date == "3/31/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "1/23/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "4/5/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "4/2/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (crisisTomorrow == true)
            {
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Crisis", "Any", "Any", "Yes", 1));
            }
            bool surviveTomorrow = false;
            if (CurrentPlayer.City == "London" && CurrentDay.Date == "4/22/20") { surviveTomorrow = true; }
            if (CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "2/29/20") { surviveTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "4/25/20") { surviveTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "4/28/20") { surviveTomorrow = true; }
            if (surviveTomorrow == true)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Crisis", "Any", "Any", "Yes", 2);
                return;
            }
            int originalSeverity = CurrentPlayer.InfectionSeverity;
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false); //update infection
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity > 0)
            {
                CurrentPlayer.InfectionSeverity = gsf.infectionDay(CurrentPlayer.InfectionSeverity, true, CurrentPlayer.CharacterClass);
            }

            if (originalSeverity > CurrentPlayer.InfectionSeverity)
            {
                if (CurrentPlayer.InfectionSeverity == 0)
                {
                    //CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Any", 3));
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Any", 3); //"You have officially recovered from the coronavirus and may go home."
                    return;
                }
                else
                {
                    CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Any", 2));
                    //CurrentQuestionStatus = CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Any", 2); //You spent your day in the hospital. You feel slightly better, but lonely.
                }
                
            }
            else //original severity is less than current severity
            {
                if (CurrentPlayer.InfectionSeverity >= 20)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5); //You passed away from the coronavirus.
                    return;
                }
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "16+", "Any", 1));
               // CurrentQuestionStatus = CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "16+", "Any", 1); //You miserably spent your day in the hospital.
            }
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
        }
        public void HospitalBetter()
        {
            CurrentPlayer.NextDayMessages.Clear();
            CurrentDay.Date = gsf.nextDay(CurrentDay.Date);
            CurrentDailyUpdate = CurrentUpdates.UpdateAt(CurrentPlayer.City, CurrentDailyUpdate.Index+1);
            RaiseUpdate(CurrentDay.Date);
            RaiseUpdate(CurrentDailyUpdate.CaseUpdate);
            CurrentPlayer.DaysSinceStart++;
            if (CurrentPlayer.Stage != "Regular" && CurrentPlayer.City == "London" && CurrentPlayer.Job != "None")
            {
                CurrentPlayer.Money += 79; //80% of income
            }
            bool quarantineTomorrow = false;
            if (CurrentPlayer.City == "London" && CurrentDay.Date == "3/16/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "1/23/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "3/22/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "3/19/20") { CurrentPlayer.Stage = "Quarantine"; quarantineTomorrow = true; }
            if (quarantineTomorrow == true) //quarantinetomorrow
            {
                if (CurrentPlayer.Job == "Customer Representative" || CurrentPlayer.Job == "Banker")  //person w/ job quarantine message
                {
                    CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Yes", 1));
                    CurrentPlayer.Job = "None";
                    CurrentPlayer.Money += CurrentPlayer.DailyIncome * CurrentPlayer.DaysSinceStart;
                }
                else
                {
                    CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Yes", 2)); //person w/o job quarantine message
                }
            }
            bool crisisTomorrow = false;
            if (CurrentPlayer.City == "London" && CurrentDay.Date == "3/31/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "1/23/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "4/5/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "4/2/20") { CurrentPlayer.Stage = "Crisis"; crisisTomorrow = true; }
            if (crisisTomorrow == true)
            {
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Crisis", "Any", "Any", "Yes", 1));
            }
            bool surviveTomorrow = false;
            if (CurrentPlayer.City == "London" && CurrentDay.Date == "4/22/20") { surviveTomorrow = true; }
            if (CurrentPlayer.City == "Wuhan" && CurrentDay.Date == "2/29/20") { surviveTomorrow = true; }
            if (CurrentPlayer.City == "New York City" && CurrentDay.Date == "4/25/20") { surviveTomorrow = true; }
            if (CurrentPlayer.City == "Los Angeles" && CurrentDay.Date == "4/28/20") { surviveTomorrow = true; }
            if (surviveTomorrow == true)
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Crisis", "Any", "Any", "Yes", 2);
                return;
            }

            int originalSeverity = CurrentPlayer.InfectionSeverity;
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false); //update infection
            CurrentPlayer.BodyGif = gsf.updateBodyDiagram(CurrentPlayer.InfectionSeverity);
            if (CurrentPlayer.InfectionSeverity > 0)
            {
                CurrentPlayer.InfectionSeverity = gsf.infectionDay(CurrentPlayer.InfectionSeverity, true, CurrentPlayer.CharacterClass);
            }

            if (originalSeverity > CurrentPlayer.InfectionSeverity)
            {
                if (CurrentPlayer.InfectionSeverity == 0)
                {
                    //CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Any", 3));
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Any", 3); //"You have officially recovered from the coronavirus and may go home."
                    return;
                }
                else
                {
                    CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Any", 2));
                    //CurrentQuestionStatus = CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "Any", "Any", 2); //You spent your day in the hospital. You feel slightly better, but lonely.
                }

            }
            else //original severity is less than current severity
            {
                if (CurrentPlayer.InfectionSeverity >= 20)
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5); //You passed away from the coronavirus.
                    return;
                }
                CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "16+", "Any", 1));
                // CurrentQuestionStatus = CurrentQuestion.StatusAt("Hospital", "Any", "Any", "Any", "16+", "Any", 1); //You miserably spent your day in the hospital.
            }
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
        }

        public void HospitableRecovered() //1
        {
            CurrentPlayer.NextDayMessages.Clear();
            CurrentPlayer.Hospitalized = false;
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            if(CurrentPlayer.Job != "None")
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1); //"Do you want to go to work?"
            }
            else
            {
                if (CurrentPlayer.Stage == "Regular")
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", 2); //"Do you want to go to the store?"
                }
                else
                {
                    CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Quarantine", "Any", "Any", "Any", 3); //Do you want to go to the store? You should only go if necessary and maintain social distancing.
                }
            }
        }

        public void HospitalQuarantineOk()
        {
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
        }

        public void StarvedOk()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 6);
            //FAMILY SICKNESS AND HEALTH //1. update healths
            List<int> Healths = new List<int> { CurrentFamilyHealth.CharacterHealth, CurrentFamilyHealth.SpouseHealth, CurrentFamilyHealth.MomHealth, CurrentFamilyHealth.DadHealth, CurrentFamilyHealth.DaughterHealth, CurrentFamilyHealth.SonHealth };
            List<bool> Infections = new List<bool> { CurrentFamilyHealth.CharacterInfected, CurrentFamilyHealth.SpouseInfected, CurrentFamilyHealth.MomInfected, CurrentFamilyHealth.DadInfected, CurrentFamilyHealth.DaughterInfected, CurrentFamilyHealth.SonInfected };
            bool obesity = false;
            if (CurrentPlayer.CharacterClass == "Obese") { obesity = true; }
            List<int> newHealths = gsf.updateHealths(Healths, Infections, obesity);
            CurrentFamilyHealth.CharacterHealth = newHealths[0];
            CurrentFamilyHealth.SpouseHealth = newHealths[1];
            CurrentFamilyHealth.MomHealth = newHealths[2];
            CurrentFamilyHealth.DadHealth = newHealths[3];
            CurrentFamilyHealth.DaughterHealth = newHealths[4];
            CurrentFamilyHealth.SonHealth = newHealths[5];
            //2. update infections
            if (CurrentFamilyHealth.CharacterInfected == true)
            {
                Infections = gsf.updateInfections(Infections);
            }
            CurrentFamilyHealth.SpouseInfected = Infections[1];
            CurrentFamilyHealth.MomInfected = Infections[2];
            CurrentFamilyHealth.DadInfected = Infections[3];
            CurrentFamilyHealth.DaughterInfected = Infections[4];
            CurrentFamilyHealth.SonInfected = Infections[5];
            if (CurrentPlayer.InfectionSeverity > 0) { CurrentFamilyHealth.CharacterInfected = true; } else { CurrentFamilyHealth.CharacterInfected = false; }
            //3. update alive
            List<string> Images = new List<string> { CurrentFamilyHealth.CharacterImage, CurrentFamilyHealth.SpouseImage, CurrentFamilyHealth.MomImage, CurrentFamilyHealth.DadImage, CurrentFamilyHealth.DaughterImage, CurrentFamilyHealth.SonImage };
            List<bool> Living = new List<bool> { CurrentFamilyHealth.CharacterAlive, CurrentFamilyHealth.SpouseAlive, CurrentFamilyHealth.MomAlive, CurrentFamilyHealth.DadAlive, CurrentFamilyHealth.DaughterAlive, CurrentFamilyHealth.SonAlive };
            Living = gsf.updateAlive(Healths, Living);
            CurrentFamilyHealth.CharacterAlive = Living[0];
            CurrentFamilyHealth.SpouseAlive = Living[1];
            CurrentFamilyHealth.MomAlive = Living[2];
            CurrentFamilyHealth.DadAlive = Living[3];
            CurrentFamilyHealth.DaughterAlive = Living[4];
            CurrentFamilyHealth.SonAlive = Living[5];
            //3.5. update infections2
            Infections = gsf.updateInfections2(Infections);
            CurrentFamilyHealth.SpouseInfected = Infections[1];
            CurrentFamilyHealth.MomInfected = Infections[2];
            CurrentFamilyHealth.DadInfected = Infections[3];
            CurrentFamilyHealth.DaughterInfected = Infections[4];
            CurrentFamilyHealth.SonInfected = Infections[5];
            //4. update images
            Images = gsf.updateImages(Images, Living, Infections);
            CurrentFamilyHealth.CharacterImage = Images[0];
            CurrentFamilyHealth.SpouseImage = Images[1];
            CurrentFamilyHealth.MomImage = Images[2];
            CurrentFamilyHealth.DadImage = Images[3];
            CurrentFamilyHealth.DaughterImage = Images[4];
            CurrentFamilyHealth.SonImage = Images[5];

        }

        public void DeathOk()
        {
            //Player reset
            CurrentPlayer.NextDayMessages.Clear();
            CurrentPlayer.Name = "Tiffily";
            CurrentPlayer.CharacterClass = "";
            CurrentPlayer.Job = "";
            CurrentPlayer.Bread = 2;
            CurrentPlayer.ToiletPaper = 3m;
            CurrentPlayer.City = "";
            CurrentPlayer.Mode = "";
            CurrentPlayer.Stage = "Regular";
            CurrentPlayer.InfectionChance = 0;
            CurrentPlayer.InfectionSeverity = 0;
            CurrentPlayer.DaysSinceTested = 0;
            CurrentPlayer.Tested = false;
            CurrentPlayer.Hospitalized = false;
            CurrentPlayer.DaysSinceStart = 0;
            CurrentPlayer.Karma = 50;
            CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Regular", "Any", "Any", "Yes", 1));
            CurrentPlayer.BodyGif = "/Engine;component/Images/Body/body1.gif";
            //Family reset
            CurrentFamilyHealth.CharacterHealth = 90;
            CurrentFamilyHealth.MomHealth = 67;
            CurrentFamilyHealth.DadHealth = 62;
            CurrentFamilyHealth.SpouseHealth = 95;
            CurrentFamilyHealth.DaughterHealth = 90;
            CurrentFamilyHealth.SonHealth = 90;

            CurrentFamilyHealth.CharacterInfected = false;
            CurrentFamilyHealth.MomInfected = false;
            CurrentFamilyHealth.DadInfected = false;
            CurrentFamilyHealth.SpouseInfected = false;
            CurrentFamilyHealth.DaughterInfected = false;
            CurrentFamilyHealth.SonInfected = false;

            CurrentFamilyHealth.CharacterAlive = true;
            CurrentFamilyHealth.MomAlive = true;
            CurrentFamilyHealth.DadAlive = true;
            CurrentFamilyHealth.SpouseAlive = true;
            CurrentFamilyHealth.DaughterAlive = true;
            CurrentFamilyHealth.SonAlive = true;

            CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/player.png";
            CurrentFamilyHealth.MomImage = "/Engine;component/Images/Family/mom.png";
            CurrentFamilyHealth.DadImage = "/Engine;component/Images/Family/dad.png";
            CurrentFamilyHealth.SpouseImage = "/Engine;component/Images/Family/spouse.png";
            CurrentFamilyHealth.DaughterImage = "/Engine;component/Images/Family/daughter.png";
            CurrentFamilyHealth.SonImage = "/Engine;component/Images/Family/son.png";
            //Location reset
            CurrentLocation = CurrentWorld.LocationAt(-1,-1);


            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "None", "Regular", "Any", "Any", "Yes", 1);
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

        public void RaiseUpdate(string update)
        {
            OnUpdateRaised?.Invoke(this, new UpdateMessageEventArgs(update));
        }

    }
}