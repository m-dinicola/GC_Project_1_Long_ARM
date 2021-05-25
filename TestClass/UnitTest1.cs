using Long_ARM_GC_Project_1.Clubs;
using System;
using Xunit;


namespace TestClass
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(Hercules Fitness)]
        [InlineData(Side Bar Fitness)]
        [InlineData(Gym None)]        
        [InlineData(123 Generic Rd)]
        [InlineData(321 Main St)]

        public bool ClubIsValid(string club)
        {
            if (club != null)
            {
                return true;
            }
            return false;
        }
        
        public bool AddressIsValid(string address)
        {
            if (address != null)
            {
                return true;
            }
            return false;
        }
          


        
    }
}
