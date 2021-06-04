﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public static class BillView
    {
        public static void DisplayBill(Member member)
        {
            Bill newBill = new Bill();
            Console.WriteLine($"This is the bill of fees for {member.Name}:\nMonthly Plan - {newBill.MonthlyPlan}" +
                $"\nEquipment - {newBill.Equipment}\nSpa - {newBill.Spa}\nClasses - {newBill.Classes}\nParking - {newBill.Parking}");
            Console.WriteLine();
        }

        public static void DisplayBill(MultiClubMembers member)
        {
            Bill newBill = new Bill();
            Console.WriteLine($"This is the bill of fees for {member.Name}:\nMonthly Plan - {newBill.MonthlyPlan}" +
                $"\nEquipment - {newBill.Equipment}\nSpa - {newBill.Spa}\nClasses - {newBill.Classes}\nParking - {newBill.Parking}\n");
            Console.WriteLine($"Membership Points - {member.MembershipPoints}");
            Console.WriteLine();
        }
    }
}
