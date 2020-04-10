using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal class UpdateFactory
    {
        internal Updates CreateUpdate()
        {
            Updates newUpdate = new Updates();
            newUpdate.AddDailyUpdate("New York City", 1, "New York has had 600 cases and its first 2 deaths. The United States has surpassed 50 deaths. President Trump has tested negative.");
            newUpdate.AddDailyUpdate("New York City", 2, "New York has had 700 cases. Italy has surpassed 1,800 deaths. The C.D.C. advised no gatherings of 50 or more people.");
            newUpdate.AddDailyUpdate("New York City", 3, "New York has had 900 cases. Italy has surpassed 25,000 cases.");
            newUpdate.AddDailyUpdate("New York City", 4, "New York has had 1,000 cases and 10 deaths. All 62 counties in New York have declared a state of emergency. Schools, bars, and restaurants will be closed, except for food takeout and delivery.");
            newUpdate.AddDailyUpdate("New York City", 5, "New York has had 2,000 cases. The U.S. has closed its borders to non-esssential traveling. President Trump has signed into a COVID-19 relief package which includes free testing and paid emergency leave.");
            newUpdate.AddDailyUpdate("New York City", 6, "New York has had 4,000 cases. China has reported no COVID-19 cases for the first time since the pandemic began. Italy now has the most COVID-19 related deaths at 3,405.");
            newUpdate.AddDailyUpdate("New York City", 7, "New York has had 5,000 cases. President Trump has declared a major emergency in New York and requested for federal assistance to be given. Spain has nearly 20,000 cases.");
            newUpdate.AddDailyUpdate("New York City", 8, "New York has had 10,000 cases and 50 deaths. Mayor de Blasio said New York City is the epicenter of the COVID-19 pandemic in the U.S.");
            newUpdate.AddDailyUpdate("New York City", 9, "New York has had 900 cases. Italy has surpassed 25,000 cases.");
            newUpdate.AddDailyUpdate("New York City", 10, "Governor Andrew Cuomo has issued a stay at home order to all New Yorkers. Senator Rand Paul has become the first senator to test positive. Italy has surpassed 50,000 cases.");
            newUpdate.AddDailyUpdate("New York City", 11, "New York has had 20,000 cases and 100 deaths. Iran has surpassed 20,000 cases. Globally, there have been more than 300,000 cases.");
            newUpdate.AddDailyUpdate("New York City", 12, "The United States has surpassed 50,000 cases. Chinese authorities have stated that travel restrictions in Wuahn will be lifted on 4/8");
            newUpdate.AddDailyUpdate("New York City", 13, "New York has had 30,000 cases. The White House and Senate have agreed upon a $2 trillion stimulus deal to help lessen the economic damage of COVID-19. Spain now has the second-highest death toll at 3,434.");
            newUpdate.AddDailyUpdate("New York City", 14, "USNS Comfort, a hospital ship of the United States Navy, is heading to New York City to assist hospitals.");

            return newUpdate;
        }
    }
}
