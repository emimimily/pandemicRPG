using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class QuestionStatus
    {
        public string Location { get; set; }
        public string City { get; set; }
        public string Stage { get; set; }
        public string InfectionChance { get; set; }
        public string InfectionSeverity { get; set; }
        public string Job { get; set; }
        public int Index { get; set; }
        public string Message { get; set; }
    }
}
