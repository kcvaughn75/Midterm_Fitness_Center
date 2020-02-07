using System;
using System.Collections.Generic;
using System.Text;
using static Midterm_Fitness_Center.DisplayMember;

namespace Midterm_Fitness_Center
{
    class RemoveMember
    {
        public static void RmvMember(List<Member> memberList, int userIndex)
        {
            int memberToDelete;
            // Find member to remove
            memberToDelete = SearchMember(memberList);
            if (memberToDelete == -1)
            {
                Console.WriteLine("Could not remove member.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                // VALIDATION NEEDED HERE
                Console.WriteLine($"\n\nAre you sure you want to remove {memberList[memberToDelete].FirstName} {memberList[memberToDelete].LastName} from the system? [y/n]");
                string deleteUser = Console.ReadLine();    // Other options?
                if (deleteUser == "y")
                {
                    memberList.RemoveAt(memberToDelete);
                    Console.WriteLine("User removed from system.\n\n");
                }
                else
                {
                    Console.WriteLine("Remove user cancelled.\n");
                }

            }
        }
    }
}
