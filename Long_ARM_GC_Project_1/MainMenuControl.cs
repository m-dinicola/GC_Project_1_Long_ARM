using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public class MainMenuControl
    {
        public Clubs ClubDB { get; set; }

        public MainMenuControl(Clubs clubDB)
        {
            ClubDB = clubDB;      //constructor stores the clubs as a dictionary
        }

        public void MemberAction(Member m)         //displays the info of the member passed to it.
        {
            MemberView.Display(m);
        }

        public void WelcomeAction()
        {
            Console.WriteLine("Hello, welcome to Universal Fitness");
            bool tryAgain = true;
            while (tryAgain)
            {
                Console.WriteLine("Please select an option from the following list:");  //after loop starts, so it will display on tryAgains
                OptionView.Display();                       //Display the list of options.
                int selection = -1;                         //selection will remain -1 if output was invalid.
                while (!int.TryParse(Console.ReadLine(), out selection) || selection >= OptionView.MainOptions.Count || selection < 0)
                {                       //if tryParse fails, or if the int is outside the range of options this will run.
                    Console.Write($"Invalid entry. Please enter the number of your desired option. ");
                }
                //once a valid selection is confirmed, put up view for the option at the selection's index
                //old code: CountryAction(ClubDB[selection]);        
                Console.WriteLine("Would you like to perform another action? (y/n)");
                string input = Console.ReadLine();
                while (input != "y" && input != "yes" && input != "n" && input != "no")
                {       //if the entry was invalid, we will re-prompt.
                    Console.Write($"Invalid entry \"{input}\". Please try again. ");
                    input = Console.ReadLine();
                }
                tryAgain = input[0] == 'y';     //tryAgain will have the same value as the match between y and char 1 of entry.
            }
        }
    }
}
