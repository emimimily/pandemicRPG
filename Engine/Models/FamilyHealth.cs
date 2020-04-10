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

        private bool _characterInfected;
        private bool _momInfected;
        private bool _dadInfected;
        private bool _spouseInfected;
        private bool _sonInfected;
        private bool _daughterInfected;

        private bool _characterAlive;
        private bool _momAlive;
        private bool _dadAlive;
        private bool _spouseAlive;
        private bool _sonAlive;
        private bool _daughterAlive;

        private string _characterImage;
        private string _momImage;
        private string _dadImage;
        private string _spouseImage;
        private string _daughterImage;
        private string _sonImage;


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

        public bool CharacterInfected
        {
            get
            { return _characterInfected; }
            set
            {
                _characterInfected = value;
                OnPropertyChanged("CharacterInfected");
            }
        }
        public bool MomInfected
        {
            get
            { return _momInfected; }
            set
            {
                _momInfected = value;
                OnPropertyChanged("MomInfected");
            }
        }

        public bool DadInfected
        {
            get
            { return _dadInfected; }
            set
            {
                _dadInfected = value;
                OnPropertyChanged("DadInfected");
            }
        }

        public bool SpouseInfected
        {
            get
            { return _spouseInfected; }
            set
            {
                _spouseInfected = value;
                OnPropertyChanged("SpouseInfected");
            }
        }
        public bool DaughterInfected
        {
            get
            { return _daughterInfected; }
            set
            {
                _daughterInfected = value;
                OnPropertyChanged("DaughterInfected");
            }
        }
        public bool SonInfected
        {
            get
            { return _sonInfected; }
            set
            {
                _sonInfected = value;
                OnPropertyChanged("SonInfected");
            }
        }
        public bool CharacterAlive
        {
            get
            { return _characterAlive; }
            set
            {
                _characterAlive = value;
                OnPropertyChanged("CharacterAlive");
            }
        }

        public bool MomAlive
        {
            get
            { return _momAlive; }
            set
            {
                _momAlive = value;
                OnPropertyChanged("MomAlive");
            }
        }

        public bool DadAlive
        {
            get
            { return _dadAlive; }
            set
            {
                _dadAlive = value;
                OnPropertyChanged("DadAlive");
            }
        }

        public bool SpouseAlive
        {
            get
            { return _spouseAlive; }
            set
            {
                _spouseAlive = value;
                OnPropertyChanged("spouseAlive");
            }
        }

        public bool DaughterAlive
        {
            get
            { return _daughterAlive; }
            set
            {
                _daughterAlive = value;
                OnPropertyChanged("DaughterAlive");
            }
        }
        public bool SonAlive
        {
            get
            { return _sonAlive; }
            set
            {
                _sonAlive = value;
                OnPropertyChanged("SonAlive");
            }
        }

        public string CharacterImage
        {
            get { return _characterImage; }
            set
            {
                _characterImage = value;
                OnPropertyChanged("CharacterImage");
            }
        }
        public string MomImage
        {
            get { return _momImage; }
            set
            {
                _momImage = value;
                OnPropertyChanged("MomImage");
            }
        }
        public string DadImage
        {
            get { return _dadImage; }
            set
            {
                _dadImage = value;
                OnPropertyChanged("DadImage");
            }
        }
        public string SpouseImage
        {
            get { return _spouseImage; }
            set
            {
                _spouseImage = value;
                OnPropertyChanged("SpouseImage");
            }
        }
        public string DaughterImage
        {
            get { return _daughterImage; }
            set
            {
                _daughterImage = value;
                OnPropertyChanged("DaughterImage");
            }
        }
        public string SonImage
        {
            get { return _sonImage; }
            set
            {
                _sonImage = value;
                OnPropertyChanged("SonImage");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}