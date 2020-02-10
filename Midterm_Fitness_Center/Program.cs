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
            //Calling the login method from login class
            Login.LoginStaff(Login.StaffLogin);

            #region club list import
            List<Club> ClubList = new List<Club>();

            StreamReader reader = new StreamReader("../../../../Clubs.txt");
            string line = reader.ReadLine();

            while (line != null)
            {
                string[] clubArray = line.Split('|');
                Club club = new Club(clubArray[0], clubArray[1]);
                ClubList.Add(club);
                line = reader.ReadLine();
            }
            #endregion

            #region single member list import
            List<Member> MemberListSingle = new List<Member>();

            StreamReader readerMemberSingle = new StreamReader("../../../../SingleMembers.txt");
            string lineMemberSingle = readerMemberSingle.ReadLine();

            while (lineMemberSingle != null)
            {
                string[] memberArraySingle = lineMemberSingle.Split('|');
                Member newMemberSingle = new SingleClubClass(int.Parse(memberArraySingle[0]), memberArraySingle[1], memberArraySingle[2],
                    memberArraySingle[3], double.Parse(memberArraySingle[4]));
                MemberListSingle.Add(newMemberSingle);
                lineMemberSingle = readerMemberSingle.ReadLine();

            }
            readerMemberSingle.Close();
            #endregion
            #region multi member list import
            List<Member> MemberListMulti = new List<Member>();

            StreamReader readerMemberMulti = new StreamReader("../../../../MultiMembers.txt");
            string lineMemberMulti = readerMemberMulti.ReadLine();

            while (lineMemberMulti != null)
            {
                string[] memberArrayMulti = lineMemberMulti.Split('|');
                Member newMemberMulti = new Multi_Club(int.Parse(memberArrayMulti[0]), memberArrayMulti[1], memberArrayMulti[2],
                    double.Parse(memberArrayMulti[3]), int.Parse(memberArrayMulti[4]));
                MemberListMulti.Add(newMemberMulti);
                lineMemberMulti = readerMemberMulti.ReadLine();
            }
            readerMemberMulti.Close();
            #endregion


            bool userContinue = true;
            while (userContinue)
            {

                int input = SelectFromLoginMenu(ClubList, MemberListSingle, MemberListMulti);
                if(input == 6)
                {
                    break;
                }

                userContinue = UserSelection("Would you like to perform another task? (y/n)", "y", "n");
            }

            Console.WriteLine("You have successfully logged out!");
        }

        //method




        //method to generate a random number to set ID number
        public static int GenerateID()
        {
            Random random = new Random();
            int id = random.Next();
            return id;
        }


        //Metod to generate random ID of 4 digits without duplicating from the existing list// We can change the parametere here
        public static int GenerateID(List<int> list)
        {
            int id;
            do
            {

                Random random = new Random();
                id = random.Next(1111, 9999);

            } while (list.Contains(id));

            return id;
        }




        public static string DisplayLoginMenuAndGetSelection()
        {

            return GetUserInput($"Please select from the following options: \n1. Check-in a member \n2. Register a new member " +
                $"\n3. Cancel a membership \n4. Display member information \n5. Generate a bill \n6. Logout");
        }
        public static int SelectFromLoginMenu(List<Club> clubList, List<Member> membersSingle, List<Member> membersMulti)
        {
            try
            {
                int select = int.Parse(DisplayLoginMenuAndGetSelection());

                if (select == 1)
                {

                    //send to checkIn method
                    //call to dispMember and returns a specific member
                    Member currentMember = DisplayMember.FindMember(membersSingle, membersMulti);

                    if (currentMember.HomeClub != "")
                    {
                        //send to singleClub.CheckIN
                   //    SingleClubClass.CheckIn(currentMember.HomeClub, currentMember); //CheckIn will not accept a club as a string or from
                    }//a list of clubs. Changed parameters of Member CheckIn method to accept a string 
                    else
                    {
                        //send to multiClub.checkIn
                 //       Multi_Club.CheckIn(currentMember.HomeClub, currentMember);//same here will only accept a datatype Club
                    }
                 //   OR
                    //try
                    //{
                    //    int pointCheck = currentMember.Points; unable to use points because it's not part of Parent class 
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

                    if (SingleOrMultiSelection() == "single")
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

                }
                else if (select == 3)
                {
                    //send to remove a member
                    RemoveMember.RmvMember(membersSingle, membersMulti);

                }
                else if (select == 4)
                {
                    //send to Display member info *DispMember(memberList)
                   DisplayMember.DispMember(membersSingle, membersMulti);
                }
                else if (select == 5)
                {
                    //send to generate a bill

                }
                return select;//will return the int the user selects. This is important if they select 6 then it logs them out
            }
            catch
            {
                return SelectFromLoginMenu(clubList, membersSingle, membersMulti);
            }

        }
        //adding points based on if it's a checkIn or referral
        public int AddPoints()
        {
            bool select = UserSelection("Please select one to add: \n1. Check-In points \t2. Referral points", "1", "2");

            if (select == true)
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

    

