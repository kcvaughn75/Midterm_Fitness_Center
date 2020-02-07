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

        public Multi_Club(int id,string firstName, string lastName, double fees, int points)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Fees = fees; 
            Points = points;
        }


        public override void CheckIn(Club club, List<Member> members)
        {
            Member toCheckIn = Program.DispMember(members);

           
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
            //add the member to the list
        }
    }
}
