using System;
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
        private int _health;
        private int _money;
        private int _toiletPaper;
        private int _bread;

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
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged("Health");
            }

        }
        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                OnPropertyChanged("Money");
            }

        }

        public int Bread
        {
            get { return _bread; }
            set
            {
                _bread = value;
                OnPropertyChanged("Bread");
            }
        }

        public int ToiletPaper 
        {
            get { return _toiletPaper; }
            set
            {
                _toiletPaper = value;
                OnPropertyChanged("ToiletPaper");
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged (string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}