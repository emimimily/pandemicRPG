using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal class QuestionFactory
    {
        internal Question CreateQuestion()
        {
            Question newQuestion = new Question();
            //Location, City, Stage, InfectionChance, InfectionSeverity, Job, Index, Message
            //STAGE 1/REGULAR
            newQuestion.AddStatus("Home", "None", "Regular", "Any", "Any", "Yes", 1,
                "What difficulty do you want to play on?");

            newQuestion.AddStatus("Home", "None", "Regular", "Any", "Any", "Yes", 2,
                 "Which easy mode city do you want to play in?");

            newQuestion.AddStatus("Home", "None", "Regular", "Any", "Any", "Yes", 3,
                 "Which hard mode city do you want to play in?");

            newQuestion.AddStatus("Home", "Any", "Regular", "Any", "Any", "Yes", 1,
                "Do you want to go to work?");

            newQuestion.AddStatus("Work", "Any", "Regular", "Any", "Any", "Any", 1,
                "You shook hands with your boss at work, who seems to be sick; do you want to wash your hands? This will take time, and reduce your day’s pay by 10%.");

            newQuestion.AddStatus("Work", "Any", "Regular", "Any", "Any", "Any", 2, //any for work technically
                "Do you want to go to the store?");

            newQuestion.AddStatus("Home", "Any", "Regular", "Any", "Any", "No", 1,
                "Your boss did not consider your excuse to be valid, so you were fired from your job and given your last paycheck."); //changed

            newQuestion.AddStatus("Store", "Any", "Any", "Any", "Any", "Any", 1,
                "How much bread do you want to buy?"); 

            newQuestion.AddStatus("Store", "Any", "Any", "Any", "Any", "Any", 3,
                "How much bread do you want to buy? \n You don't have enough money. Select a lower quantity.");

            newQuestion.AddStatus("Store", "Any", "Any", "Any", "Any", "Any", 2,
                "How much toilet paper do you want to buy?"); 

            newQuestion.AddStatus("Store", "Any", "Any", "Any", "Any", "Any", 4,
                "How much toilet paper do you want to buy? \n You don't have enough money. Select a lower quantity");
                
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 3,
                "Do you want to wash your hands before you eat dinner? It will cost 10% of a toilet paper roll."); 

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 4,
                "Who will eat dinner today?"); 

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 5,
                "Who will eat dinner today? \n You do not have enough bread. Select less family members.");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 6,
                "You died from starvation.");

            //STAGE 2/QUARANTINE
            newQuestion.AddStatus("Home", "Any", "Quarantine", "Any", "Any", "Yes", 1,
                "This morning you recieved an email-- due to concerns over the coronavirus, you may no longer go to work. You were laid off and have recieved your last paycheck."); //changed 
            newQuestion.AddStatus("Home", "Any", "Quarantine", "Any", "Any", "Yes", 2,
                "You should begin practicing social distancing due to concerns over the virus.");
            newQuestion.AddStatus("Home", "Any", "Quarantine", "Any", "Any", "Any", 3,
                "Do you want to go to the store? You should only go if necessary and maintain social distancing.");

            //STAGE 3/CRISIS
            newQuestion.AddStatus("Home", "Any", "Crisis", "Any", "Any", "Yes", 1,
                "On the news this morning, they announced that the country is in a state of crisis. Hospitals are past their carrying capacity and stores are empty from panic buying.");
            newQuestion.AddStatus("Home", "Any", "Crisis", "Any", "Any", "Yes", 2,
                "You survived the pandemic."); 

            //INFECTION SEVERITY
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "16", "Any", 1,
                "You are not feeling well, and coming down with a fever. Do you want to get tested for the coronavirus?");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "17", "Any", 2,
                "Along with your fever, you are starting to experience dry cough and shortness of breath. Do you want to get tested for the coronavirus?");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "18", "Any", 3,
                "You seem to be losing your sense of smell and taste. You had diarrhea this morning too. Do you want to get tested for the coronavirus?");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "19", "Any", 4,
                "You feel extremely unwell. Do you want to go to the emergency room?");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "20", "Any", 5,
                "You passed away from the coronavirus.");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "16+", "Any", 6,
                "You were tested for COVID-19 and will recieve results in two days. You were instructed to go back home and self-quarantine.");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "16+", "Any", 7,
                "The hospital did not have enough tests to test you for the virus. You were instructed to go back home and self-quarantine.");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "16+", "Any", 8,
                "You tested positive for the coronavirus. Do you want to be admitted to the hospital?");

            newQuestion.AddStatus("Home", "Any", "Crisis", "Any", "16+", "Any", 1,
                "The hospital does not have enough ventilators to accomodate you.");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "16+", "Any", 9,
                "You were admitted to the hospital.");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "16+", "Any", 9,
                "Do you want to be admitted to the hospital?");

            newQuestion.AddStatus("Home", "Any", "Regular", "Any", "16+", "Yes", 1,
                "Your boss excused your absence and wished you a fast recovery.");

            //HOSPITAL
            newQuestion.AddStatus("Hospital", "Any", "Any", "Any", "16+", "Any", 1,
                "You miserably spent your day in the hospital.");
            newQuestion.AddStatus("Hospital", "Any", "Any", "Any", "Any", "Any", 2,
                "You spent your day in the hospital. You feel slightly better, but lonely.");
            newQuestion.AddStatus("Hospital", "Any", "Any", "Any", "Any", "Any", 3,
                "You have officially recovered from the coronavirus and may go home.");

            newQuestion.AddStatus("Hospital", "Any", "Any", "Any", "Any", "Yes", 1,
                "You were informed that today the city has been put in quarantine. You were laid off from your job and given your last paycheck."); //changed

            newQuestion.AddStatus("Hospital", "Any", "Any", "Any", "Any", "No", 1,
                "You were informed that today the city has been put in quarantine.");

            //Location, City, Stage, InfectionChance, InfectionSeverity, Job, Index, Message
            //RANDOM: ANY
            //lower karma, raise infection chance
            //requirement: none
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 10,
                "Your friend Dave invited you to a party. Will you go?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 11,
                "Your great aunt has invited you to a large family get-together with other distant relatives. Will you attend?"); 
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 12,
                "One of your close friends is visiting the city and wants to come over. Are you going to invite him?"); 
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 13,
                "Despite quarantine orders, are you still going to go to church today?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 14,
                "A few co-workers are heading to the bar after work and invite you. Will you have a drink with them?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 15,
                "One of your daughter’s friends is hosting a birthday party today. Will you allow her to go?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 27,
                "Your father yells at you for losing your job, giving you a migraine. Do you want to go to the bar for a drink?");
            //raise karma
            //requirement: none
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 16,
                "The adoption centers have a shortage in workers. Would you like to foster a kitten?"); 
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 17,
                "Do you want to sew some masks for your local hospital?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 26,
                "Your parents believe that the coronavirus is “just a hoax” and want to go outside for nonessential activities anyway. Do you want to try and convince them not to?");
            //raise karma, lower bread
            //requirement: 1 bread
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 19,
                "You spot a homeless person sitting on the sidewalk with a sign asking for food. Will you give her some bread?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 20,
                "A child is sitting on the sidewalk in ragged clothes. Will you give her some bread?");
            //lower karma
            //requirement: $50
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 21,
                "You noticed that the cost of airplane tickets have significantly decreased. Would you like to buy a ticket for travel in the future?");
            //specific dates
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 22, //1/18/20 && Wuhan
                "The Annual Wuhan Lunar New Year banquet is today. Will you and your family attend it?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 23, //4/12/20 && !Wuhan && daughter alive
                "Since today is Easter, your daughter wants to go to the park and celebrate. Will you allow her to go?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 24, //3/27/20 && daughter alive
                "Your daughter’s birthday is today. Do you want to invite their friends to throw a birthday party?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 25, //NYC = 2/23, Wuhan = 1/24, London = 3/17, LA = 3/20
                "Today is your birthday. Do you want to go out and have a drink?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 28, //4/11/20 USA
                "Do you want to file for the $1800 stimulus package?");
            //goign to the store
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 29, //4/11/20 USA
                "Your mother told you to buy some tea at the store to “increase resistance” against the coronavirus. Will you go to the store?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 30, //4/11/20 USA
                "Your mother has been feeling unwell and started coughing. Instead of going to the hospital, she told you to buy some essential oils at the store instead. Will you follow her request?");
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 31,
                "An elderly neighbor requests for you to go out and buy them bread. Will you accept this favor?"); //raise+go to the store?
            


            return newQuestion;


        }
    }
}
