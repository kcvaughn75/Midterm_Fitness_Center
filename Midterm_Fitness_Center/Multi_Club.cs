using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class Multi_Club : Member
    {
        public int Points { get; set; }

        public Multi_Club() { }

        public Multi_Club(string firstName, string lastName, double fees, int points)
        {
            FirstName = firstName;
            LastName = lastName;
            Fees = fees; 
            Points = points;
        }

        public override void CheckIn(Club club)
        {
            
            //set isCheckedIn to true
            //send to points method
            throw new NotImplementedException();
        }
    }
}
