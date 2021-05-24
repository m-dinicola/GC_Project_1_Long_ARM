using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class SingleClubMembers : Member
    {
        public static Club TheirClub { get; set; }

        public SingleClubMembers(int id, string name)
        {
            Name = name;
            ID = id;
        }

        public static void AssignToClub(string input)
        {
            Clubs clubs = new Clubs();
            if (clubs.ClubDictionary.ContainsKey(input))
            {
                var inputKey = clubs.ClubDictionary[input];
                TheirClub = inputKey;
                Console.WriteLine($"This user has been assaigned to {clubs.ClubDictionary[input].Name}");
            }
            else
                Console.WriteLine("I'm sorry, but that club doesen't exists.");
            //LOOP THIS
        }

        public override void CheckIn(string input)
        {
            if (TheirClub.Name == input)
            {
                Console.WriteLine($"This member has been checked in!");
            }
            else
                Console.WriteLine("This member isn't a part of this club!");
        }
    }
}
