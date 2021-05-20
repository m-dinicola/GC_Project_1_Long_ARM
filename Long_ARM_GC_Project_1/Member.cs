using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    abstract class Member
    {
        //properties
        public int ID { get; set; }
        public string Name { get; set; }

        //Constructor
        public Member(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
