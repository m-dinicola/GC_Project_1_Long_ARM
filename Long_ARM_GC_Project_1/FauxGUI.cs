using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public class FauxGUI
    {
        public List<GraphicUnit> GUIBuffer { get; set; }
        public ConsoleColor DefaultBG { get; set; }
        public ConsoleColor DefaultFG { get; set; }
        public string CurrentHeader { get; set; }

        public FauxGUI(ConsoleColor bg, ConsoleColor fg)
        {
            DefaultBG = bg;
            DefaultFG = fg;
            GUIBuffer = new List<GraphicUnit> { new GraphicUnit(bg, fg, "") };
        }

        public void SetHeader(string header)
        {
            CurrentHeader = header.Trim();
            GUIBuffer[0] = new GraphicUnit(DefaultBG, DefaultFG, CurrentHeader+"\n");
        }

        internal void SetMenu(Tuple<string, List<string>, int> tuple)
        {
            SetMenu(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        public void SetMenu(string menuHeader, List<string> options, int highlight)
        {
            List<GraphicUnit> graphicUnits = new List<GraphicUnit>
            {
                GetGU(menuHeader + '\n', false)
            };
            foreach (string option in options)
            {
                graphicUnits.Add(GetGU(option + '\n', false));
            }
            graphicUnits[highlight+1] = GetGU(options[highlight] + '\n', true);     //has to hilight+1 b/c addition of header
            GUIBuffer.AddRange(graphicUnits);
        }

        public void SetMenuWait()
        {
            GUIBuffer.Add(new GraphicUnit(DefaultBG, DefaultFG, ""));
        }

        public void SetPrompt(string prompt)
        {
            GUIBuffer.Add(GetGU('\n' + prompt + "  ", false));
            GUIBuffer.Add(GetGU(" ", false));
        }

        public void DrawGUI()
        {
            foreach(GraphicUnit gu in GUIBuffer)
            {
                gu.Draw();
            }
        }

        public void RefreshGUI()
        {
            Console.Clear();
            DrawGUI();
        }

        public void ResetBuffer()
        {
            GUIBuffer = new List<GraphicUnit> { new GraphicUnit(DefaultBG, DefaultFG, "") };
            SetHeader(CurrentHeader);
        }

        public void AddLine()
        {
            GUIBuffer.Add(GetGU("\n", false));
        }

        public void AddText(string text)
        {
            GUIBuffer.Add(GetGU(text, false));
        }

        public void AddText(List<string> text)
        {
            foreach (string s in text)
            {
                GUIBuffer.Add(GetGU(s, false));
            }

        }

        public void AddLines(int num)
        {
            for(int i=0; i<num; i++)
            {
                AddLine();
            }
        }

        public GraphicUnit GetGU(string text, bool invert)
        {
            if (invert)
            {
                return new GraphicUnit(DefaultFG, DefaultBG, text);
            }
            return new GraphicUnit(DefaultBG, DefaultFG, text);
        }
    }
}
