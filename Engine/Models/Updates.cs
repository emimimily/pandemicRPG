using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Updates
    {
        private List<DailyUpdate> _dailyUpdate = new List<DailyUpdate>();
        internal void AddDailyUpdate(string city, int index, string caseUpdate)
        {
            DailyUpdate upd = new DailyUpdate();
            upd.City = city;
            upd.Index = index;
            upd.CaseUpdate = caseUpdate;

            _dailyUpdate.Add(upd);
        }

        public DailyUpdate UpdateAt(string city, int index)
        {
            foreach (DailyUpdate upd in _dailyUpdate)
            {
                if(upd.City==city && upd.Index == index)
                {
                    return upd;
                }
            }
            return null;
        }
    }
}
