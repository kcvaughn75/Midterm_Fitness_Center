using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class Club
    {
        //properties
        public string Name { get; set; }
        public string Address { get; set; }

        //Default constructor
        public Club()
        {

        }

        //overloaded constructor
        public Club(string name, string address)
        {
            Name = name;
            Address = address; 
        }

        //Display Club method

        public void DisplayClubs()
        {
            Console.WriteLine($"Club Name:{ Name}");
            Console.WriteLine($"Club Address: {Address}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
        }

    }
}
