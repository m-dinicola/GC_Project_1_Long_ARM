using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Long_ARM_GC_Project_1
{
    public static class MemberControl
    {

        private static Clubs clubs = new Clubs();
        public static MemberDB members = new MemberDB(clubs);
        public static void CheckInMember()
        {
            Member member = MemberSelect("check in");
            Console.WriteLine("Please enter the club name: \n");
            string input = Console.ReadLine();

            Club club = new Club();
            club.Name = input;
            member.CheckIn(club);


        }


        public static void MemberActions()
        {
            List<string> options = new List<string> { "Display Member", "Add Member", "Remove Member", "Exit" };
            OptionView.Display(options);
            int selection = -1;                         //selection will remain -1 if output was invalid.
            while (!int.TryParse(Console.ReadLine(), out selection) || selection > options.Count || selection <= 0)
            {                       //if tryParse fails, or if the int is outside the range of options this will run.
                Console.Write($"Invalid entry. Please enter the number of your desired option. \n");
            }
            FunctionSwitch(selection);
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
            while (true)
            {
                int _ID;

                Console.WriteLine($"Please enter the name or ID number of the member you would like to {action}. Leave the field blank to go back to the Main Menu.");

                string response = Console.ReadLine().Trim();
                if (response == "")
                {
                    return null;
                }
                if (int.TryParse(response, out _ID))
                {
                    try
                    {
                        return members.Members[_ID];
                    }
                    catch
                    {
                        Console.WriteLine($"There is no member with ID number {_ID}.\n");
                    }
                }
                else
                {
                    Member foundMember = members.GetMemberByName(response);
                    if (foundMember != null)
                    {
                        return foundMember;
                    }
                    Console.WriteLine($"No member was found with name \"{response}\".\n");
                }
            }
        }

        public static void AddMember()
        {
            while (!AddMemberLoop())
            {
                if (getYesNo("Would you like to go back to the Member Menu?\n"))
                {
                    return;
                }
            }


        }

        public static bool AddMemberLoop()
        {
            int _ID = Math.Max(9999, members.Members.Keys.Max()) + 1;
            Console.Write("Please enter the name of the person you would like to add as a new member: \n");
            string name = Console.ReadLine();
            if (getYesNo($"Would {name} like to join the Universal Fitness Program, and be able to enter any participating club?\n"))
            {
                if (getYesNo($"The person named \"{name}\" would like to be a Universal Fitness Program member. Is this correct?\n "))
                {
                    members.Add(new MultiClubMembers(_ID, name));
                    return true;
                }
                return false;
            }
            try
            {
                Console.Write($"Please enter the name of the club that {name} would like to join: \n");
                Club club = clubs.ClubDictionary[Console.ReadLine()];
                if (getYesNo($"The person named \"{name}\" would like to be a member of {name}. Is this correct?"))
                {
                    members.Add(new SingleClubMembers(_ID, name, club));
                    return true;
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("No such club exists. Please try again." + e.Message );
                Console.WriteLine();
            }
            return false;
        }

        public static void RemoveMember()
        {
            Member member = MemberSelect("remove");
            if (member == null)
            {
                return;
            }
            members.Members.Remove(member.ID);
            members.UpdateMembersFile();
            Console.WriteLine($"{member.Name} has been removed from the system.\n");
        }

        public static void DisplayMemberInfo()
        {
            var member = MemberSelect("display");
            if (member == null)
            {
                return;
            }
            if (member.GetType().GetProperty("TheirClub") != null)
            {
                Console.WriteLine(ParseMember((SingleClubMembers)member));
            }
            else
            {
                Console.WriteLine(ParseMember((MultiClubMembers)member));
            }
        }

        public static string ParseMember(SingleClubMembers member)
        {
            return ($"\nClub: {member.TheirClub.Name}\n Address: {member.TheirClub.Address}\n");
        }
        public static string ParseMember(MultiClubMembers member)
        {
            return ($"Club: Universal\n Membership Points: {member.MembershipPoints}\n");
        }

        public static bool getYesNo(string message)
        {
            Console.Write($"{message} (y/n) ");
            string input = Console.ReadLine();
            while (input != "y" && input != "yes" && input != "n" && input != "no")
            {       //if the entry was invalid, we will re-prompt.
                Console.Write($"Invalid entry \"{input}\". Please try again. \n");
                input = Console.ReadLine();
            }
            return input[0] == 'y';
        }

    }
}
