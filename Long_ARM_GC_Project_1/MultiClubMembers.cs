using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public class MultiClubMembers : Member
    {
        public int MembershipPoints { get; set; }

        public MultiClubMembers(int id, string name)
        {
            Name = name;
            ID = id;
            MembershipPoints = 0;
        }

        public MultiClubMembers(int id, string name, int points) : this(id, name)
        {
            MembershipPoints = points;
        }

        public override void CheckIn(Club club)
        {
            Console.WriteLine("This member has been checked in (Enter to continue)\n");
            MembershipPoints++;
        }

        public override string ToString()
        {
            return ($"Name: {Name}\tID#: {ID}\nClub: Universal\t Membership Points: {MembershipPoints}\n\n");
        }
    }
}
