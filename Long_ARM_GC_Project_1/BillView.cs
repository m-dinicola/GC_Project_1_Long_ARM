﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class BillView
    {
        public static void DisplayBill(Member member)
        {
            Bill newBill = new Bill();
            Console.WriteLine($"This is the bill of fees for {member.Name}:\nMonthly Plan - {newBill.MonthlyPlan}" +
                $"\nEquipment - {newBill.Equipment}\nSpa - {newBill.Spa}\nClasses - {newBill.Classes}\nParking - {newBill.Parking}");
        }

        public static void MultiDisplayBill(MultiClubMembers member)
        {
            DisplayBill(member);
            Console.WriteLine($"Membership Points - {member.MembershipPoints}");
        }
    }
}
