using System;
using System.Collections.Generic;

namespace Midterm_Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ClubName = new List<string>
            {


            };
            List<string> ClubAddress = new List<string>
            {

            };

        }

        public string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public bool UserSelection(string message, string option1_true, string option2_false)
        {
            string select = GetUserInput(message);

            while(select != option1_true && select != option2_false)
            {
                return UserSelection(message, option1_true, option2_false);
            }

            if(select == option1_true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FindUser(List<string> memberList, string name)
        {
            string userFound = "";
            for (int i = 0; i < memberList.Count; i++)
            {
                if(name == memberList[i])//may need to link with actual first or last name attached to member
                {
                    userFound = memberList[i];
                    break;
                }
            }
            return userFound;
        }

        //method to generate a random number to set ID number
        public int GenerateID()
        {
            Random random = new Random();
            int id = random.Next();
            return id;
        }

        public string DisplayLoginMenuAndGetSelection()
        {
            
            return GetUserInput($"Please select from the following options: \n1. Check-in a member \n2. Register a new member " +
                $"\n3. Cancel a membership \n4. Display member information \n5. Generate a bill \n6. Logout");
        }
        public int SelectFromLoginMenu(string selection)
        {
            try
            {
                int select = int.Parse(DisplayLoginMenuAndGetSelection());

                if(select == 1)
                {
                    //send to checkIn method
                }
                else if (select == 2)
                {
                    //send to Add a member
                }
                else if (select == 3)
                {
                    //send to remove a member
                }
                else if (select  == 4)
                {
                    //send to Display member info *DispMember(memberList)
                }
                else if (select == 5)
                {
                    //send to generate a bill
                }
                else if (select == 6)
                {
                    //send to Logout
                }

                return select;//need to check to see if we need this index 
            }
            catch
            {
                return SelectFromLoginMenu(selection);
            }

        }
        //adding points based on if it's a checkIn or referral
        public int AddPoints()
        {
            bool select = UserSelection("Please select one to add: \n1. Check-In points \t2. Referral points", "1", "2");
            
            if(select == true)
            {
                return 5;
            }
            else
            {
                return 10;
            }
        }

    }
}
