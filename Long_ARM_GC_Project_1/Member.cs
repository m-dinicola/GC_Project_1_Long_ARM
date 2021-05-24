using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    abstract class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Member()
        {

        }

        public Member(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public abstract void CheckIn(string input);
    }
}
