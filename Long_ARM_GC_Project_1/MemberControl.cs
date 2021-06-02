using System;
using System.Collections.Generic;
using System.Text;

namespace Long_ARM_GC_Project_1
{
    class MemberControl
    {
    public void CheckInMember()
        {
            //call memberSelect to checkin members
            MemberDB checkin = new MemberDB(memberSelect);

            if (Member == memberSelect)   //check if member is listed in database
            {
                if (Member == SingleClubMembers) //check if single club or multi-club member
                {
                    if ()  //single club member-  verify club
                    {

                    }
                }
                else   //multiclub member
                {
                    //add membership points 
                }
            }
            else
            {
                //create new member
            }
        }
    }
}
