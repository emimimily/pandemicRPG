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
                "Your boss did not consider your excuse to be valid, so you were fired from your job.");

            newQuestion.AddStatus("Store", "Any", "Any", "Any", "Any", "Any", 1,
                "How much bread do you want to buy?"); 

            newQuestion.AddStatus("Store", "Any", "Any", "Any", "Any", "Any", 3,
                "How much bread do you want to buy? \n You don't have enough money. Select a lower quantity.");

            newQuestion.AddStatus("Store", "Any", "Any", "Any", "Any", "Any", 2,
                "How much toilet paper do you want to buy?"); 

            newQuestion.AddStatus("Store", "Any", "Any", "Any", "Any", "Any", 4,
                "How much toilet paper do you want to buy? \n You don't have enough money. Select a lower quantity");

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 2,
                "When you came home, your friend Dave invited you to a party. Will you go?");
                
            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 3,
                "Do you want to wash your hands before you eat dinner? It will cost 10% of a toilet paper roll."); 

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 4,
                "Who will eat dinner today?"); 

            newQuestion.AddStatus("Home", "Any", "Any", "Any", "Any", "Any", 5,
                "Who will eat dinner today? \n You do not have enough bread. Select less family members.");

            //STAGE 2/QUARANTINE
            newQuestion.AddStatus("Home", "Any", "Quarantine", "Any", "Any", "Yes", 1,
                "This morning you recieved an email-- due to concerns over the coronavirus, you may no longer go to work. You were laid off.");
            newQuestion.AddStatus("Home", "Any", "Quarantine", "Any", "Any", "Any", 2,
                "Do you want to go to the store? You should maintain social distancing.");

            return newQuestion;
           
        }
    }
}
