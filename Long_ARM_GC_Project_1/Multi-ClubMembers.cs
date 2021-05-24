using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class Multi_ClubMembers : Member
    {
        public int MembershipPoints { get; set; }

        public Multi_ClubMembers(int id, string name)
        {
            Name = name;
            ID = id;
        }

        public override void CheckIn(string input)
        {
            MembershipPoints++;
        }
    }
}
