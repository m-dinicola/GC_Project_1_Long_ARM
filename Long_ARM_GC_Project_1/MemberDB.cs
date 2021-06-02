using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Long_ARM_GC_Project_1
{
    public class MemberDB
    {
        private Clubs _clubDB;
        public Dictionary<int, Member> Members { get; set; }

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
        
        public void AppendMemberToFile(Member m)
        {
            List<string> memberText = new List<string>();
            if (m.GetType().GetProperty("MembershipPoints") != null)
            {
                memberText.Add(MemberToString((MultiClubMembers)m));
            }
            else
            {
                memberText.Add(MemberToString((SingleClubMembers)m));
            }
            File.AppendAllLines("../../../Members.txt", memberText);
        }

        public void UpdateMembersFile()
        {
            List<string> fileLines = new List<string>();
            foreach(Member m in Members.Values)
            {
                if (m.GetType().GetProperty("MembershipPoints") != null)
                {
                    fileLines.Add(MemberToString((MultiClubMembers)m));
                }
                else
                {
                    fileLines.Add(MemberToString((SingleClubMembers)m));
                }
            }
            File.WriteAllLines("../../../Members.txt",fileLines);
        }


        public static string MemberToString(MultiClubMembers m)
        {
            return $"{m.ID}|{m.Name}|{m.MembershipPoints}";
        }

        public static string MemberToString(SingleClubMembers m)
        {
            return $"{m.ID}|{m.Name}|{m.TheirClub.Name}";
        }

        public Member GetMemberByName(string name)
        {
            foreach(Member member in Members.Values)
            {
                if (member.Name.ToLower() == name.ToLower())
                {
                    return member;
                }
            }
            return null;
        }

        public Member MemberFactory(string[] input) 
        {
            int id = int.Parse(input[0]);
            int points;
            if (int.TryParse(input[2], out points))
            {
            return new MultiClubMembers(id, input[1], points);
            }    
                return new SingleClubMembers(id, input[1], _clubDB.ClubDictionary[input[2]]);
        }

        public void Add(Member m)
        {
            Members.Add(m.ID, m);
            AppendMemberToFile(m);
        }
    }
}
