using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public static class MemberControl
    {
        public static MemberDB members = new MemberDB(new Clubs());
        public static void EditMembers()
        {
            List<string> options = new List<string> { "Display Member", "Add Member", "Remove Member", "Exit" };
            OptionView.Display(options);
            int selection = -1;                         //selection will remain -1 if output was invalid.
            while (!int.TryParse(Console.ReadLine(), out selection) || selection > options.Count || selection <= 0)
            {                       //if tryParse fails, or if the int is outside the range of options this will run.
                Console.Write($"Invalid entry. Please enter the number of your desired option. ");
            }

            //DisplayMemberInfo()
        }

        public static bool FunctionSwitch(int selection)
        {
            switch (selection)
            {
                case 1:
                    DisplayMemberInfo();
                    break;
                case 2:
                    AddMember();
                    break;
                case 3:
                    RemoveMember();
                    break;
                default:
                    return false;

            }
            return true;
        }

        public static Member MemberSelect(string action)
        {
            while (true) {                        //currently, loop cannot be exited if you do not want to follow through. Possible added functionality.
                int _ID;
                string orID = "";
                if (action.ToLower() != "add")
                {
                    orID = "or ID number ";
                }
                Console.WriteLine($"Please enter the name {orID}of the member you would like to {action}.");
                string response = Console.ReadLine().Trim();
                if (int.TryParse(response, out _ID))
                {
                    if (members.Members.ContainsKey(_ID) && orID == "or ID number ")
                    {
                        return members.Members[_ID];
                    }
                    Console.WriteLine($"There is no member with ID number {_ID}.");
                }
                else
                {
                    Member foundMember = members.GetMemberByName(response);
                    if (foundMember != null){
                        return foundMember;
                    }
                    Console.WriteLine($"No member was found with name \"{response}\".");
                }
            }
        }

        public static void AddMember()
        {

        }

        public static void RemoveMember()
        {

        }
        
        public static void DisplayMemberInfo()
        {
            var member = MemberSelect("display");

            if (typeof(Member).GetProperty("TheirClub") != null)
                Console.WriteLine(ParseMember((SingleClubMembers)member));
            else
                Console.WriteLine(ParseMember((MultiClubMembers)member));
        }

        public static string ParseMember(SingleClubMembers member)
        {
            return ($"\nClub: {member.TheirClub.Name}\n Address: {member.TheirClub.Address}");
        }
        public static string ParseMember(MultiClubMembers member)
        {
            return ($"Club: Universal\n Membership Points: {member.MembershipPoints}");
        }
    }
}
