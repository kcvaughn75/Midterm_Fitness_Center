using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class DisplayMember
    {
        public static Member DispMember(List<Member> scMemberList, List<Member> mcMemberList)
        {
            int userIndex = FindMember(scMemberList, mcMemberList);
            if (userIndex != -1)  // if name or ID was found, display user's info
            {
                memberList[userIndex].DisplayInfo();
                return memberList[userIndex];
            }
            return memberList[userIndex];//work on validating this
        }

        public static int FindMember(List<Member> scMemberList, List<Member> mcMemberList)
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
                int idSearchidx = IDSearch(idSearch, scMemberList, mcMemberList);
                if (idSearchidx == -1)
                {
                    FindMember(scMemberList, mcMemberList);
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

        public static int IDSearch(int idSearch, List<Member> scMemberList, List<Member> mcMemberList)
        {
            int foundIt = -1;

            for (int i = 0; i < scMemberList.Count; i++)  // Search systen for ID entered
            {
                if (idSearch == scMemberList[i].Id)
                {
                    foundIt = i;    // Store index for later
                    return foundIt;
                }
            }
            if (foundIt == -1)  // ID not found
            {
                for (int i = 0; i < mcMemberList.Count; i++)  // Search systen for ID entered
                {
                    if (idSearch == mcMemberList[i].Id)
                    {
                        foundIt = i;    // Store index for later
                        return foundIt;
                    }
                }
            }
            return foundIt;

        }

        public static int NameSearch(int nameSearch, List<Member> scMemberList, List<Member> mcMemberList)
        {
            return 0;
        }
    }
}
