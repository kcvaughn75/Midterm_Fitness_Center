using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class Bill
    {
        public static void GenerateBill(List<Member> scMemberList, List<Member> mcMemberList)
        {
            Member currentMember = DisplayMember.FindMember(scMemberList, mcMemberList);

            if (currentMember.MonthlyFees == 20)//single club mem
            {
                Console.WriteLine($"{currentMember}'s Balance: \nMonthly Fee: ${currentMember.MonthlyFees}.00 \nAdditional Fees: $0 \nTotal Due: $20.00");
            }
            else if (currentMember.MonthlyFees == 25)//single club mem w/ diff club checkin fee
            {
                Console.WriteLine($"{currentMember}'s Balance: \nMonthly Fee: ${currentMember.MonthlyFees}.00 \nAdditional Fees: $5 \nTotal Due: $25.00");
            }
            else if (currentMember.MonthlyFees == 30)//Multiclub mem
            {
                Console.WriteLine($"{currentMember}'s Balance: \nMonthly Fee: ${currentMember.MonthlyFees}.00 \nAdditional Fees: $0 \nTotal Due: $30.00");
            }
            else if (currentMember.MonthlyFees == 70)//single club mem w/ massage fee
            {
                Console.WriteLine($"{currentMember}'s Balance: \nMonthly Fee: ${currentMember.MonthlyFees}.00 \nAdditional Fees: $50 \nTotal Due: $70.00");
            }
            else if (currentMember.MonthlyFees == 75)//single club mem w/ diff club checkin fee and massage fee
            {
                Console.WriteLine($"{currentMember}'s Balance: \nMonthly Fee: ${currentMember.MonthlyFees}.00 \nAdditional Fees: $55 \nTotal Due: $75.00");
            }
            else if (currentMember.MonthlyFees == 80)//multi club mem w/ massage fee
            {
                Console.WriteLine($"{currentMember}'s Balance: \nMonthly Fee: ${currentMember.MonthlyFees}.00 \nAdditional Fees: $50 \nTotal due: $80.00");
            }
            else
            {
                Console.WriteLine($"{currentMember}'s Balance: ${currentMember.MonthlyFees}.00");
            }

        }
    }
}
