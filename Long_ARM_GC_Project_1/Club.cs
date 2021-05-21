using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class Club
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Club()
        {

        }
        public Club(string name, string address)
        {
            Name = name;
            Address = address;
        }

    }
}
