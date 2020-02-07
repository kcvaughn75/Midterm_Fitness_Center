using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class SingleClubClass : Member
    {    
        //properties
        public string HomeClub { get; set; }


        //default constructor
        public SingleClubClass()
        {

        }

        //overloaded constructor
        public SingleClubClass(int iD, string firstName, string lastName, double fees, string homeClub)
        {
            Id = Id;
            FirstName = firstName;
            LastName = lastName;
            Fees = fees;
            HomeClub = homeClub;
        }

        //Wasn't sure if FindMemberByIdOrName method will work in this CheckIn method here?
        //will have to ccreate a bool variable and call below method here

        public override void CheckIn(Club club)
        {
            string userName = GetUserInput("Please enter member name:");
            int userId = int.Parse(GetUserInput("Please enter member ID:"));
            //How can we bring in List value here?
            bool temp = FindMemberByIdOrName(//ListName goes here, user Id, useName);
            if (temp)
            {
                Console.WriteLine($"Single club Member{userName} is checked in!");
            }
            else
            {
                Console.WriteLine($"{userName} is not a member of this club, but can drop in for $5 a day!");
            }
        }


        //Are we using Member class or Club class here to pass the value? Becuase Check in method has parameter from Club  
        /*public virtual bool FindMemberByIdOrName(List<Member> clubMember, int mId, string mName) 
        {
            bool retVal = false;
            foreach(Member mInfo  in clubMember)
            {
                if (mInfo.Id == mId || mInfo.FirstName == mName)
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }*/


        //Getting input from user
        public string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }


    }
}
