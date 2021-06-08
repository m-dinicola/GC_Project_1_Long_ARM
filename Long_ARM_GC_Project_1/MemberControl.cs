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
            string input = GUIPrompt("Please enter the club name: \n");

            Club club = new Club
            {
                Name = input
            };
            member.CheckIn(club);
            members.UpdateMembersFile();
            Console.ReadKey(false);

        }


        public static void MemberActions()
        {
            List<string> options = new List<string> { "Display Member", "Add Member", "Remove Member", "Exit" };
            int selection = MainMenuControl.MenuLoop("Member Menu", options);
            FunctionSwitch(selection);
        }

        public static bool FunctionSwitch(int selection)
        {
            switch (selection)
            {
                case 0:
                    DisplayMemberInfo();
                    break;
                case 1:
                    AddMember();
                    break;
                case 2:
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
                string response = GUIPrompt(
                    $"Please enter the name or ID number of the member you would like to {action}. " +
                    $"Leave the field blank to go back to the Main Menu.");

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
                        GUIPrepend($"There is no member with ID number {_ID}. Please try again.\n");
                    }
                }
                else
                {
                    List<Member> namedMembers = members.MembersByName(response);
                    if(namedMembers.Count > 1)
                    {
                        int selection = MainMenuControl.MenuLoop("Member Selection", namedMembers.Select(x => x.ToString()).ToList(), "There was more than one member by that name. ");
                        return namedMembers[selection];
                    }
                    if (namedMembers.Count == 1)
                    {
                        return namedMembers[0];
                    }
                    GUIPrepend($"No member was found with name \"{response}\". Please try again. \n");
                }
            }
        }

        public static void AddMember()
        {
            while (!AddMemberLoop())
            {
            }
            return;


        }

        public static bool AddMemberLoop()
        {
            int _ID = Math.Max(9999, members.Members.Keys.Max()) + 1;
            string name = GUIPrompt("Please enter the name of the person you would like to add as a new member: ");
            if (getYesNo($"Would {name} like to join the Universal Fitness Program, and be able to enter any participating club? "))
            {
                if (getYesNo($"The person named \"{name}\" would like to be a Universal Fitness Program member. Is this correct? "))
                {
                    members.Add(new MultiClubMembers(_ID, name));
                    return !getYesNo($"{name} has been added as a Universal Fitness Program member. Would you like to add another member? ");
                }
                return !getYesNo($"{name} has not been added as a member. Would you like to try again?");
            }
            try
            {
                string clubName = GUIPrompt($"Please enter the name of the club that {name} would like to join: ");
                Club club = clubs.ClubDictionary[clubName];
                if (getYesNo($"The person named \"{name}\" would like to be a member of {clubName}. Is this correct? "))
                {
                    members.Add(new SingleClubMembers(_ID, name, club));
                    return !getYesNo($"{name} has been added as a member of {clubName}. Would you like to add another member? ");
                }
                return !getYesNo($"{name} has not been added as a member. Would you like to try again?");
            }
            catch (KeyNotFoundException e)
            {
                GUIPrepend("No such club exists. Please try again." + e.Message +"\n");
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
            Console.WriteLine($"{member.Name} has been removed from the system. Press \"ENTER\" to continue.");
            Console.ReadKey(true);
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
                GUIPrepend(ParseMember((SingleClubMembers)member));
            }
            else
            {
                GUIPrepend(ParseMember((MultiClubMembers)member));
            }
            GUIPrompt("Press \"ENTER\" to continue");
        }

        public static string ParseMember(SingleClubMembers member)
        {
            return ($"Name: {member.Name}\nID#: {member.ID}\nClub: {member.TheirClub.Name}\nAddress: {member.TheirClub.Address}\n\n");
        }
        public static string ParseMember(MultiClubMembers member)
        {
            return ($"Name: {member.Name}\nID#: {member.ID}\nClub: Universal\nMembership Points: {member.MembershipPoints}\n\n");
        }

        public static bool getYesNo(string message)
        {
            string input = GUIPrompt($"{message} (y/n) ");
            while (input != "y" && input != "yes" && input != "n" && input != "no")
            {       //if the entry was invalid, we will re-prompt.
                input = GUIPrompt($"Invalid entry \"{input}\". Please try again. \n");
            }
            return input[0] == 'y';
        }

        public static string GUIPrompt(string prompt)
        {
            MemberView.PromptView("Member Menu", prompt);
            return Console.ReadLine().Trim();
        }

        public static void GUIPrepend(string text)
        {
            MemberView.Preload(text);
        }

    }
}
