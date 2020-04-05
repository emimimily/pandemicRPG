using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class QuestionStatus : INotifyPropertyChanged
    {
        private string _location;
        private string _city;
        private string _stage;
        private string _infectionChance;
        private string _infectionSeverity;
        private string _job;
        private int _index;
        private string _message;

        /*public string Location { get; set; }
        public string City { get; set; }
        public string Stage { get; set; }
        public string InfectionChance { get; set; }
        public string InfectionSeverity { get; set; }
        public string Job { get; set; }
        public int Index { get; set; }
        public string Message { get; set; }*/
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
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
        public string Stage
        {
            get { return _stage; }
            set
            {
                _stage = value;
                OnPropertyChanged("Stage");
            }
        }
        public string InfectionChance
        {
            get { return _infectionChance; }
            set
            {
                _infectionChance = value;
                OnPropertyChanged("InfectionChance");
            }
        }
        public string InfectionSeverity
        {
            get { return _infectionSeverity; }
            set
            {
                _infectionSeverity = value;
                OnPropertyChanged("InfectionSeverity");
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
        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                OnPropertyChanged("Index");
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
