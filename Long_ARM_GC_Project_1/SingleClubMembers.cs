using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public class SingleClubMembers : Member
    {
        public Club TheirClub { get; set; }

        public SingleClubMembers(int id, string name)
        {
            Name = name;
            ID = id;
        }

        public SingleClubMembers(int id, string name, Club club) : this(id, name)
        {
            this.AssignToClub(club.Name);
        }

        public void AssignToClub(string input)
        {
            Clubs clubs = new Clubs();
            if (clubs.ClubDictionary.ContainsKey(input))
            {
                TheirClub = clubs.ClubDictionary[input];
                Console.WriteLine($"{this.Name} has been assaigned to {input}");
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
