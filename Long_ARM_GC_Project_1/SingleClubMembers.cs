using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class SingleClubMembers : Member
    {
        public string TheirClub { get; set; }

        public SingleClubMembers(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }


        public override void CheckIn(Club club)
        {
            //check if they are checking into the appropriate club
            if (TheirClub != club)
            {
                Console.WriteLine("This isn't the correct club");
                //Add exception
            }
        }
    }
}
