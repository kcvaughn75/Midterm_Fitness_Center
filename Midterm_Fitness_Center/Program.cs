using System;
using System.Collections.Generic;
using System.IO;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Club> ClubList = new List<Club>();

            StreamReader reader = new StreamReader("../../../../Clubs.txt");
            string line = reader.ReadLine();

            while(line != null)
            {
                string[] clubArray = line.Split('|');
                Club club = new Club(clubArray[0], clubArray[1]);
                ClubList.Add(club);
                line = reader.ReadLine();
            }




            List<Member> MemberListSingle = new List<Member>();

            StreamReader readerMemberSingle = new StreamReader("../../../../SingleMembers.txt");
            string lineMemberSingle = readerMemberSingle.ReadLine();

            while (lineMemberSingle != null)
            {
                string[] memberArraySingle = lineMemberSingle.Split('|');
                Member newMemberSingle = new SingleClubClass(int.Parse(memberArraySingle[0]), memberArraySingle[1], memberArraySingle[2],
                    memberArraySingle[3], double.Parse(memberArraySingle[4]));
                MemberListSingle.Add(newMemberSingle);
                lineMemberSingle = reader.ReadLine();

            }
            readerMemberSingle.Close();

            List<Member> MemberListMulti = new List<Member>();

            StreamReader readerMemberMulti = new StreamReader("../../../../MultiMembers.txt");
            string lineMemberMulti = readerMemberMulti.ReadLine();

            while (lineMemberMulti != null)
            {
                string[] memberArrayMulti = lineMemberMulti.Split('|');
                Member newMemberMulti = new Multi_Club(int.Parse(memberArrayMulti[0]), memberArrayMulti[1], memberArrayMulti[2], 
                    double.Parse(memberArrayMulti[3]), int.Parse(memberArrayMulti[4]));
                MemberListMulti.Add(newMemberMulti);
                lineMemberMulti = reader.ReadLine();
            }
            readerMemberMulti.Close();

            int input = SelectFromLoginMenu(ClubList, MemberListSingle, MemberListMulti);
        }

       //method

       
       

        //method to generate a random number to set ID number
        public static int GenerateID()
        {
            Random random = new Random();
            int id = random.Next();
            return id;
        }

        public static string DisplayLoginMenuAndGetSelection()
        {
            
            return GetUserInput($"Please select from the following options: \n1. Check-in a member \n2. Register a new member " +
                $"\n3. Cancel a membership \n4. Display member information \n5. Generate a bill \n6. Logout");
        }
        public static int SelectFromLoginMenu( List<Club> clubList, List<Member> membersSingle, List<Member> membersMulti)
        {
            try
            {
                int select = int.Parse(DisplayLoginMenuAndGetSelection());

                if(select == 1)
                {

                    //send to checkIn method
                    //call to dispMember and returns a specific member
                    //if(Member.HomeClub != "")
                    //{
                    //    //send to singleClub.CheckIN
                    //}
                    //else
                    //{
                    //    //send to multiClub.checkIn
                    //}
                    //OR
                    //try
                    //{
                    //    int pointCheck = Member.Points;
                    //    //send to multi checkin

                    //}
                    //catch
                    //{
                    //    //send to single
                    //}



                }
                else if (select == 2)
                {
                    //send to Add a member
                    //call to SingleOrMultiSelection
                    
                    if(SingleOrMultiSelection() == "single")
                    {
                        Member newSingle = new SingleClubClass();
                        newSingle.AddMember(clubList, membersSingle);
                        membersSingle.Add(newSingle);
                    }
                    else
                    {
                        Member newMulti = new Multi_Club();
                        newMulti.AddMember(clubList, membersMulti);
                        membersMulti.Add(newMulti);
                    }


                    //Console.WriteLine("Would you like to add another new member? [y/n]");
                    //keepAdding = char.Parse(Console.ReadLine().ToLower());

                    //while (keepAdding != 'y' && keepAdding != 'n')
                    //{                                                                                 //calling it main menu?
                    //    Console.WriteLine("Invalid entry. Please enter [y] to add another new member. Enter [n] to return to Main Menu");
                    //    keepAdding = char.Parse(Console.ReadLine().ToLower());
                    //}

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
                    
                }

                return select;//need to check to see if we need this index 
            }
            catch
            {
                return SelectFromLoginMenu( clubList, membersSingle, membersMulti);
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

        public static Member DispMember(List<Member> memberList)
        {
            int userIndex = SearchMember(memberList);
            if (userIndex != -1)  // if name or ID was found, display user's info
            {
                memberList[userIndex].DisplayInfo();
                return memberList[userIndex];
            }
            return memberList[userIndex];//work on validating this
        }

        //public static void DispMember(List<Member> memberList)
        //{
        //    int userIndex = SearchMember(memberList);
        //    if (userIndex != -1)  // if name or ID was found, display user's info
        //    {
        //        memberList[userIndex].DisplayInfo();    
        //    }
        //}

        public static int SearchMember(List<Member> memberList)
        {
            int foundIt = -1;

            Console.WriteLine("Would you like to look for a member by ID number or name?");
            Console.WriteLine($"1)\tID number");
            Console.WriteLine($"2)\tName?");
            int userSelection = int.Parse(Console.ReadLine());  // <---- validation needed here!!!
            if (userSelection == 1)     // ID search selected by user;
            {
                Console.WriteLine("Please enter the ID number: ");
                int idSearch = int.Parse(Console.ReadLine()); // <---- validation needed here!!!
                for (int i = 0; i < memberList.Count; i++)  // Search systen for ID entered
                {
                    if (idSearch == memberList[i].Id)
                    {
                        foundIt = i;    // Store index for later
                        break;
                    }
                }
                if (foundIt == -1)  // ID not found
                {
                    Console.WriteLine($"{userSelection} could not be found in the system.");
                }
            }
            else   // name search selected by user;
            {
                Console.WriteLine("Please enter member's first name");
                string fName = Console.ReadLine();
                Console.WriteLine("Please enter member's last name");
                string lName = Console.ReadLine();

                for (int i = 0; i < memberList.Count; i++)  // Search systen for name entered
                {
                    if (lName.Trim().ToLower() == memberList[i].LastName.Trim().ToLower())
                    {
                        if (fName.Trim().ToLower() == memberList[i].FirstName.Trim().ToLower())
                        {
                            foundIt = i;    // Store index for later
                            break;
                        }
                    }
                }
                if (foundIt == -1)  // name not found
                {
                    Console.WriteLine($"{userSelection} could not be found in the system.");
                }
            }
            return foundIt;
        }
    }


}

    

