using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.ViewModels;
using System.Text.RegularExpressions;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession;

        public MainWindow()
        {
            InitializeComponent();

            _gameSession = new GameSession();

            DataContext = _gameSession;

        }
        private void Button1Click(object sender, RoutedEventArgs e)
        { 
            switch (QuestionText.Text)
            {
                case "Do you want to go to work?":
                    _gameSession.WorkYes();
                    QuestionText.Text = _gameSession.CurrentQuestionStatus.Message;
                    break;
                case "You shook hands with your boss at work, who seems to be sick; do you want to wash your hands? This will take time, and reduce your day’s pay by 10%.":
                    _gameSession.WorkWash();
                    QuestionText.Text = _gameSession.CurrentQuestionStatus.Message;
                    break;
                case "Your boss did not consider your excuse to be valid, so you were fired from your job.":
                    _gameSession.FiredOk();
                    QuestionText.Text = _gameSession.CurrentQuestionStatus.Message;
                    Button1.Content = "Yes";
                    _gameSession.HasButton2 = true;
                    break;
                case "Do you want to go to the store?":
                    _gameSession.StoreYes();
                    QuestionText.Text = _gameSession.CurrentQuestionStatus.Message;
                    _gameSession.HasButton1 = false;
                    _gameSession.HasUpDown = true;
                    Button2.Content = "Ok";
                    break;
                default:
                    break;
            }
            
        }
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            switch (QuestionText.Text)
            {
                case "Do you want to go to work?":
                    _gameSession.WorkNo();
                    QuestionText.Text = _gameSession.CurrentQuestionStatus.Message;
                    Button1.Content = "Ok";
                    _gameSession.HasButton2 = false;
                    break;
                case "You shook hands with your boss at work, who seems to be sick; do you want to wash your hands? This will take time, and reduce your day’s pay by 10%.":
                    _gameSession.WorkWash();
                    QuestionText.Text = _gameSession.CurrentQuestionStatus.Message;
                    break;
                default:
                    break;
            }

        }

        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }

        public void NumberUpDown()
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            if(NumValue < 20)
            {
                NumValue++;
            }
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if (NumValue > 0)
            {
                NumValue--;
            }
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out _numValue))
                txtNum.Text = _numValue.ToString();
        }


    }
}