using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Question
    {
        private List<QuestionStatus> _questionStatus = new List<QuestionStatus>();

        internal void AddStatus(string Location, string City, string Stage, string InfectionChance, string InfectionSeverity, string Job, int Index, string Message)
        {
            QuestionStatus stat = new QuestionStatus();
            stat.Location = Location;
            stat.City = City;
            stat.Stage = Stage;
            stat.InfectionChance = InfectionChance;
            stat.InfectionSeverity = InfectionSeverity;
            stat.Job = Job;
            stat.Index = Index;
            stat.Message = Message;

            _questionStatus.Add(stat);
        }

        public QuestionStatus StatusAt(string Location, string City, string Stage, string InfectionChance, string InfectionSeverity, string Job, int Index)
        {
            foreach (QuestionStatus stat in _questionStatus)
            {
                if (stat.Location == Location && 
                    stat.City == City &&
                    stat.Stage == Stage &&
                    stat.InfectionChance == InfectionChance &&
                    stat.InfectionSeverity == InfectionSeverity &&
                    stat.Job== Job &&
                    stat.Index == Index)
                {
                    return stat;
                }
            }

            return null;
        }
        
    }
}
