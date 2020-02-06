using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    abstract class Member
    {   
        //Fields
        private int id;
        private string lastName;
        private string firstName;
        private double fees;

        //Properties
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double Fees { get; set; }

        //abstract method will be defined by child classes
        public abstract void CheckIn(Club club);

        virtual public void AddMember()
        {

        }
        
       

    }
}
