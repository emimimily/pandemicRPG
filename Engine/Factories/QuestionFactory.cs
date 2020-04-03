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

            newQuestion.AddStatus("Home", 
                "All", 
                "Regular", 
                "Any", 
                "Any", 
                "Yes", 
                1,
                "Do you want to go to work?");
            newQuestion.AddStatus("Work",
                "All",
                "Regular",
                "Any",
                "Any",
                "Yes",
                1,
                "You shook hands with your boss at work, who seems to be sick; do you want to wash your hands? This will take time, and reduce your day’s pay by 10%.");

            return newQuestion;

        }
    }
}
