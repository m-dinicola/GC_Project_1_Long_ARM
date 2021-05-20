using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class SingleClubMembers : Member
    {
        public SingleClubMembers(int id, string name, Club club /*Club class to be added*/) : base(id, name)
        {
            ID = id;
            Name = name;
            CheckIn(club);
        }


        public override void CheckIn(Club club)
        {
            try
            {
                Club = club;
            }
            catch
            {
                if ()
            }
        }
    }
}
