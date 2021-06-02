using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public class OptionView
    {
        //methods
        public static void Display(List<string> options)
        {
            Console.WriteLine("Please select an option from the following list:");
            int i = 1;
            foreach(string s in options)
            {
                Console.WriteLine($"{i}. {s}");
                i++;
            }
        }
    }
}
