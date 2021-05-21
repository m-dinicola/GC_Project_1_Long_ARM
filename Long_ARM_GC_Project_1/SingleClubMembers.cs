using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class SingleClubMembers : Member
    {
        public Club TheirClub { get; set; }

        public SingleClubMembers(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        public static void AssaignToClub(string input)
        {
            TheirClub = Clubs[input];
        }

        public override void CheckIn(Club club)
        {
            if (TheirClub != )
        }
    }
}
