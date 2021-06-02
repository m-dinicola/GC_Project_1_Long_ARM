using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class Bill
    {
        public double MonthlyPlan { get; set; }
        public double Equipment { get; set; }
        public double Spa { get; set; }
        public double Classes { get; set; }
        public double Parking { get; set; }

        public Bill()
        {
            MonthlyPlan = 50.00;
            Equipment = 14.99;
            Spa = 19.99;
            Classes = 24.99;
            Parking = 9.99;
        }

        //The bill class is a good opportunity to have a different pay-scale for different gyms
        //We would have to include a bill in each Club definition, and in the multi-club member constructor
    }
}
