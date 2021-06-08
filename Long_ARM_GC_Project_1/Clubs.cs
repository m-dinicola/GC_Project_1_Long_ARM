using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Long_ARM_GC_Project_1
{
    public class Clubs
    {
        public Dictionary<string, Club> ClubDictionary {get; set;}
        public Clubs()
        {
            ClubDictionary = new Dictionary<string, Club>(StringComparer.OrdinalIgnoreCase);
            string[] fileLines = File.ReadAllLines("../../../Clubs.txt");
            foreach (string line in fileLines)
            {
                string[] split = line.Split('|');
                Club club = new Club(split[0], split[1]);
                ClubDictionary.Add(split[0], club);
            }
        }

    }
    
}
