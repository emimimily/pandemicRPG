﻿using System;
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
using Engine.EventArgs;

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

            _gameSession.OnMessageRaised += OnGameMessageRaised;

            DataContext = _gameSession;

        }
        private void Button1Click(object sender, RoutedEventArgs e)
        { 
            switch (QuestionText.Text)
            {
                case "What difficulty do you want to play on?":
                    _gameSession.ModeEasy();
                    Button1.Content = "London";
                    Button2.Content = "Los Angeles";
                    break;
                case "Which easy mode city do you want to play in?":
                    _gameSession.CityLondon();
                    Button1.Content = "Yes";
                    Button2.Content = "No";
                    _gameSession.RaiseMessage(_gameSession.CurrentDay.Date);
                    _gameSession.RaiseMessage("You live in London, England, as a banker. ");
                    break;
                case "Which hard mode city do you want to play in?":
                    _gameSession.CityWuhan();
                    Button1.Content = "Yes";
                    Button2.Content = "No";
                    _gameSession.RaiseMessage("You live in Wuhan, China, as a bank customer representative.");
                    break;
                case "Do you want to go to work?":
                    _gameSession.WorkYes();
                    _gameSession.RaiseMessage("You went to work.");
                    break;
                case "You shook hands with your boss at work, who seems to be sick; do you want to wash your hands? This will take time, and reduce your day’s pay by 10%.":
                    _gameSession.WorkWashYes();
                    _gameSession.RaiseMessage("You shook hands with your sick boss today, but you washed your hands.");
                    break;
                case "Your boss did not consider your excuse to be valid, so you were fired from your job.":
                    _gameSession.FiredOk();
                    Button1.Content = "Yes";
                    _gameSession.HasButton2 = true;
                    break;
                case "Do you want to go to the store?":
                    _gameSession.StoreYes();
                    _gameSession.HasButton1 = false;
                    _gameSession.HasUpDown = true;
                    Button2.Content = "Ok";
                    break;
                case "When you came home, your friend Dave invited you to a party. Will you go?":
                    _gameSession.PartyYes();
                    if (QuestionText.Text == "Who will eat dinner today?")
                    {
                        Button1.Content = "Check all";
                        Button2.Content = "Ok";
                    }
                    break;
                case "Do you want to wash your hands before you eat dinner? It will cost 10% of a toilet paper roll.":
                    _gameSession.HomeWashYes();
                    Button1.Content = "Check all";
                    Button2.Content = "Ok";
                    _gameSession.CurrentPlayer.ToiletPaper -= .1m;
                    _gameSession.HasCheckMe = true;
                    _gameSession.HasCheckSpouse = true;
                    _gameSession.HasCheckMother = true;
                    _gameSession.HasCheckFather = true;
                    _gameSession.HasCheckDaughter = true;
                    _gameSession.HasCheckSon = true;
                    break;
                case "Who will eat dinner today?":
                    Character.IsChecked = !Character.IsChecked;
                    Spouse.IsChecked = !Spouse.IsChecked;
                    Mother.IsChecked = !Mother.IsChecked;
                    Father.IsChecked = !Father.IsChecked;
                    Daughter.IsChecked = !Daughter.IsChecked;
                    Son.IsChecked = !Son.IsChecked;
                    break;
                case "This morning you recieved an email-- due to concerns over the coronavirus, you may no longer go to work. You were laid off.":
                    _gameSession.SocialDistanceOk();
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "You should begin practicing social distancing due to concerns over the virus.":
                    _gameSession.SocialDistanceOk();
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "Do you want to go to the store? You should maintain social distancing.":
                    _gameSession.StoreYes();
                    _gameSession.HasButton1 = false;
                    _gameSession.HasButton2 = true;
                    _gameSession.HasUpDown = true;
                    Button2.Content = "Ok";
                    break;
                case "You are not feeling well, and coming down with a fever. Do you want to get tested for the coronavirus?":
                    _gameSession.TestYes();
                    _gameSession.HasButton2 = false;
                    Button1.Content = "Ok";
                    break;
                case "Along with your fever, you are starting to experience dry cough and shortness of breath. Do you want to get tested for the coronavirus?":
                    _gameSession.TestYes();
                    _gameSession.HasButton2 = false;
                    Button1.Content = "Ok";
                    break;
                case "You seem to be losing your sense of smell and taste. You had diarrhea this morning too. Do you want to get tested for the coronavirus?":
                    _gameSession.TestYes();
                    _gameSession.HasButton2 = false;
                    Button1.Content = "Ok";
                    break;
                case "The hospital did not have enough tests to test you for the virus. You were instructed to go back home and self-quarantine.":
                    _gameSession.NotEnoughTests();
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "You were tested for COVID-19 and will recieve results in two days. You were instructed to go back home and self-quarantine.":
                    _gameSession.NotEnoughTests();
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                default:
                    break;
            }
            
        }
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            switch (QuestionText.Text)
            {
                case "What difficulty do you want to play on?":
                    _gameSession.ModeHard();
                    Button1.Content = "Wuhan";
                    Button2.Content = "New York";
                    break;
                case "Which easy mode city do you want to play in?":
                    _gameSession.CityLosAngeles();
                    Button1.Content = "Yes";
                    Button2.Content = "No";
                    break;
                case "Which hard mode city do you want to play in?":
                    _gameSession.CityNewYork();
                    Button1.Content = "Yes";
                    Button2.Content = "No";
                    break;
                case "Do you want to go to work?":
                    _gameSession.WorkNo();
                    Button1.Content = "Ok";
                    _gameSession.HasButton2 = false;
                    break;
                case "You shook hands with your boss at work, who seems to be sick; do you want to wash your hands? This will take time, and reduce your day’s pay by 10%.":
                    _gameSession.WorkWashNo();
                    break;
                case "Do you want to go to the store?":
                    _gameSession.StoreNo();
                    if (QuestionText.Text == "Who will eat dinner today?")
                    {
                        Button1.Content = "Check all";
                        Button2.Content = "Ok";
                    }
                    break;
                case "How much bread do you want to buy?":
                    if (_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 5)
                    {
                        _gameSession.BreadOk();
                        _gameSession.CurrentPlayer.Bread += Int16.Parse(txtNum.Text);
                        _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 5;
                        txtNum.Text = "0";
                    }
                    else
                    {
                        _gameSession.BreadMoney();
                    }
                    break;
                case "How much bread do you want to buy? \n You don't have enough money. Select a lower quantity.":
                    if (_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 5)
                    {
                        _gameSession.BreadOk();
                        _gameSession.CurrentPlayer.Bread += Int16.Parse(txtNum.Text);
                        _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 5;
                        txtNum.Text = "0";
                    }
                    else
                    {
                        _gameSession.BreadMoney();
                    }
                    break;
                case "How much toilet paper do you want to buy?":
                    if (_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 6)
                    {
                        _gameSession.CurrentPlayer.ToiletPaper += Int16.Parse(txtNum.Text);
                        _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 6;
                        _gameSession.TPOk();
                        txtNum.Text = "0";
                        _gameSession.HasButton1 = true;
                        _gameSession.HasUpDown = false;
                        Button2.Content = "No";
                        if (QuestionText.Text == "Who will eat dinner today?")
                        {
                            Button1.Content = "Check all";
                            Button2.Content = "Ok";
                        }
                        break;
                    }
                    else
                    {
                        _gameSession.TPMoney();
                    }
                    break;
                case "How much toilet paper do you want to buy? \n You don't have enough money. Select a lower quantity":
                    if (_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 6)
                    {
                        _gameSession.TPOk();
                        _gameSession.CurrentPlayer.ToiletPaper += Int16.Parse(txtNum.Text);
                        _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 6;
                        txtNum.Text = "0";
                        _gameSession.HasButton1 = true;
                        _gameSession.HasUpDown = false;
                        Button2.Content = "No";
                        if(QuestionText.Text=="Who will eat dinner today?")
                        {
                            Button1.Content = "Check all";
                            Button2.Content = "Ok";
                        }
                        break;
                    }
                    else
                    {
                        _gameSession.TPMoney();
                    }
                    break;
                case "When you came home, your friend Dave invited you to a party. Will you go?":
                    _gameSession.PartyNo();
                    if (QuestionText.Text == "Who will eat dinner today?")
                    {
                        Button1.Content = "Check all";
                        Button2.Content = "Ok";
                    }
                    break;
                case "Do you want to wash your hands before you eat dinner? It will cost 10% of a toilet paper roll.":
                    _gameSession.HomeWashNo();
                    Button1.Content = "Check all";
                    Button2.Content = "Ok";
                    _gameSession.HasCheckMe = true;
                    _gameSession.HasCheckSpouse = true;
                    _gameSession.HasCheckMother = true;
                    _gameSession.HasCheckFather = true;
                    _gameSession.HasCheckDaughter = true;
                    _gameSession.HasCheckSon = true;
                    break;
                case "Who will eat dinner today?":
                    int membersEaten = 0;
                    if (Character.IsChecked==true) { membersEaten++; }
                    if (Spouse.IsChecked == true) { membersEaten++; }
                    if (Mother.IsChecked == true) { membersEaten++; }
                    if (Father.IsChecked == true) { membersEaten++; }
                    if (Daughter.IsChecked == true) { membersEaten++; }
                    if (Son.IsChecked == true) { membersEaten++; }
                    if (membersEaten <= _gameSession.CurrentPlayer.Bread*2)
                    {
                        _gameSession.CurrentPlayer.Bread -= membersEaten * .5;

                        _gameSession.DinnerOk();
                        if (_gameSession.CurrentPlayer.City == "London" && _gameSession.CurrentDay.Date=="3/23/20") //quarantine message
                        {

                            _gameSession.HasButton2 = false;
                            Button1.Content = "Ok";
                            Button2.Content = "No";

                        }
                        else
                        {
                            Button1.Content = "Yes";
                            Button2.Content = "No";
                        }

                        Character.IsChecked = false;
                        Spouse.IsChecked = false;
                        Mother.IsChecked = false;
                        Father.IsChecked = false;
                        Daughter.IsChecked = false;
                        Son.IsChecked = false;

                        _gameSession.HasCheckMe = false;
                        _gameSession.HasCheckSpouse = false;
                        _gameSession.HasCheckMother = false;
                        _gameSession.HasCheckFather = false;
                        _gameSession.HasCheckDaughter = false;
                        _gameSession.HasCheckSon = false;
                        _gameSession.RaiseMessage("");
                        _gameSession.RaiseMessage(_gameSession.CurrentDay.Date);
                    }
                    else
                    {
                        _gameSession.DinnerBread();
                    }
                    break;

                case "Who will eat dinner today? \n You do not have enough bread. Select less family members.":
                    int membersEaten2 = 0;
                    if (Character.IsChecked == true) { membersEaten2++; }
                    if (Spouse.IsChecked == true) { membersEaten2++; }
                    if (Mother.IsChecked == true) { membersEaten2++; }
                    if (Father.IsChecked == true) { membersEaten2++; }
                    if (Daughter.IsChecked == true) { membersEaten2++; }
                    if (Son.IsChecked == true) { membersEaten2++; }
                    if (membersEaten2 <= _gameSession.CurrentPlayer.Bread*2)
                    {
                        _gameSession.CurrentPlayer.Bread -= membersEaten2 * .5;

                        _gameSession.DinnerOk();
                        if (_gameSession.CurrentPlayer.Stage == "Quarantine")
                        {
                            _gameSession.HasButton2 = false;
                            Button1.Content = "Ok";
                            Button2.Content = "No";
                        } else
                        {
                            Button1.Content = "Yes";
                            Button2.Content = "No";
                        }

                        Character.IsChecked = false;
                        Spouse.IsChecked = false;
                        Mother.IsChecked = false;
                        Father.IsChecked = false;
                        Daughter.IsChecked = false;
                        Son.IsChecked = false;

                        _gameSession.HasCheckMe = false;
                        _gameSession.HasCheckSpouse = false;
                        _gameSession.HasCheckMother = false;
                        _gameSession.HasCheckFather = false;
                        _gameSession.HasCheckDaughter = false;
                        _gameSession.HasCheckSon = false;

                        
                    }
                    else
                    {
                        _gameSession.DinnerBread();
                    }
                    break;
                case "Do you want to go to the store? You should maintain social distancing.":
                    _gameSession.StoreNo();
                    if (QuestionText.Text == "Who will eat dinner today?")
                    {
                        Button1.Content = "Check all";
                        Button2.Content = "Ok";
                    }
                    break;
                case "You are not feeling well, and coming down with a fever. Do you want to get tested for the coronavirus?":
                    _gameSession.TestNo();
                    break;
                case "Along with your fever, you are starting to experience dry cough and shortness of breath. Do you want to get tested for the coronavirus?":
                    _gameSession.TestNo();
                    break;
                case "You seem to be losing your sense of smell and taste. You had diarrhea this morning too. Do you want to get tested for the coronavirus?":
                    _gameSession.TestNo();
                    break;
                default:
                    break;
            }

        }

        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
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