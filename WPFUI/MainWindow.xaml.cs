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

            _gameSession.OnUpdateRaised += OnUpdateMessageRaised;

            DataContext = _gameSession;

        }
        private void ISClick(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.InfectionSeverity++;
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
                case "Your boss did not consider your excuse to be valid, so you were fired from your job and given your last paycheck.":
                    _gameSession.FiredOk();
                    Button1.Content = "Yes";
                    _gameSession.HasButton2 = true;
                    _gameSession.RaiseMessage("You were fired for not showing up to work.");
                    break;
                case "Do you want to go to the store?":
                    _gameSession.StoreYes();
                    _gameSession.HasButton1 = false;
                    _gameSession.HasUpDown = true;
                    Button2.Content = "Ok";
                    _gameSession.RaiseMessage("You went to the store.");
                    break;
                case "Do you want to wash your hands before you eat dinner? It will cost 10% of a toilet paper roll.":
                    _gameSession.HomeWashYes();
                    _gameSession.RaiseMessage("You washed your hands before dinner.");
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
                    //no raise message?
                    Character.IsChecked = !Character.IsChecked;
                    Spouse.IsChecked = !Spouse.IsChecked;
                    Mother.IsChecked = !Mother.IsChecked;
                    Father.IsChecked = !Father.IsChecked;
                    Daughter.IsChecked = !Daughter.IsChecked;
                    Son.IsChecked = !Son.IsChecked;
                    break;
                case "Who will eat dinner today? \n You do not have enough bread. Select less family members.":
                    Character.IsChecked = !Character.IsChecked;
                    Spouse.IsChecked = !Spouse.IsChecked;
                    Mother.IsChecked = !Mother.IsChecked;
                    Father.IsChecked = !Father.IsChecked;
                    Daughter.IsChecked = !Daughter.IsChecked;
                    Son.IsChecked = !Son.IsChecked;
                    break;
                case "This morning you recieved an email-- due to concerns over the coronavirus, you may no longer go to work. You were laid off and have recieved your last paycheck.":
                    _gameSession.SocialDistanceOk(); //england make 80% message
                    _gameSession.RaiseMessage("The quarantine has officially started.");
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "You should begin practicing social distancing due to concerns over the virus.":
                    _gameSession.SocialDistanceOk();
                    _gameSession.RaiseMessage("The quarantine has officially started.");
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "Do you want to go to the store? You should only go if necessary and maintain social distancing.":
                    _gameSession.StoreYes();
                    _gameSession.RaiseMessage("You went to the store.");
                    _gameSession.HasButton1 = false;
                    _gameSession.HasButton2 = true;
                    _gameSession.HasUpDown = true;
                    Button2.Content = "Ok";
                    break;
                case "You are not feeling well, and coming down with a fever. Do you want to get tested for the coronavirus?":
                    _gameSession.TestYes();
                    _gameSession.RaiseMessage("You went to the hospital and recieved a test for COVID-19.");
                    _gameSession.HasButton2 = false;
                    Button1.Content = "Ok";
                    break;
                case "Along with your fever, you are starting to experience dry cough and shortness of breath. Do you want to get tested for the coronavirus?":
                    _gameSession.TestYes();
                    _gameSession.RaiseMessage("You went to the hospital and recieved a test for COVID-19.");
                    _gameSession.HasButton2 = false;
                    Button1.Content = "Ok";
                    break;
                case "You seem to be losing your sense of smell and taste. You had diarrhea this morning too. Do you want to get tested for the coronavirus?":
                    _gameSession.TestYes();
                    _gameSession.RaiseMessage("You went to the hospital and recieved a test for COVID-19.");
                    _gameSession.HasButton2 = false;
                    Button1.Content = "Ok";
                    break;
                case "You feel extremely unwell. Do you want to go to the emergency room?":
                    _gameSession.EmergencyYes();
                    _gameSession.RaiseMessage("You were rushed to the emergency room.");
                    Button1.Content = "Ok";
                    _gameSession.HasButton2 = false;
                    break;
                case "The hospital did not have enough tests to test you for the virus. You were instructed to go back home and self-quarantine.":
                    _gameSession.NotEnoughTests();
                    _gameSession.RaiseMessage("You were unable to get a test for the coronavirus.");
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "You were tested for COVID-19 and will recieve results in two days. You were instructed to go back home and self-quarantine.":
                    _gameSession.NotEnoughTests();
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "You tested positive for the coronavirus. Do you want to be admitted to the hospital?":
                    _gameSession.HospitalizedYes();
                    _gameSession.HasButton2 = false;
                    Button1.Content = "Ok";
                    break;
                case "Do you want to be admitted to the hospital?":
                    _gameSession.HospitalizedYes();
                    _gameSession.HasButton2 = false;
                    Button1.Content = "Ok";
                    break;
                case "You were admitted to the hospital.":
                    _gameSession.AdmittedOk();
                    _gameSession.RaiseMessage("You were admitted to the hospital for coronavirus.");

                    break;
                case "The hospital does not have enough ventilators to accomodate you.":
                    _gameSession.NotAdmittedOk();
                    _gameSession.RaiseMessage("The hospital did not have enough ventilators to accomodate you.");
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "You miserably spent your day in the hospital.":
                    _gameSession.HospitalMiserable();
                    _gameSession.RaiseMessage("");
                    _gameSession.RaiseMessage(_gameSession.CurrentDay.Date);
                    _gameSession.RaiseMessage("You miserably spent your day in the hospital.");
                    break;
                case "You spent your day in the hospital. You feel slightly better, but lonely.":
                    _gameSession.HospitalBetter();
                    _gameSession.RaiseMessage("");
                    _gameSession.RaiseMessage(_gameSession.CurrentDay.Date);
                    _gameSession.RaiseMessage("You spent your day in the hospital. You felt slightly better, but lonely.");
                    break;
                case "You have officially recovered from the coronavirus and may go home.":
                    _gameSession.HospitableRecovered();
                    _gameSession.RaiseMessage("You recovered from the coronavirus and went home.");
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Yes";
                    break;
                case "You were informed that today the city has been put in quarantine. You were laid off from your job and given your last paycheck.":
                    _gameSession.HospitalQuarantineOk();
                    _gameSession.RaiseMessage("The city is officially in quarantine, and you were laid off.");
                    if (_gameSession.CurrentPlayer.Hospitalized == true)
                    {
                        _gameSession.HasButton2 = false;
                        Button1.Content = "Ok";
                    }
                    break;
                case "You were informed that today the city has been put in quarantine.":
                    _gameSession.HospitalQuarantineOk();
                    _gameSession.RaiseMessage("The city is officially in quarantine.");
                    if (_gameSession.CurrentPlayer.Hospitalized == true)
                    {
                        _gameSession.HasButton2 = false;
                        Button1.Content = "Ok";
                    }
                    break;
                case "On the news this morning, they announced that the country is in a state of crisis. Hospitals are past their carrying capacity and stores are empty from panic buying.":
                    _gameSession.CrisisOk();
                    _gameSession.RaiseMessage("The city has declared a state of crisis.");
                    if (_gameSession.CurrentPlayer.Hospitalized == false)
                    {
                        _gameSession.HasButton2 = true;
                        Button1.Content = "Yes";
                    }
                    break;
                case "You died from starvation.":
                    _gameSession.CurrentFamilyHealth.CharacterAlive = false;
                    _gameSession.CurrentFamilyHealth.CharacterHealth = 0;
                    _gameSession.CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/dead_character.png";
                    _gameSession.DeathOk();
                    _gameSession.RaiseMessage("You died from starvation.");
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Easy";
                    Button2.Content = "Hard";
                    GameMessages.Document.Blocks.Clear();
                    UpdateMessages.Document.Blocks.Clear();
                    break;
                case "You passed away from the coronavirus.":
                    _gameSession.CurrentFamilyHealth.CharacterAlive = false;
                    _gameSession.CurrentFamilyHealth.CharacterHealth = 0;
                    _gameSession.CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/dead_character.png";
                    _gameSession.DeathOk();
                    _gameSession.RaiseMessage("You succumbed to the coronavirus.");
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Easy";
                    Button2.Content = "Hard";
                    GameMessages.Document.Blocks.Clear();
                    UpdateMessages.Document.Blocks.Clear();
                    break;
                case "You survived the pandemic.":
                    _gameSession.DeathOk();
                    _gameSession.RaiseMessage("You survived the pandemic.");
                    _gameSession.HasButton2 = true;
                    Button1.Content = "Easy";
                    Button2.Content = "Hard";
                    GameMessages.Document.Blocks.Clear();
                    UpdateMessages.Document.Blocks.Clear();
                    break;
                //random
                case "Your friend Dave invited you to a party. Will you go?":
                    _gameSession.LC_RIC_Yes();
                    if(QuestionText.Text== "Who will eat dinner today?")
                    {
                        Button2.Content = "Ok";
                    }
                    break;
                case "Your great aunt has invited you to a large family get-together with other distant relatives. Will you attend?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You went to your great aunt's large family get-together.");
                    break;
                case "One of your close friends is visiting the city and wants to come over. Are you going to invite him?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You invited your friend over.");
                    break;
                case "Despite quarantine orders, are you still going to go to church today?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You went to church.");
                    break;
                case "A few co-workers are heading to the bar after work and invite you. Will you have a drink with them?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You and your coworkers went to a bar after work.");
                    break;
                case "One of your daughter’s friends is hosting a birthday party today. Will you allow her to go?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You allowed your daughter to go to her friend's birthday party.");
                    break;
                case "You spot a homeless person sitting on the sidewalk with a sign asking for food. Will you give her some bread?":
                    _gameSession.RK_LB_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You gave some bread to a homeless person. She was incredibly grateful.");
                    break;
                case "A child is sitting on the sidewalk in ragged clothes. Will you give her some bread?":
                    _gameSession.RK_LB_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You gave a loaf of bread to a young girl in ragged clothing.");
                    break;
                case "The adoption centers have a shortage in workers. Would you like to foster a kitten?":
                    _gameSession.RK_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You are now fostering a kitten.");
                    break;
                case "Do you want to sew some masks for your local hospital?":
                    _gameSession.RK_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("The hospital was in need of masks, so you sew some and donated them.");
                    break;
                case "You noticed that the cost of airplane tickets have significantly decreased. Would you like to buy a ticket for travel in the future?":
                    _gameSession.LK_LM_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You bought a cheap plane ticket for the summer.");
                    break;
                case "The Annual Wuhan Lunar New Year banquet is today. Will you and your family attend it?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("To celebrate Chinese New Year, you and your family went to the Annual Wuhan Lunar New Year banquet.");
                    break;
                case "Since today is Easter, your daughter wants to go to the park and celebrate. Will you allow her to go?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You took your daughter to an Easter egg hunt at the park.");
                    break;
                case "Your daughter’s birthday is today. Do you want to invite their friends to throw a birthday party?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You threw a birthday party for your daughter and invited all of her friends.");
                    break;
                case "Today is your birthday. Do you want to go out and have a drink?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You went to the bar for your birthday.");
                    break;
                case "Your parents believe that the coronavirus is “just a hoax” and want to go outside for nonessential activities anyway. Do you want to try and convince them not to?":
                    _gameSession.RK_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("Your mother and father believe that the virus is 'just a hoax.'");
                    break;
                case "Your father yells at you for losing your job, giving you a migraine. Do you want to go to the bar for a drink?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("Your father screamed at you again, so you escaped to the bar to get drunk and forget.");
                    break;
                case "Do you want to file for the $1800 stimulus package?":
                    _gameSession.LC_RIC_Yes();
                    _gameSession.CurrentPlayer.Money += 1800;
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    _gameSession.RaiseMessage("You recieved $1800 from the government.");
                    break;
                case "Your mother told you to buy some tea at the store to “increase resistance” against the coronavirus. Will you go to the store?":
                    _gameSession.StoreYes();
                    _gameSession.HasButton1 = false;
                    _gameSession.HasUpDown = true;
                    Button2.Content = "Ok";
                    _gameSession.RaiseMessage("You went to the store.");
                    break;
                case "Your mother has been feeling unwell and started coughing. Instead of going to the hospital, she told you to buy some essential oils at the store instead. Will you follow her request?":
                    _gameSession.StoreYes();
                    _gameSession.HasButton1 = false;
                    _gameSession.HasUpDown = true;
                    Button2.Content = "Ok";
                    _gameSession.RaiseMessage("You went to the store.");
                    break;
                case "An elderly neighbor requests for you to go out and buy them bread. Will you accept this favor?":
                    _gameSession.StoreYes();
                    _gameSession.CurrentPlayer.Karma += 20;
                    _gameSession.HasButton1 = false;
                    _gameSession.HasUpDown = true;
                    Button2.Content = "Ok";
                    _gameSession.RaiseMessage("You went to the store.");
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
                    _gameSession.RaiseMessage(_gameSession.CurrentDay.Date);
                    _gameSession.RaiseMessage("You live in Los Angeles, California, as a banker. ");
                    break;
                case "Which hard mode city do you want to play in?":
                    _gameSession.CityNewYork();
                    Button1.Content = "Yes";
                    Button2.Content = "No";
                    _gameSession.RaiseMessage(_gameSession.CurrentDay.Date);
                    _gameSession.RaiseMessage("You live in New York City, New York, as a banker. ");
                    break;
                case "Do you want to go to work?":
                    _gameSession.WorkNo();
                    Button1.Content = "Ok";
                    _gameSession.HasButton2 = false;
                    break;
                case "You shook hands with your boss at work, who seems to be sick; do you want to wash your hands? This will take time, and reduce your day’s pay by 10%.":
                    _gameSession.WorkWashNo();
                    _gameSession.RaiseMessage("You did not wash your hands after shaking hands with your sick boss.");
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
                    if ((_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 5 && _gameSession.CurrentPlayer.Stage!="Crisis")|| (_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 10 && _gameSession.CurrentPlayer.Stage == "Crisis"))
                    {
                        _gameSession.BreadOk();
                        for(int i =0; i<Int16.Parse(txtNum.Text)*2; i++) { _gameSession.CurrentPlayer.BreadAge.Add(1); }
                        _gameSession.RaiseMessage("You bought "+Int16.Parse(txtNum.Text)+" bread.");
                        _gameSession.CurrentPlayer.Bread += Int16.Parse(txtNum.Text);
                        if (_gameSession.CurrentPlayer.Stage == "Crisis")
                        {
                            _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 10;
                        }
                        else
                        {
                            _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 5;
                        }
                        txtNum.Text = "0";
                    }
                    else
                    {
                        _gameSession.BreadMoney();
                    }
                    break;
                case "How much bread do you want to buy? \n You don't have enough money. Select a lower quantity.":
                    if ((_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 5 && _gameSession.CurrentPlayer.Stage != "Crisis") || (_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 10 && _gameSession.CurrentPlayer.Stage == "Crisis"))
                    {
                        _gameSession.BreadOk();
                        for (int i = 0; i < Int16.Parse(txtNum.Text); i++) { _gameSession.CurrentPlayer.BreadAge.Add(1); }
                        _gameSession.RaiseMessage("You bought " + Int16.Parse(txtNum.Text) +" bread.");
                        _gameSession.CurrentPlayer.Bread += Int16.Parse(txtNum.Text);
                        if (_gameSession.CurrentPlayer.Stage == "Crisis")
                        {
                            _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 10;
                        }
                        else
                        {
                            _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 5;
                        }
                        txtNum.Text = "0";
                    }
                    else
                    {
                        _gameSession.BreadMoney();
                    }
                    break;
                case "How much toilet paper do you want to buy?":
                    if ((_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 6 && _gameSession.CurrentPlayer.Stage != "Crisis") || (_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 12 && _gameSession.CurrentPlayer.Stage == "Crisis"))
                    {
                        _gameSession.CurrentPlayer.ToiletPaper += Int16.Parse(txtNum.Text);
                        _gameSession.RaiseMessage("You bought " + Int16.Parse(txtNum.Text) + " toilet paper rolls.");
                        if (_gameSession.CurrentPlayer.Stage == "Crisis")
                        {
                            _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 12;
                        }
                        else
                        {
                            _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 6;
                        }
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
                    if ((_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 6 && _gameSession.CurrentPlayer.Stage != "Crisis") || (_gameSession.CurrentPlayer.Money >= Int16.Parse(txtNum.Text) * 12 && _gameSession.CurrentPlayer.Stage == "Crisis"))
                    {
                        _gameSession.TPOk();
                        _gameSession.CurrentPlayer.ToiletPaper += Int16.Parse(txtNum.Text);
                        _gameSession.RaiseMessage("You bought " + Int16.Parse(txtNum.Text) + " toilet paper rolls.");
                        if (_gameSession.CurrentPlayer.Stage == "Crisis")
                        {
                            _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 12;
                        }
                        else
                        {
                            _gameSession.CurrentPlayer.Money -= Int16.Parse(txtNum.Text) * 6;
                        }
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
                case "Do you want to wash your hands before you eat dinner? It will cost 10% of a toilet paper roll.":
                    _gameSession.HomeWashNo();
                    Button1.Content = "Check all";
                    Button2.Content = "Ok";
                    _gameSession.HasCheckMe = true;
                    if (_gameSession.CurrentFamilyHealth.SpouseAlive == true) { _gameSession.HasCheckSpouse = true; }
                    if (_gameSession.CurrentFamilyHealth.MomAlive == true) { _gameSession.HasCheckMother = true; }
                    if (_gameSession.CurrentFamilyHealth.DadAlive == true) { _gameSession.HasCheckFather = true; }
                    if (_gameSession.CurrentFamilyHealth.DaughterAlive == true) { _gameSession.HasCheckDaughter = true; }
                    if (_gameSession.CurrentFamilyHealth.SonAlive == true) _gameSession.HasCheckSon = true;
                    break;
                case "Who will eat dinner today?":
                    int membersEaten = 0;
                    bool starved = false;
                    if (Character.IsChecked==true) { membersEaten++; } else { _gameSession.CurrentFamilyHealth.CharacterHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.CharacterHealth <= 0) { _gameSession.CurrentFamilyHealth.CharacterHealth = 0; starved = true; }
                    }
                    if (Spouse.IsChecked == true) { membersEaten++; } else {_gameSession.CurrentFamilyHealth.SpouseHealth -= 20; 
                        if (_gameSession.CurrentFamilyHealth.SpouseHealth <= 0) { _gameSession.CurrentFamilyHealth.SpouseHealth = 0; }
                    }
                    if (Mother.IsChecked == true) { membersEaten++; } else { _gameSession.CurrentFamilyHealth.MomHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.MomHealth <= 0) { _gameSession.CurrentFamilyHealth.MomHealth = 0;}
                    }
                    if (Father.IsChecked == true) { membersEaten++; } else { _gameSession.CurrentFamilyHealth.DadHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.DadHealth <= 0) { _gameSession.CurrentFamilyHealth.DadHealth = 0;}
                    }
                    if (Daughter.IsChecked == true) { membersEaten++; } else { _gameSession.CurrentFamilyHealth.DaughterHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.DaughterHealth <= 0) { _gameSession.CurrentFamilyHealth.DaughterHealth = 0;}
                    }
                    if (Son.IsChecked == true) { membersEaten++; }else { _gameSession.CurrentFamilyHealth.SonHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.SonHealth <= 0) { _gameSession.CurrentFamilyHealth.SonHealth = 0;}
                    }
                    if (starved)
                    {
                        _gameSession.StarvedOk();
                        _gameSession.HasButton2 = false;
                        Button1.Content = "Ok";
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
                        if (membersEaten <= _gameSession.CurrentPlayer.Bread * 2)
                        {
                            _gameSession.CurrentPlayer.Bread -= membersEaten * .5;
                            for (int i = 0; i < membersEaten; i++) { _gameSession.CurrentPlayer.BreadAge.RemoveAt(0); }
                            _gameSession.DinnerOk();
                            if (QuestionText.Text == "You should begin practicing social distancing due to concerns over the virus."
                                || QuestionText.Text == "This morning you recieved an email-- due to concerns over the coronavirus, you may no longer go to work. You were laid off and have recieved your last paycheck."
                                || QuestionText.Text == "You passed away from the coronavirus."
                                || QuestionText.Text == "On the news this morning, they announced that the country is in a state of crisis. Hospitals are past their carrying capacity and stores are empty from panic buying."
                                ||QuestionText.Text=="You survived the pandemic.")//quarantine message
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
                    }
                    
                    break;

                case "Who will eat dinner today? \n You do not have enough bread. Select less family members.":
                    int membersEaten2 = 0;
                    bool starved2 = false;
                    if (Character.IsChecked == true) { membersEaten2++; }
                    else
                    {
                        _gameSession.CurrentFamilyHealth.CharacterHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.CharacterHealth <= 0) { _gameSession.CurrentFamilyHealth.CharacterHealth = 0; starved2 = true; }
                    }
                    if (Spouse.IsChecked == true) { membersEaten2++; }
                    else
                    {
                        _gameSession.CurrentFamilyHealth.SpouseHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.SpouseHealth <= 0) { _gameSession.CurrentFamilyHealth.SpouseHealth = 0; }
                    }
                    if (Mother.IsChecked == true) { membersEaten2++; }
                    else
                    {
                        _gameSession.CurrentFamilyHealth.MomHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.MomHealth <= 0) { _gameSession.CurrentFamilyHealth.MomHealth = 0; }
                    }
                    if (Father.IsChecked == true) { membersEaten2++; }
                    else
                    {
                        _gameSession.CurrentFamilyHealth.DadHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.DadHealth <= 0) { _gameSession.CurrentFamilyHealth.DadHealth = 0; }
                    }
                    if (Daughter.IsChecked == true) { membersEaten2++; }
                    else
                    {
                        _gameSession.CurrentFamilyHealth.DaughterHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.DaughterHealth <= 0) { _gameSession.CurrentFamilyHealth.DaughterHealth = 0; }
                    }
                    if (Son.IsChecked == true) { membersEaten2++; }
                    else
                    {
                        _gameSession.CurrentFamilyHealth.SonHealth -= 20;
                        if (_gameSession.CurrentFamilyHealth.SonHealth <= 0) { _gameSession.CurrentFamilyHealth.SonHealth = 0; }
                    }
                    if (starved2)
                    {
                        _gameSession.CurrentFamilyHealth.CharacterImage = "/Engine;component/Images/Family/dead_character.png";
                        _gameSession.StarvedOk();
                        _gameSession.HasButton2 = false;
                        Button1.Content = "Ok";
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
                    if (membersEaten2 <= _gameSession.CurrentPlayer.Bread * 2)
                    {
                        _gameSession.CurrentPlayer.Bread -= membersEaten2 * .5;
                        for (int i = 0; i < membersEaten2; i++) { _gameSession.CurrentPlayer.BreadAge.RemoveAt(0); }
                        _gameSession.DinnerOk();
                        if (QuestionText.Text == "You should begin practicing social distancing due to concerns over the virus."
                            || QuestionText.Text == "This morning you recieved an email-- due to concerns over the coronavirus, you may no longer go to work. You were laid off and have recieved your last paycheck."
                            || QuestionText.Text == "You passed away from the coronavirus."
                            || QuestionText.Text == "On the news this morning, they announced that the country is in a state of crisis. Hospitals are past their carrying capacity and stores are empty from panic buying."
                            || QuestionText.Text == "You survived the pandemic.")  
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
                        
                    }
                    else
                    {
                        _gameSession.DinnerBread();
                    }
                    break;
                case "Do you want to go to the store? You should only go if necessary and maintain social distancing.":
                    _gameSession.StoreNo();
                    if (QuestionText.Text == "Who will eat dinner today?")
                    {
                        Button1.Content = "Check all";
                        Button2.Content = "Ok";
                    }
                    break;
                case "You are not feeling well, and coming down with a fever. Do you want to get tested for the coronavirus?":
                    _gameSession.TestNo();
                    _gameSession.RaiseMessage("Despite symptoms, you did not try to get a coronavirus test.");
                    break;
                case "Along with your fever, you are starting to experience dry cough and shortness of breath. Do you want to get tested for the coronavirus?":
                    _gameSession.TestNo();
                    _gameSession.RaiseMessage("Despite symptoms, you did not try to get a coronavirus test.");
                    break;
                case "You seem to be losing your sense of smell and taste. You had diarrhea this morning too. Do you want to get tested for the coronavirus?":
                    _gameSession.TestNo();
                    _gameSession.RaiseMessage("Despite symptoms, you did not try to get a coronavirus test.");
                    break;
                case "You feel extremely unwell. Do you want to go to the emergency room?":
                    _gameSession.EmergencyNo();
                    _gameSession.RaiseMessage("You did not go to the emergency room despite your condition.");
                    break;
                case "You tested positive for the coronavirus. Do you want to be admitted to the hospital?":
                    _gameSession.RaiseMessage("Despite testing positive for the coronavirus, you chose not to go to the hospital.");
                    _gameSession.HospitalizedNo();
                    break;
                case "Do you want to be admitted to the hospital?":
                    _gameSession.RaiseMessage("Despite testing positive for the coronavirus, you chose not to go to the hospital.");
                    _gameSession.HospitalizedNo();
                    break;
                case "Your friend Dave invited you to a party. Will you go?":
                    _gameSession.LC_RIC_Yes();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Your great aunt has invited you to a large family get-together with other distant relatives. Will you attend?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "One of your close friends is visiting the city and wants to come over. Are you going to invite him?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Despite quarantine orders, are you still going to go to church today?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "A few co-workers are heading to the bar after work and invite you. Will you have a drink with them?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "One of your daughter’s friends is hosting a birthday party today. Will you allow her to go?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "You spot a homeless person sitting on the sidewalk with a sign asking for food. Will you give her some bread?":
                    _gameSession.RK_LB_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "A child is sitting on the sidewalk in ragged clothes. Will you give her some bread?":
                    _gameSession.RK_LB_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "The adoption centers have a shortage in workers. Would you like to foster a kitten?":
                    _gameSession.RK_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Do you want to sew some masks for your local hospital?":
                    _gameSession.RK_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "You noticed that the cost of airplane tickets have significantly decreased. Would you like to buy a ticket for travel in the future?":
                    _gameSession.LK_LM_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "The Annual Wuhan Lunar New Year banquet is today. Will you and your family attend it?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Since today is Easter, your daughter wants to go to the park and celebrate. Will you allow her to go?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Your daughter’s birthday is today. Do you want to invite their friends to throw a birthday party?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Today is your birthday. Do you want to go out and have a drink?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Your parents believe that the coronavirus is “just a hoax” and want to go outside for nonessential activities anyway. Do you want to try and convince them not to?":
                    _gameSession.RK_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Your father yells at you for losing your job, giving you a migraine. Do you want to go to the bar for a drink?":
                    _gameSession.LC_RIC_No();
                    if (QuestionText.Text == "Who will eat dinner today?") { Button2.Content = "Ok"; }
                    break;
                case "Your mother told you to buy some tea at the store to “increase resistance” against the coronavirus. Will you go to the store?":
                    _gameSession.StoreNo();
                    if (QuestionText.Text == "Who will eat dinner today?")
                    {
                        Button1.Content = "Check all";
                        Button2.Content = "Ok";
                    }
                    break;
                case "Your mother has been feeling unwell and started coughing. Instead of going to the hospital, she told you to buy some essential oils at the store instead. Will you follow her request?":
                    _gameSession.StoreNo();
                    if (QuestionText.Text == "Who will eat dinner today?")
                    {
                        Button1.Content = "Check all";
                        Button2.Content = "Ok";
                    }
                    break;
                case "An elderly neighbor requests for you to go out and buy them bread. Will you accept this favor?":
                    _gameSession.StoreNo();
                    _gameSession.CurrentPlayer.Karma -= 10;
                    if (_gameSession.CurrentPlayer.Karma < 0) { _gameSession.CurrentPlayer.Karma = 0; }
                    if (QuestionText.Text == "Who will eat dinner today?")
                    {
                        Button1.Content = "Check all";
                        Button2.Content = "Ok";
                    }
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

        private void OnUpdateMessageRaised(object sender, UpdateMessageEventArgs e)
        {
            UpdateMessages.Document.Blocks.Add(new Paragraph(new Run(e.Update)));
            UpdateMessages.ScrollToEnd();
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
            if (_gameSession.CurrentPlayer.Stage == "Crisis")
            {
                if (NumValue < 2)
                {
                    NumValue++;
                }
            }
            if(_gameSession.CurrentPlayer.Stage == "Quarantine")
            {
                if (NumValue < 5)
                {
                    NumValue++;
                }
            }
            if(_gameSession.CurrentPlayer.Stage == "Regular")
            {
                if (NumValue < 20)
                {
                    NumValue++;
                }
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