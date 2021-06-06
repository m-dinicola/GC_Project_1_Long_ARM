using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public static class MemberView
    {


        private static FauxGUI _GUI = new FauxGUI(ConsoleColor.Black, ConsoleColor.Green);
        private static List<string> preloadedText = new List<string>();

        
        public static void PromptView(string header, string prompt)
        {
            _GUI.SetHeader(header);     //add the header to the buffer
            _GUI.ResetBuffer();
            _GUI.AddLines(3);
            _GUI.AddText(preloadedText);
            preloadedText.Clear();
            _GUI.SetPrompt(prompt);
            _GUI.RefreshGUI();
        }

        public static void Preload(string text)
        {
            preloadedText.Add(text);
        }

        //methods
        public static void Display(Member m)
        {

        }
    }
}
