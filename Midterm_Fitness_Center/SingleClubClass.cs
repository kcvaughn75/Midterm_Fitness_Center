using System;
using System.Collections.Generic;
using System.Text;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    class SingleClubClass : Member
    {    
        //default constructor
        public SingleClubClass() { }
        

        //overloaded constructor
        public SingleClubClass(int id, string firstName, string lastName, string homeClub, double fees)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HomeClub = homeClub;
            Fees = fees;
            
        }

        //Wasn't sure if FindMemberByIdOrName method will work in this CheckIn method here?
        //will have to ccreate a bool variable and call below method here

        public override void CheckIn(Club club, List<Member> members)
        {

            Member toCheckIn = Program.DispMember(members);
            
           // bool temp = FindMemberByIdOrName(//ListName goes here, user Id, useName);
            if (club.Name == toCheckIn.HomeClub)
            {
                toCheckIn.CheckedInto = club.Name;
                Console.WriteLine($"Single club Member{toCheckIn.FirstName} is checked in!");
            }
            else
            {
                Console.WriteLine($"{toCheckIn.FirstName} is not a member of this club, but can drop in for $5 a day!");
                bool userContinue = UserSelection("Does the member want to pay (y/n)?", "y","n");
                if (userContinue)
                {
                    toCheckIn.CheckedInto = club.Name;
                    Console.WriteLine($"Single club Member{toCheckIn.FirstName} is checked in!");
                    toCheckIn.Fees += 5;
                    Console.WriteLine($"$5 has been added to the {toCheckIn.FirstName}'s monthly fees. Their total for this month is ${toCheckIn.Fees}");
                }
            }
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Home club: {HomeClub}");
        }

        public override void AddMember(List<Club> clubList, List<Member> members)
        {
            base.AddMember(clubList, members);
            
            int selectHomeClub = UserChoice(GetUserInput("Enter the number of the club to set as the home club?"), $"Please enter a number between 1-{clubList.Count}", clubList.Count);
            Fees = 19.99;
        }

    }
}
