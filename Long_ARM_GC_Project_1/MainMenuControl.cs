using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public static class MainMenuControl
    {
        private static List<string> options = new List<string> { "Add/Remove/Display a Member", "Check a Member in", "Display a Bill of Fees", "Exit" };
        public static Clubs ClubDB { get; set; }
        private static FauxGUI _GUI = new FauxGUI();

        public static void MemberAction(Member m)         //displays the info of the member passed to it.
        {
            MemberView.Display(m);
        }

        public static void WelcomeAction()
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                int selection = MenuLoop();

                //int selection = -1;                         //selection will remain -1 if output was invalid.
                //while (!int.TryParse(Console.ReadLine(), out selection) || selection > options.Count || selection <= 0)
                //{                       //if tryParse fails, or if the int is outside the range of options this will run.
                //    Console.Write($"Invalid entry. Please enter the number of your desired option. ");
                //}
                tryAgain = FunctionSwitch(selection);
                //once a valid selection is confirmed, put up view for the option at the selection's index

                //method for switching between functions        
                //Console.WriteLine("Would you like to perform another action? (y/n)");
                //string input = Console.ReadLine();
                //while (input != "y" && input != "yes" && input != "n" && input != "no")
                //{       //if the entry was invalid, we will re-prompwt.
                //    Console.Write($"Invalid entry \"{input}\". Please try again. ");
                //    input = Console.ReadLine();
                //}
                //tryAgain = input[0] == 'y';     //tryAgain will have the same value as the match between y and char 1 of entry.
            }
            Console.WriteLine("See Ya, Bro. May your weights be heavy, and your gains plentiful.");
        }

        public static int MenuLoop()
        {
            int selection = 0;
            while (true)
            {
                _GUI.ResetBuffer();
                _GUI.SetHeader("Hello, welcome to Universal Fitness!"); //add the header to the buffer
                _GUI.SetMenu(OptionView.Display(options, selection));              //add the menu to the buffer
                _GUI.SetMenuWait();
                _GUI.DrawGUI();
                ConsoleKey keyPress = Console.ReadKey(false).Key;
                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        selection = Math.Max(0, selection - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selection = Math.Min(options.Count - 1, selection + 1);
                        break;
                    default:
                        break;
                    case ConsoleKey.Enter:
                        return selection;
                }
            }
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
