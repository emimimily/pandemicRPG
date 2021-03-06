﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Engine.Models
{
    public class Player : INotifyPropertyChanged
    {
        private string _name;
        private string _characterClass;
        private string _city;
        //private int _health;
        private int _money;
        private decimal _toiletPaper;
        private double _bread;
        private string _job;
        private string _mode;
        private string _stage;
        private double _infectionChance;
        private int _infectionSeverity;
        private bool _confirmedInfection;
        private bool _tested;
        private int _daysSinceTested;
        private bool _hospitalized;
        private int _daysSinceStart;
        private int _dailyIncome;
        private int _karma;
        private string _bodyGif;
        private int _peopleYouInfected;
        private int _daveParties;

        private List<QuestionStatus> _nextDayMessages;
        private List<int> _breadAge;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged("CharacterClass");
            }

        }

        public string Job
        {
            get { return _job; }
            set
            {
                _job = value;
                OnPropertyChanged("Job");
            }
        }
        /*public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged("Health");
            }

        }*/
        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                OnPropertyChanged("Money");
            }

        }

        public double Bread
        {
            get { return _bread; }
            set
            {
                _bread = value;
                OnPropertyChanged("Bread");
            }
        }

        public decimal ToiletPaper
        {
            get { return _toiletPaper; }
            set
            {
                _toiletPaper = value;
                OnPropertyChanged("ToiletPaper");
            }

        }

        public string Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                OnPropertyChanged("Mode");
            }
        }

        public string Stage
        {
            get { return _stage; }
            set
            {
                _stage = value;
                OnPropertyChanged("Stage");
            }
        }

        public double InfectionChance
        {
            get { return _infectionChance; }
            set
            {
                _infectionChance = value;
                OnPropertyChanged("InfectionChance");
            }
        }

        public int InfectionSeverity
        {
            get { return _infectionSeverity; }
            set
            {
                _infectionSeverity = value;
                OnPropertyChanged("InfectionSeverity");
            }
        }

        public bool Tested
        {
            get { return _tested; }
            set
            {
                _tested = value;
                OnPropertyChanged("Tested");
            }
        }

        public bool ConfirmedInfection
        {
            get { return _confirmedInfection; }
            set
            {
                _confirmedInfection = value;
                OnPropertyChanged("ConfirmedInfection");
            }
        }

        public int DaysSinceTested
        {
            get { return _daysSinceTested; }
            set
            {
                _daysSinceTested = value;
                OnPropertyChanged("DaysSinceTested");
            }
        }

        public bool Hospitalized
        {
            get { return _hospitalized; }
            set
            {
                _hospitalized = value;
                OnPropertyChanged("Hospitalized");
            }
        }

        public int DaysSinceStart
        {
            get { return _daysSinceStart; }
            set
            {
                _daysSinceStart = value;
                OnPropertyChanged("DaysSinceStart");
            }
        }

        public int DailyIncome
        {
            get { return _dailyIncome; }
            set
            {
                _dailyIncome = value;
                OnPropertyChanged("DailyIncome");
            }
        }

        public List<QuestionStatus> NextDayMessages
        {
            get { return _nextDayMessages; }
            set
            {
                _nextDayMessages = value;
                OnPropertyChanged("NextDayMessages");
            }
        }

        public int Karma
        {
            get { return _karma; }
            set
            {
                _karma = value;
                OnPropertyChanged("Karma");
            }
        }

        public string BodyGif
        {
            get { return _bodyGif; }
            set
            {
                _bodyGif = value;
                OnPropertyChanged("BodyGif");
            }
        }

        public int PeopleYouInfected
        {
            get { return _peopleYouInfected; }
            set
            {
                _peopleYouInfected = value;
                OnPropertyChanged("PeopleYouInfected");
            }
        }

        public List<int> BreadAge
        {
            get { return _breadAge; }
            set
            {
                _breadAge = value;
                OnPropertyChanged("BreadAge");
            }
        }

        public int DaveParties
        {
            get { return _daveParties; }
            set
            {
                _daveParties = value;
                OnPropertyChanged("DaveParties");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged (string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}