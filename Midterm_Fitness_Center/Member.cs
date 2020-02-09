using System;
using System.Collections.Generic;
using System.Text;
using static Midterm_Fitness_Center.Club;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    abstract class Member
    {   
        
        //Properties
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double Fees { get; set; }
        public string CheckedInto { get; set; }
        public string HomeClub { get; set; }

        //abstract method will be defined by child classes
        public abstract void CheckIn(Club club, List<Member> members);

        //Removed add member parameters to allow method to loop
        virtual public void AddMember(List<Club> clubList, List<Member> members)
        {
            char keepAdding = 'y';
            while (keepAdding == 'y')
            {   //Use property "lastName" or declare new string?
                FirstName = GetUserInput("Enter new member's First Name: ");
                LastName = GetUserInput("Enter new member's Last Name: ");
                //add a validation to check for no input/valid input
                DisplayClubs(clubList);

            }//AddMember generates ID then method ends.
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"\n\nMember ID: {Id}\t\tName: {LastName}, {FirstName}\tFees: {Fees}");
        }


    }
}
