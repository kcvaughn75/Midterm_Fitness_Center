using System;
using System.Collections.Generic;
using System.Text;
using static Midterm_Fitness_Center.Club;

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

        //abstract method will be defined by child classes
        public abstract void CheckIn(Club club);

        //Removed add member parameters to allow method to loop
        virtual public void AddMember(List<string> clubList)
        {
            char keepAdding = 'y';
            while (keepAdding == 'y')
            {   //Use property "lastName" or declare new string?
                string newMemFirstName = GetUserInput("Enter new member's First Name: ");
                string newMemLastName = GetUserInput("Enter new member's Last Name: ");

                DisplayClubs(clubList);

                string singleOrMulti = GetUserInput("Membership options: Single Club or Multi Club access? Enter: [single] or [multi]");

                if (singleOrMulti == "single")
                {
                    DisplayClubs(clubList);

                    string homeClub = GetUserInput("Enter Home Club location: ");

                    GenerateID();
                }
                if (singleOrMulti == "multi")
                {
                    DisplayClubs(clubList);

                    string homeClub = GetUserInput("Enter Home Club location: ");

                    GenerateID();
                }

                Console.WriteLine("Would you like to add another new member? [y/n]");
                keepAdding = char.Parse(Console.ReadLine().ToLower());

                while (keepAdding != 'y' && keepAdding != 'n')
                {                                                                                 //calling it main menu?
                    Console.WriteLine("Invalid entry. Please enter [y] to add another new member. Enter [n] to return to Main Menu");
                    keepAdding = char.Parse(Console.ReadLine().ToLower());
                }
            }//AddMember generates ID then method ends.
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().ToLower();
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"\n\nMember ID: {Id}\t\tName: {LastName}, {FirstName}\tFees: {Fees}");
        }
    }
}
