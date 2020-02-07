using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class MC_Member : Member
    {
        // fields
        private int memberPoints;
        
        // properties
        public string MemberPoints { get; set; }
        
        // constructors
        public MC_Member() { }

        // methods
        public override void CheckIn(Club club)
        {
            // CheckedInto = club.name;
            // Member points accrue by 10 ppints
            MemberPoints += 10;
        }

        public override void AddMember()
        {
            // May be later randomized and automatically entered in by the system
            Id = int.Parse(GetUserInput("Enter new member's ID"));
            FirstName = GetUserInput("Please enter your first name:");
            LastName = GetUserInput("Please enter your last name:");
            Fees = 19.95;
        }

        public void DisplayInfo()       // <-- Needs to be added to Member and single-member classes
        {
            Console.WriteLine($"\n\nMember ID: {Id}\t\tName: {LastName}, {FirstName}\tFees: {Fees}");
            Console.WriteLine($"You have {MemberPoints} member points!");
            Console.WriteLine("\t***MULTI-CLUB MEMBER ***");

        }

        public static string GetUserInput(string message)
        {
            // Relocate to another area
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
