using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine.Models
{
    public class FamilyHealth : INotifyPropertyChanged
    {
        private int _characterHealth;
        private int _momHealth;
        private int _dadHealth;
        private int _spouseHealth;
        private int _sonHealth;
        private int _daughterHealth;

        public int CharacterHealth
        {
            get
            { return _characterHealth; }
            set
            {
                _characterHealth = value;
                OnPropertyChanged("CharacterHealth");
            }
        }
        public int MomHealth
        {
            get
            { return _momHealth; }
            set
            {
                _momHealth = value;
                OnPropertyChanged("MomHealth");
            }
        }

        public int DadHealth
        {
            get
            { return _dadHealth; }
            set
            {
                _dadHealth = value;
                OnPropertyChanged("DadHealth");
            }
        }

        public int SpouseHealth
        {
            get
            { return _spouseHealth; }
            set
            {
                _spouseHealth = value;
                OnPropertyChanged("SpouseHealth");
            }
        }

        public int SonHealth
        {
            get
            { return _sonHealth; }
            set
            {
                _sonHealth = value;
                OnPropertyChanged("SonHealth");
            }
        }

        public int DaughterHealth
        {
            get
            { return _daughterHealth; }
            set
            {
                _daughterHealth = value;
                OnPropertyChanged("DaughterHealth");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}