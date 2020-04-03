using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal class WorldFactory
    {
        internal World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(0, 0,
                "Home", 
                "This is your apartment.",
                "/Engine;component/Images/Locations/house (1).png");
            newWorld.AddLocation(1, 0,
                "Store",
                "This is a grocery store.",
                "/Engine;component/Images/Locations/testHome.png");
            newWorld.AddLocation(0, 1,
                "Work",
                "You are at work.",
                "/Engine;component/Images/Locations/testHome.png");
            newWorld.AddLocation(-1, 0,
                "Hospital",
                "You are at a hospital.",
                "/Engine;component/Images/Locations/testHome.png");
            return newWorld;
        }
    }
}