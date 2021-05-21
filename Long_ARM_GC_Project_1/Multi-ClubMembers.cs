using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class Multi_ClubMembers : Member
    {
        public Multi_ClubMembers(int id, string name) : base(id, name)
        {
            ID = id;
            Name = name;
        }

        int membershipPoints = 0;

        public override void CheckIn()
        {
            membershipPoints++;
        }
    }
}
