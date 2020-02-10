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

        public int OtherGymFees { get; set; }

        //overloaded constructor
        public SingleClubClass(int id, string firstName, string lastName, string homeClub, double monthlyFees)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HomeClub = homeClub;
            Fees = monthlyFees;
           // OtherGymFees = otherGymFees;
            //SwagFees = swagFees;
            
        }

        //Wasn't sure if FindMemberByIdOrName method will work in this CheckIn method here?
        //will have to ccreate a bool variable and call below method here

        public override void CheckIn(Club club, Member toCheckIn)
        {

            // bool temp = FindMemberByIdOrName(//ListName goes here, user Id, useName);
            try
            {
                if (club.Name == toCheckIn.HomeClub)
                {
                    toCheckIn.CheckedInto = club.Name;
                    Console.WriteLine($"Single club Member{toCheckIn.FirstName} is checked in!");
                }
            }
            catch
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
            
  
            int selectHomeClub = UserChoice("Enter the number of the club to set as the home club.", $"Please enter a number between 1-{clubList.Count}", clubList.Count);

            HomeClub = clubList[selectHomeClub - 1].Name;

            Console.WriteLine($"{HomeClub}, has been set as the members home club.");



            int genId = 0;
            bool duplicateFound = true;

            Random random = new Random();

            while (duplicateFound)
            {
                
                genId = random.Next(0, 5000);

                for (int i = 0; i < members.Count; i++)
                {
                    if (genId == members[i].Id)
                    {
                        duplicateFound = true;
                        break;
                    }
                    else
                    {
                        duplicateFound = false;
                    }
                }
            }
            Id = genId;

            Console.WriteLine($"The new single member ID is: {genId}");
            Fees = 19.99;
        }

        //        public static void GenerateSingleClubFeeBreakdown(SingleClubClass member)
        //        {
        //            double feeSum = member.MonthlyFees + member.OtherGymFees + member.SwagFees;
        //            Console.WriteLine($"{member.FirstName}'s Monthly Fees Total: {member.MonthlyFees} | Other Gym Fees Total: {member.OtherGymFees} | Swag Fees Total: {member.SwagFees} Grand Total: {feeSum}.");

        //        }

    }
}
