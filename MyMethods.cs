using System;


namespace GC_CS_Lab13_RockPaperScissors
{
    class MyMethods
    {


        public static int UserChoice(string msg, string errorMsg, int limit)
        {
            int userOption;

            // check if input is a valid integer
            if (int.TryParse(GetUserInput(msg), out userOption))
            {
                // check if integer input is valid
                if ((userOption <= 0) || (userOption > limit))
                {
                    SetOutputColor();
                    Console.WriteLine(errorMsg);
                    return UserChoice(msg, errorMsg, limit);
                }
                return userOption;
            }
            else
            {
                // if option is NOT an integer
                SetOutputColor();
                Console.WriteLine(errorMsg);
                return UserChoice(msg, errorMsg, limit);
            }
        }

        public static string YN_UserChoice(string msg, string errorMsg)
        {
            // Validates yes or no input using "y" or "n"
            SetOutputColor();
            string userOption = GetUserInput(msg).Trim().ToLower();
            // check if "Y" input is valid
            if ((userOption != "y") && (userOption != "n"))
            {
                SetOutputColor();
                Console.WriteLine(errorMsg);
                return YN_UserChoice(msg, errorMsg);
            }
            return userOption;
        }

        public static string TryAgain(string message)
        {
            // Method for running program again.  Passes back to do while loop in main.
            string userChoice = GetUserInput(message).Trim().ToLower();
            while ((userChoice != "y") && (userChoice != "n"))
            {
                userChoice = GetUserInput("Please enter 'y' or 'n'.  [y/n]").Trim().ToLower();
            }
            return userChoice;
        }
        public static string GetUserInput(string message)
        {
            // Allows for program prompt and user input (string)
            SetOutputColor();
            Console.WriteLine(message);
            SetInputColor();
            return Console.ReadLine();
        }

        public static void ShowTitle(string title)
        {
            // This method simply shows the title
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{title} \n\n");
        }

        public static void SetInputColor()
        {
            // Method for setting colors for user inputted text
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void SetOutputColor()
        {
            // Method for setting colors for default display text
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
