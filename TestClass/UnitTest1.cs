using Long_ARM_GC_Project_1;
using System;
using Xunit;


namespace TestClass
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Hercules Fitness")]
        [InlineData("Side Bar Fitness")]
        [InlineData("Gym None")]
       
        public void ClubIsValid(string club)
        {
            Clubs clubdb = new Clubs();
            Exception result = null;
            try { Club Test = clubdb.ClubDictionary[club];
                
            }
                                 
            catch (Exception e)
            {
                result = e; 
            Assert.Null(result);
            }
           
        }
        [Theory]
        [InlineData("123 Generic Rd")]
        [InlineData("321 Main St")]
        public void AddressIsValid(string address)
        {
            Clubs clubdb = new Clubs();
            Exception result = null;
            try { Club Test = clubdb.ClubDictionary[address]; }

            catch (Exception e)
            {
                result = e;
                Assert.Null(result);
            }
        }
          
        [Theory]
        [InlineData()]

        public void MemberIsValid(int Id, string name, string club)
        {
            Member memberdb = new Member();
            Exception result = null;
            try { Member Test = memberdb.MemberDictionary[]; }
            catch (Exception e)
            {
                result = e;
                Assert.Null(result);
            }
        }
    }
}
