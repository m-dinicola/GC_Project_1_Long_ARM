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

        //Overload to construct member with club
        public SingleClubMembers(int id, string name, Club club) : this(id, name)
        {
            TheirClub = club;
        }

        //methods
        public void AssignToClub(string input)
        {
            Clubs clubs = new Clubs();
            if (clubs.ClubDictionary.ContainsKey(input))
            {
                TheirClub = clubs.ClubDictionary[input];
                Console.WriteLine($"{this.Name} has been assigned to {input}");
            }
            else
                Console.WriteLine("I'm sorry, but that club doesen't exists.");
            //LOOP THIS
        }
        //possible extension - allow changing from single club to multiclub member
        public override void CheckIn(Club club)
        {
            try
            {
                if (club.Name != TheirClub.Name)
                {
                    throw new IndexOutOfRangeException();
                }
                Console.WriteLine("This member has been checked in");
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("This member is not a member of this club");
            }
        }
    }
}
