using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public static class MainMenuView
    {
        private static FauxGUI _GUI = new FauxGUI(ConsoleColor.Black, ConsoleColor.Green);


        public static void RefreshGUI(string header, List<string> options, int selection, string message)
        {
            _GUI.SetHeader(header); //add the header to the buffer
            _GUI.ResetBuffer();
            _GUI.SetMenu(OptionView.Display(options, selection, message));              //add the menu to the buffer
            _GUI.SetMenuWait();
            _GUI.RefreshGUI();
        }

        public static void RefreshGUI(string header, List<string> options, int selection)
        {
            RefreshGUI(header, options, selection, "");
        }


    }
}
