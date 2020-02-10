using System;
using System.Collections.Generic;
using System.Text;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    class Multi_Club : Member
    {
        public int Points { get; set; }
        
        public Multi_Club() { }

        public Multi_Club(int id,string firstName, string lastName, double monthlyFees, int points, double swagFees)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MonthlyFees = monthlyFees; 
            Points = points;
            SwagFees = swagFees;
        }


        public override void CheckIn(Club club, Member toCheckIn)
        {           
            if (club.Name == toCheckIn.HomeClub)
            {
                toCheckIn.CheckedInto = club.Name;
                Points += 5;
                Console.WriteLine($"Multi club Member{toCheckIn.FirstName} is checked in!");
                Console.WriteLine($"{toCheckIn.FirstName} has {Points} membership points!");
            }
            
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Points: {Points}");
            Console.WriteLine("\t***MULTI-CLUB MEMBER ***");
        }

        public override void AddMember(List<Club> clubList, List<Member> members)
        {
            base.AddMember(clubList, members);
            Console.WriteLine($"{FirstName} can access all the clubs!");
            Points = 50;
            Fees = 29.99;

            int genId = 0;
            bool duplicateFound = true;

            Random random = new Random();

            while (duplicateFound)
            {
                genId = random.Next(5001, 9999);

                for (int i = 0; i < members.Count; i++)
                {
                    if (members[i].Id != genId)
                    {
                        duplicateFound = false;
                    }
                    else
                    {
                        duplicateFound = true;
                    }
                }
            }
            Id = genId;

            //add the member to the list
        }
        //
        public static int GeneratePointsMulti(Multi_Club currentMember)
        {
            return currentMember.Points;
        }

        public static void GenerateMultiClubFeeBreakdown(Multi_Club member)
        {
            double feeSum = member.MonthlyFees + member.SwagFees;
            Console.WriteLine($"{member.FirstName}'s Monthly Fees Total: {member.MonthlyFees}  Other Gym Fees Total: {member.SwagFees}  Grand Total: {feeSum}.");

        }
    }
}
