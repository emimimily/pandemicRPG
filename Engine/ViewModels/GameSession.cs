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
                ConfirmedInfection = false,
                DaysSinceTested = 0,
                Tested = false,
                Hospitalized=false,
                DaysSinceStart=0
                
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

        }
        public void CityLosAngeles()
        {
            CurrentDay.Date = "3/11/20";
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation = CurrentWorld.LocationAt(-3, 0);
            CurrentPlayer.City = "Los Angeles";
            CurrentPlayer.DailyIncome = 168;
        }
        public void CityWuhan()
        {
            CurrentDay.Date = "1/15/20";
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation = CurrentWorld.LocationAt(3, -2);
            CurrentPlayer.City = "Wuhan";
            CurrentPlayer.DailyIncome = 24;

        }
        public void CityNewYork()
        {
            CurrentDay.Date = "3/14/20";
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            CurrentPlayer.City = "New York City";
            CurrentPlayer.DailyIncome = 96;
        }
        public void WorkYes() //1
        {
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Work", "Any", "Regular", "Any", "Any", "Any", gsf.randomNumber(0, 2, 2)); //index, %, possible
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            CurrentPlayer.InfectionChance = 1; //.1
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false);
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
            CurrentPlayer.Money += CurrentPlayer.DailyIncome * CurrentPlayer.DaysSinceStart;
        }
        public void StoreYes()
        {
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
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
            //CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
            //CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentDay.Date = gsf.nextDay(CurrentDay.Date);
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
            //INFECTED
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false); //update infection
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
                            CurrentPlayer.NextDayMessages.Add(CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5));
                            //CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "20", "Any", 5);
                            break;
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
            CurrentQuestionStatus = CurrentPlayer.NextDayMessages[0];
        CurrentPlayer.NextDayMessages.RemoveAt(0);


        }

        public void DinnerBread()
        {
            CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "Any", "Any", 5);
        }

        public void SocialDistanceOk() //1 quarantine message
        {
            CurrentPlayer.NextDayMessages.RemoveAt(0);
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
            CurrentPlayer.NextDayMessages.RemoveAt(0);
            CurrentLocation =CurrentWorld.LocationAt(CurrentLocation.XCoordinate-1, CurrentLocation.YCoordinate);
            if (gsf.testChance(CurrentPlayer.Stage)) { CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 6); CurrentPlayer.Tested = true; } else
            {
                CurrentQuestionStatus = CurrentQuestion.StatusAt("Home", "Any", "Any", "Any", "16+", "Any", 7);
            }
        }
        public void TestNo() //1
        {
            CurrentPlayer.NextDayMessages.RemoveAt(0);
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
            CurrentPlayer.NextDayMessages.RemoveAt(0);
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
            CurrentPlayer.NextDayMessages.RemoveAt(0);
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
            CurrentPlayer.NextDayMessages.RemoveAt(0);
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
            CurrentPlayer.NextDayMessages.RemoveAt(0);
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
            int originalSeverity = CurrentPlayer.InfectionSeverity;
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false); //update infection
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


            int originalSeverity = CurrentPlayer.InfectionSeverity;
            CurrentPlayer.InfectionSeverity = gsf.infection(CurrentPlayer.InfectionChance, CurrentPlayer.InfectionSeverity, false); //update infection
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