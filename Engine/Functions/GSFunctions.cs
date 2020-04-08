using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Functions
{
    public class GSFunctions
    {
        public int randomNumber(int index, int percentage, int totalPossible)
        {
            Random rnd = new Random();
            int randomRoll = rnd.Next(1, 11);
            if (totalPossible == 2)
            {
                if (randomRoll <= percentage)
                {
                    return index + 1;
                }
                return index + 2;
            }
            return -1;
        }

        public string nextDay(string currentDay)
        {
            string[] date = currentDay.Split('/');
            //january and march (31 days)
            if (date[0] == "1" || date[0] == "3")
            {
                if (Int32.Parse(date[1]) < 31) { date[1] = (Int32.Parse(date[1]) + 1).ToString(); }
                else
                {
                    date[0] = (Int32.Parse(date[0]) + 1).ToString();
                    date[1] = "0";
                }
            }
            //february (29 days)
            if (date[0] == "2")
            {
                if (Int32.Parse(date[1]) < 29) { date[1] = (Int32.Parse(date[1]) + 1).ToString(); }
                else
                {
                    date[0] = (Int32.Parse(date[0]) + 1).ToString();
                    date[1] = "0";
                }
            }
            //april (30 days)
            if (date[0] == "4")
            {
                if (Int32.Parse(date[1]) < 30) { date[1] = (Int32.Parse(date[1]) + 1).ToString(); }
                else
                {
                    date[0] = (Int32.Parse(date[0]) + 1).ToString();
                    date[1] = "0";
                }
            }
            return string.Join("/", date);
        }

        public int infection(double chance, int severity, bool washedHands) //returns how serious the infection is
        {
            int newSeverity = severity;
            if (severity == 0) //establishes if player is severity 1
            {
                Random rnd = new Random();
                int randomRoll = rnd.Next(1, 101);
                if (randomRoll <= chance * 100) 
                {
                    newSeverity = 1;
                }
            }

            if (severity == 1 && washedHands == true)
            {
                newSeverity = 0;
            }

            return newSeverity;
        }

        public int infectionDay(int severity, bool atHospital, string health)
        {
            int newSeverity = severity;
            Random rnd = new Random();
            int randomRoll = rnd.Next(1, 13);
            if (health == "Obese")
            {
                if (randomRoll <= 6) { newSeverity += 4; }
                if (randomRoll <= 10 && randomRoll > 6) { newSeverity--; }
            }
            if (health == "Healthy")
            {
                if (randomRoll <= 8) { newSeverity += 2; } //<=6
                if (randomRoll <= 10 && randomRoll > 8) { newSeverity--; }
            }
            if (atHospital) { newSeverity--; }
            return newSeverity;
        }

        public bool testChance(string stage)
        {
            Random rnd = new Random();
            int randomRoll = rnd.Next(1, 11);
            bool test = false;
            if (stage == "Regular") //10%
            {
                if (randomRoll <=10) { test = true; }
            }
            if (stage == "Quarantine") //30%
            {
                if (randomRoll <= 3) { test = true; }
            }
            if (stage == "Crisis")//90%
            {
                if (randomRoll <= 9) { test = true; }
            }
            return test;
        }

        public bool hospitalizationChance(string stage)
        {
            Random rnd = new Random();
            int randomRoll = rnd.Next(1, 11);
            bool ventilator = false;
            if (stage == "Regular") //100%
            {
                if (randomRoll <= 10) { ventilator = true; }
            }
            if (stage == "Quarantine") //80%
            {
                if (randomRoll <= 8) { ventilator = true; }
            }
            if (stage == "Crisis")//30%
            {
                if (randomRoll <= 3) { ventilator = true; }
            }
            return ventilator;
        }
    }
}
