using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Long_ARM_GC_Project_1
{
    public class MemberDB
    {
        private Clubs _clubDB;
        public Dictionary<int, Member> Members;

        public MemberDB(Clubs clubDB)
        {
            _clubDB = clubDB;
            Members = new Dictionary<int, Member>();
            string[] fileLines = File.ReadAllLines("../../../Members.txt");
            foreach (string line in fileLines)
            {
                string[] split = line.Split('|');
                Member m = MemberFactory(split);
                Members.Add(m.ID, m);
            }
        }

        public Member MemberFactory(string[] input) 
        {
            if (input.Length == 3)
            {
                return new SingleClubMembers(int.Parse(input[0]), input[1], _clubDB.ClubDictionary[input[3]]);
            }    
            return new MultiClubMembers(input[0], input[0]);
        }
    }
}
