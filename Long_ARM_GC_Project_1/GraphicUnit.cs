using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public class GraphicUnit
    {
        public ConsoleColor BG { get; set; }
        public ConsoleColor FG { get; set; }
            public string Text { get; set; }

        public GraphicUnit(ConsoleColor bg, ConsoleColor fg, string text)
        {
            BG = bg;
            FG = fg;
            Text = text;
        }

        public void Draw()
        {
            Console.BackgroundColor = BG;
            Console.ForegroundColor = FG;
            Console.Write(Text);
        }
    }
}
