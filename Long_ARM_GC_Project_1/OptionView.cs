using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public class OptionView
    {
        //methods
        public static Tuple<string, List<string>, int> Display(List<string> options, string message)
        {
            List<string> numerated = new List<string>();
            int i = 1;
            foreach(string s in options)
            {
                numerated.Add($"{i}. {s}");
                i++;
                
            }
            return new Tuple<string, List<string>, int>(message + "Please select an option from the following list:", numerated, 0);
        }

        public static Tuple<string, List<string>, int> Display(List<string> options)
        {
            return Display(options, "");
        }

        public static Tuple<string, List<string>, int> Display(List<string> options, int index, string message)
        {
            Tuple<string, List<string>, int> tuple = Display(options, message);
            return new Tuple<string, List<string>, int>(tuple.Item1, tuple.Item2, index);
        }
    }
}
