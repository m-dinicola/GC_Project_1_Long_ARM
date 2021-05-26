using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public class OptionView
    {
        //properties
        public static List<string> MainOptions = new List<string>{ "Add/Remove/Display a Member","Check a Member in","Display a Bill of Fees","Exit" };

        //methods
        public static void Display(List<string> options)
        {
            int i = 1;
            foreach(string s in options)
            {
                Console.WriteLine($"{i}. {s}");
                i++;
            }
        }
    }
}
