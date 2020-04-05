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
            newQuestion.AddStatus("Home", "Any", "Regular", "Any", "Any", "Yes", 1,
                "Do you want to go to work?");

            newQuestion.AddStatus("Work", "Any", "Regular", "Any", "Any", "Yes", 1,
                "You shook hands with your boss at work, who seems to be sick; do you want to wash your hands? This will take time, and reduce your day’s pay by 10%.");

            newQuestion.AddStatus("Work", "Any", "Regular", "Any", "Any", "Any", 2,
                "Do you want to go to the store?");

            newQuestion.AddStatus("Home", "Any", "Regular", "Any", "Any", "No", 1,
                "Your boss did not consider your excuse to be valid, so you were fired from your job.");

            newQuestion.AddStatus("Store", "Any", "Regular", "Any", "Any", "Any", 1,
                "How much bread do you want to buy?");
                 
            return newQuestion;
           
        }
    }
}
