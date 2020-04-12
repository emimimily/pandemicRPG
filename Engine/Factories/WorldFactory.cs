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
            //New York
            newWorld.AddLocation(0, 0,
                "Home", 
                "This is your apartment.",
                "/Engine;component/Images/Locations/apartment_nyc.png");
            newWorld.AddLocation(1, 0,
                "Store",
                "This is a grocery store.",
                "/Engine;component/Images/Locations/grocery_nyc.png");
            newWorld.AddLocation(0, 1,
                "Work",
                "You are at work.",
                "/Engine;component/Images/Locations/bank_nyc.png");
            newWorld.AddLocation(-1, 0,
                "Hospital",
                "You are at a hospital.",
                "/Engine;component/Images/Locations/hospital_nyc.png");

            //Wuhan
            newWorld.AddLocation(3, -2,
                "Home",
                "This is your apartment.",
                "/Engine;component/Images/Locations/apartment_wuhan.png");
            newWorld.AddLocation(4, -2,
                "Store",
                "This is a grocery store.",
                "/Engine;component/Images/Locations/grocery_wuhan.png");
            newWorld.AddLocation(3, -1,
                "Work",
                "You are at work.",
                "/Engine;component/Images/Locations/bank_wuhan.png");
            newWorld.AddLocation(2, -2,
                "Hospital",
                "You are at a hospital.",
                "/Engine;component/Images/Locations/hospital_wuhan.png");

            //Los Angeles
            newWorld.AddLocation(-3, 0,
                 "Home",
                 "This is your apartment.",
                 "/Engine;component/Images/Locations/apartment_la.png");
            newWorld.AddLocation(-2, 0,
                "Store",
                "This is a grocery store.",
                "/Engine;component/Images/Locations/grocery_la.png");
            newWorld.AddLocation(-3, 1,
                "Work",
                "You are at work.",
                "/Engine;component/Images/Locations/bank_la.png");
            newWorld.AddLocation(-4, 0,
                "Hospital",
                "You are at a hospital.",
                "/Engine;component/Images/Locations/hospital_la.png");

            //London
            newWorld.AddLocation(3, 0,
                "Home",
                "This is your apartment.",
                "/Engine;component/Images/Locations/apartment_london.png");
            newWorld.AddLocation(4, 0,
                "Store",
                "This is a grocery store.",
                "/Engine;component/Images/Locations/grocery_london.png");
            newWorld.AddLocation(3, 1,
                "Work",
                "You are at work.",
                "/Engine;component/Images/Locations/bank_london.png");
            newWorld.AddLocation(2, 0,
                "Hospital",
                "You are at a hospital.",
                "/Engine;component/Images/Locations/hospital_london.png");
            return newWorld;
        }
    }
}