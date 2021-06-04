using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    public static class BillView
    {
        public static void DisplayBill(Member member)
        {
            if (member == null)
            {
                return;
            }
            Bill newBill = new Bill();
<<<<<<< HEAD
            Console.WriteLine($"This is the bill of fees for {member.Name}:\nMonthly Plan - {newBill.MonthlyPlan}" +
                $"\nEquipment - ${newBill.Equipment}\nSpa - ${newBill.Spa}\nClasses - ${newBill.Classes}\nParking - ${newBill.Parking}");
            Console.WriteLine();
=======
            Console.WriteLine($"This is the bill of fees for {member.Name}:\nMonthly Plan - ${newBill.MonthlyPlan}" +
                $"\nEquipment - ${newBill.Equipment}\nSpa - ${newBill.Spa}\nClasses - ${newBill.Classes}\nParking - ${newBill.Parking}");
>>>>>>> 4351dff460b60eff97b3c313d46f8fe6fe894bbb
        }

        public static void DisplayBill(MultiClubMembers member)
        {
            Bill newBill = new Bill();
<<<<<<< HEAD
            Console.WriteLine($"This is the bill of fees for {member.Name}:\nMonthly Plan - {newBill.MonthlyPlan}" +
=======
            Console.WriteLine($"This is the bill of fees for {member.Name}:\nMonthly Plan - ${newBill.MonthlyPlan}" +
>>>>>>> 4351dff460b60eff97b3c313d46f8fe6fe894bbb
                $"\nEquipment - ${newBill.Equipment}\nSpa - ${newBill.Spa}\nClasses - ${newBill.Classes}\nParking - ${newBill.Parking}\n");
            Console.WriteLine($"Membership Points - {member.MembershipPoints}");
            Console.WriteLine();
        }
    }
}
