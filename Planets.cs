﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace SpaceGame
{
    class Planet
    {
        /** 
         * Constructor for Planet class
         * Params:
         *  name {string} name of planet
         *  story {string} story of planet - short dialog
         * Returns: 
         *  None
         */
        public Planet(string name="Template", string story="Template")
        {
            this.Name = name;
            this.Story = story;
        }
        // Method to randomly check if Crystal Man can appear
        public void CheckCrystalMan()
        {
            int rng = _random.Next(0, 10);
            this.HasCrystalMan = rng % 2 == 0 ? true: false ;
        }
        // Story Property to get and set story
        public string Story { get; set; }
        // Property to check whether planet has Crystal man
        public bool HasCrystalMan { get; set; }
        // Name Property for the planet
        public string Name { get; set; }
        // Random Number Generator instance
        private readonly Random _random = new Random();
    }

    // Class that makes up the galaxy for the current Game
    class Galaxy
    {
        /**
         * Constructor for the Galaxy class
         * Params:
         *  filaPath {string} the path to the file that holds the info for the planets
         */
        public Galaxy()
        {
            Utils tools = new Utils();
            // Set getItems to false so it loads from the PlanetConfig file
            List<Dictionary<string,string>> planetsList = tools.ReadPlanetXMLFile("Planet", getItems:false);
            foreach (Dictionary<string, string> planet in planetsList)
            {
                this.planetsInGalaxy.Add(planet["name"], new Planet(planet["name"], planet["story"]));
            }
        }
        // List of planets in the Galaxy
        public Dictionary<string, Planet> planetsInGalaxy = new Dictionary<string, Planet>();
        // Property to show which planet the player is on currently
        public string CurrentPlanet { get; set; }
    }
}
