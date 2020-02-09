using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Midterm_Fitness_Center
{
    class Methods
    {
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static bool UserSelection(string message, string option1_true, string option2_false)
        {
            string select = GetUserInput(message).ToLower();

            while (select != option1_true && select != option2_false)
            {
                return UserSelection(message, option1_true, option2_false);
            }

            if (select == option1_true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string SingleOrMultiSelection()
        {

            bool singleOrMulti = UserSelection("Membership options: Single Club or Multi Club access? Enter: (s/m)", "s", "m");
            
            if (singleOrMulti)
            {
                return "single";
            }
            else
            {

                return "multi";
            }

        }

        public static int UserChoice(string msg, string errorMsg, int limit)
        {
            int userOption;

            // check if input is a valid integer
            if (int.TryParse(GetUserInput(msg), out userOption))
            {
                // check if integer input is valid
                if ((userOption <= 0) || (userOption > limit))
                {
                    Console.WriteLine(errorMsg);
                    return UserChoice(msg, errorMsg, limit);
                }
                return userOption;
            }
            else
            {
                // if option is NOT an integer
                Console.WriteLine(errorMsg);
                return UserChoice(msg, errorMsg, limit);
            }

        }

        //public static void RmvMember(List<Member> scMemberList, List<Member> mcMemberList)
        //{
        //    // Uses FindMember. Deletes user info (with user confirmation) if Member is found.  If passed a null because
        //    // a member was NOT found, inform user.  Removing a member also updates its respective listing on the member storage text file.
        //    try
        //    {
        //        int idFound = DisplayMember.FindMember(scMemberList, mcMemberList).Id;    // get ID of member found
        //        bool isMultiClub = false;
        //        // Find ID on the specific member list. Find out if Member is a Single or Multi Club member.
        //        foreach (Member person in scMemberList)
        //        {
        //            if (person.Id == scMemberList[idFound].Id)  // Try to match ID on Single Club member list
        //            {
        //                isMultiClub = false;
        //                break;
        //            }
        //            else
        //            {
        //                isMultiClub = true;                     // Member belongs to Multi Club member list
        //                break;
        //            }
        //        }
        //        if (isMultiClub)
        //        {
        //            if (UserSelection($"\n\nAre you sure you want to remove {mcMemberList[idFound].FirstName} {mcMemberList[idFound].LastName} from the system? [y/n]", "y", "n"))
        //            {
        //                // Confirms, deletes member and updates the Multi Club member list file.
        //                mcMemberList.Remove(mcMemberList[idFound]);
        //                StreamWriter writer = new StreamWriter("../../../MultiMembers.txt");
        //                foreach (Member person in mcMemberList)
        //                {
        //                    writer.WriteLine(person);
        //                }
        //                writer.Close();
        //                Console.WriteLine("Member has been removed from the system");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Member remove option cancelled");
        //            }
        //        }
        //        else
        //        {
        //            // Confirms, deletes member and updates the Single Member list file.
        //            if (UserSelection($"\n\nAre you sure you want to remove {mcMemberList[idFound].FirstName} {mcMemberList[idFound].LastName} from the system? [y/n]", "y", "n"))
        //            {
        //                mcMemberList.Remove(scMemberList[idFound]);
        //                StreamWriter writer = new StreamWriter("../../../SingleMembers.txt");
        //                foreach (Member person in scMemberList)
        //                {
        //                    writer.WriteLine(person);
        //                }
        //                writer.Close();

        //                Console.WriteLine("Member has been removed from the system");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Member remove option cancelled");
        //            }

        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Member does not exist. Delete operation failed.");
        //    }
        //}

    }
}
