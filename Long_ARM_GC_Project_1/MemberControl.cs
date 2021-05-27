using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class MemberControl
    {



        public static void DisplayMemberInfo()
        {
            var result = MemberSelect();
            Console.WriteLine($"Member: {member.Name} \nID:{member.ID}");
            if (member.HasProperty(TheirClub))
            {
                Console.WriteLine($"\nClub: {club.Name}\n Address: {club.Address}");
            }
            else if (member.HasProperty(MembershipPoints))
            {
                Console.WriteLine($"Club: Universal\n Membership Points: {member.MembershipPoints}");
            }
        }
    }
}
