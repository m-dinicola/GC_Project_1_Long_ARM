using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public static class MainMenuControl
    {
        private static List<string> options = new List<string> { "Add/Remove/Display a Member", "Check a Member in", "Display a Bill of Fees", "Exit" };
        public static Clubs ClubDB { get; set; }


        public static void MemberAction(Member m)         //displays the info of the member passed to it.
        {
            MemberView.Display(m);
        }

        public static void WelcomeAction()
        {
            Console.WriteLine("Hello, welcome to Universal Fitness");
            bool tryAgain = true;
            while (tryAgain)
            {
                OptionView.Display(options);                       //Display the list of options.
                int selection = -1;                         //selection will remain -1 if output was invalid.
                while (!int.TryParse(Console.ReadLine(), out selection) || selection > options.Count || selection <= 0)
                {                       //if tryParse fails, or if the int is outside the range of options this will run.
                    Console.Write($"Invalid entry. Please enter the number of your desired option. ");
                }
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

        public static bool FunctionSwitch(int selection)
        {
            switch (selection)
            {
                case 1:
                    MemberControl.MemberActions();
                    break;
                case 2:
                    //CheckIn
                    break;
                case 3:
                    //BillOfFees()
                    break;
                default:
                    return false;

            }
            return true;
        }
    }
}
