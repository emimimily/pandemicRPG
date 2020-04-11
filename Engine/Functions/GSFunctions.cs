using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
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
                if (randomRoll <= 8) { newSeverity += 1; } //<=6
                if (randomRoll <= 10 && randomRoll > 8) { newSeverity--; }
            }
            if (atHospital) { newSeverity-=2; }
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

        public List<int> updateHealths(List<int> currentHealths, List<bool> currentInfections, bool obese)
        { //0. player, 1. spouse, 2. mom, 3. dad, 4. daughter, 5. son
            List<int> newHealths = currentHealths;
            for(int i=1; i<currentHealths.Count; i++)
            {
                if (currentHealths[i] == 0) { continue; }
                if (currentInfections[i] == true)
                {
                    Random rnd = new Random();
                    int randomRoll = rnd.Next(1, 11);
                    if ((i == 0 && obese==true) || i == 2 || i == 3 || i == 5) //unhealthy people: obese char, mom, dad, baby son
                    {
                        if (randomRoll >= 5) //if the random roll is 5 or more (50%)
                        {
                            newHealths[i] -= randomRoll * 2;
                            if(newHealths[i]<0) { newHealths[i] = 0; }
                        }
                    }

                    if((i==0 && obese==false) || i==1 || i == 4) //healthy: healthy char, spouse, daughter
                    {
                        if (randomRoll >= 9)
                        {
                            newHealths[i] -= randomRoll;
                            if (newHealths[i] < 0) { newHealths[i] = 0; }
                        }
                    }
                }
            }
            return newHealths;
        }

        public List<bool> updateInfections(List<bool> currentInfections) //determines if they're infected
        {
            Random rnd = new Random();
            List<bool> newInfections = currentInfections;
            for (int i = 1; i < currentInfections.Count; i++) //excludes the character
            {
                int randomRoll = rnd.Next(1, 11);
                if (randomRoll >= 5) //50% chance to get infected
                {
                    newInfections[i] = true;
                }
                else
                {
                    newInfections[i] = false;
                }
            }
            return newInfections;
        }
        public List<bool> updateInfections2(List<bool> currentInfections) //if they're already infected, update if they recover
        {
            Random rnd = new Random();
            List<bool> newInfections = currentInfections;
            for (int i = 1; i < currentInfections.Count; i++) //excludes the character
            {
                if (currentInfections[i] == true)
                {
                    int randomRoll = rnd.Next(1, 11);
                    if (randomRoll >= 8) //30% chance to not be infected anymore
                    {
                        newInfections[i] = false;
                    }
                    else
                    {
                        newInfections[i] = true;
                    }
                }
            }
            return newInfections;
        }
        public List<bool> updateAlive(List<int> currentHealths, List<bool> currentAlive)
        {
            List<bool> newAlive = currentAlive;
            for(int i=1; i<currentAlive.Count; i++)
            {
                if (currentHealths[i] <= 0)
                {
                    newAlive[i] = false;
                }
                else
                {
                    newAlive[i] = true;
                }
            }
            return newAlive;
        }
        public List<string> updateImages(List<string> currentImages, List<bool> currentAlive, List<bool> currentInfections)
        {
            List<string> newImages = currentImages;
            for (int i = 0; i < currentImages.Count; i++)
            {
                if (currentAlive[i] == false) //if they died
                {
                    switch (i)
                    {
                        case 0:
                            newImages[i] = "/Engine;component/Images/Family/dead_character.png";
                            break;
                        case 1:
                            newImages[i]= "/Engine;component/Images/Family/dead_spouse.png";
                            break;
                        case 2:
                            newImages[i] = "/Engine;component/Images/Family/dead_mom.png";
                            break;
                        case 3:
                            newImages[i] = "/Engine;component/Images/Family/dead_dad.png";
                            break;
                        case 4:
                            newImages[i] = "/Engine;component/Images/Family/dead_daughter.png";
                            break;
                        case 5:
                            newImages[i] = "/Engine;component/Images/Family/dead_son.png";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            newImages[i] = "/Engine;component/Images/Family/player.png";
                            break;
                        case 1:
                            newImages[i] = "/Engine;component/Images/Family/spouse.png";
                            break;
                        case 2:
                            newImages[i] = "/Engine;component/Images/Family/mom.png";
                            break;
                        case 3:
                            newImages[i] = "/Engine;component/Images/Family/dad.png";
                            break;
                        case 4:
                            newImages[i] = "/Engine;component/Images/Family/daughter.png";
                            break;
                        case 5:
                            newImages[i] = "/Engine;component/Images/Family/son.png";
                            break;
                        default:
                            break;
                    }
                }
                if (currentInfections[i] == true && currentAlive[i]==true)
                {
                    switch (i)
                    {
                        case 0:
                            newImages[i] = "/Engine;component/Images/Family/infect_player.png";
                            break;
                        case 1:
                            newImages[i] = "/Engine;component/Images/Family/infect_spouse.png";
                            break;
                        case 2:
                            newImages[i] = "/Engine;component/Images/Family/infect_mom.png";
                            break;
                        case 3:
                            newImages[i] = "/Engine;component/Images/Family/infect_dad.png";
                            break;
                        case 4:
                            newImages[i] = "/Engine;component/Images/Family/infect_daughter.png";
                            break;
                        case 5:
                            newImages[i] = "/Engine;component/Images/Family/infect_son.png";
                            break;
                        default:
                            break;
                    }
                }
            }
            return newImages;
        }

        public string updateBodyDiagram(int infectionSeverity)
        {
            switch (infectionSeverity)
            {
                case 0:
                    return "/Engine;component/Images/Body/body0.gif";
                case 1:
                    return "/Engine;component/Images/Body/body1.gif";
                case 2:
                    return "/Engine;component/Images/Body/body2.gif";
                case 3:
                    return "/Engine;component/Images/Body/body3.gif";
                case 4:
                    return "/Engine;component/Images/Body/body4.gif";
                case 5:
                    return "/Engine;component/Images/Body/body5.gif";
                case 6:
                    return "/Engine;component/Images/Body/body6.gif";
                case 7:
                    return "/Engine;component/Images/Body/body7.gif";
                case 8:
                    return "/Engine;component/Images/Body/body8.gif";
                case 9:
                    return "/Engine;component/Images/Body/body9.gif";
                case 10:
                    return "/Engine;component/Images/Body/body10.gif";
                case 11:
                    return "/Engine;component/Images/Body/body11.gif";
                case 12:
                    return "/Engine;component/Images/Body/body12.gif";
                case 13:
                    return "/Engine;component/Images/Body/body13.gif";
                case 14:
                    return "/Engine;component/Images/Body/body14.gif";
                case 15:
                    return "/Engine;component/Images/Body/body15.gif";
                case 16:
                    return "/Engine;component/Images/Body/body16.gif";
                case 17:
                    return "/Engine;component/Images/Body/body17.gif";
                case 18:
                    return "/Engine;component/Images/Body/body18.gif";
                case 19:
                    return "/Engine;component/Images/Body/body19.gif";
                case 20:
                    return "/Engine;component/Images/Body/body20.gif";

                default:
                    return "/Engine;component/Images/Body/body7.gif";
            }
        }
        public int infectPeople(int currentPYI, int infectionSeverity)
        {
            int newPYI = currentPYI;
            Random rnd = new Random();
            if (infectionSeverity > 0)
            {
                return newPYI+ rnd.Next(0, 4);
            }
            return newPYI;
        }

        public List<int> updateBreadAge(List<int> currentBreadAge)
        {
            List<int> newBreadAge = currentBreadAge;
            for(int i=0; i < newBreadAge.Count; i++)
            {
                newBreadAge[i]++;
                if (newBreadAge[i] == 5)
                {
                    newBreadAge.Remove(i);
                    newBreadAge.Remove(i + 1);
                }
            }
            return newBreadAge;
        }

    }
}
