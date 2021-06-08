using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public static class MainMenuControl
    {
        private static List<string> options = new List<string> { "Display/Add/Remove a Member", "Check a Member in", "Display a Bill of Fees", "Exit" };
        public static Clubs ClubDB { get; set; }
        

        public static void MemberAction(Member m)         //displays the info of the member passed to it.
        {
            MemberView.Display(m);
        }

        public static void WelcomeAction()
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                int selection = MenuLoop("Hello, welcome to Universal Fitness!", options);
                tryAgain = FunctionSwitch(selection);
                //once a valid selection is confirmed, put up view for the option at the selection's index
            }
            Console.WriteLine("See Ya, Bro. May your weights be heavy, and your gains plentiful.");
        }

        public static int MenuLoop(string header, List<string> _options, string message)
        {
            int selection = 0;
            while (true)
            {
                MainMenuView.RefreshGUI(header, _options, selection, message);
                ConsoleKey keyPress = Console.ReadKey(true).Key;
                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        selection = Math.Max(0, selection - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selection = Math.Min(_options.Count - 1, selection + 1);
                        break;
                    default:
                        break;
                    case ConsoleKey.Enter:
                        return selection;
                }
            }
        }

        public static int MenuLoop(string header, List<string> _options)
        {
            return MenuLoop(header, _options, "");
        }

        public static bool FunctionSwitch(int selection)
        {
            switch (selection)
            {
                case 0:
                    MemberControl.MemberActions();
                    break;
                case 1:
                    //CheckIn
                    MemberControl.CheckInMember();
                    break;
                case 2:
                    //BillOfFees()
                    BillView.DisplayBill(MemberControl.MemberSelect("print a bill for"));
                    break;
                default:
                    return false;

            }
            return true;
        }
    }
}
