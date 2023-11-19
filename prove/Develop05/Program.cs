using System;
using System.Runtime;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest!");
        Console.WriteLine("Have you already created a profile?(y/n) "); //Figure out if they have a profile already
        string profile = Console.ReadLine();

        Profile activeprofile = new("null"); // Creating this here but it will be replaced in either case.

        if (profile == "y") //If they have one call Load() to bring it in
        {
            activeprofile = ProfileLoader();
        }
        else //If not then use the constructor of Profile and make one
        {
            Console.WriteLine("Choose a Username to use for your profile. Pick something that you'll remember: ");
            string username = Console.ReadLine();
            Console.WriteLine($"Are you sure that you'd like to use \"{username}\" as your username?\n(y/n)");
            string confirmation = Console.ReadLine();
            if (confirmation == "y")
            {
                Profile profile1 = new(username);
                activeprofile = profile1;
            }
        }
        bool done = false;
        while (!done)
        {
            int menuchoice = MainMenu(); //Call Menu() to get to the main menu, this will return an int corresponding to their choice
            if (menuchoice == 1) //Create Goal
            {
                GoalCreation();
            }
            else if (menuchoice == 2) //View Goals
            {
                activeprofile.DisplayGoals();
            }
            else if (menuchoice == 3) //Report Goal Progress
            {
                //Figure this out later
            }
            else if (menuchoice == 4) //View Profile
            {
                //Add desplay profile function in Profile
                activeprofile.DisplayProfile();
            }
            else if (menuchoice == 5) //Help
            {
                bool helpMenu = true;
                while (helpMenu)
                {
                    int helpMenuChoice = HelpMenu();

                    if (helpMenuChoice == 1) // How to set goals
                    {
                        //Teach about SMART goals
                    }
                    else if (helpMenuChoice == 2) // Streak Savers
                    {
                        // Explain Streak Savers program
                    }
                    else if (helpMenuChoice == 3) // Report a Problem
                    {
                        // Give Contact info
                    }
                    else if (helpMenuChoice == 4) // Quit
                    {
                        helpMenu = false;
                        Console.WriteLine("Returning to main menu");
                    }
                    else // Error
                    {
                        Console.WriteLine("You done messed up A-Aaron");
                    }
                }
            }
            else if (menuchoice == 6) //Settings
            {
                //Redirect to settings menu
                bool settingsMenu = true;
                while (settingsMenu) //Menu loop
                {
                    int settignsMenuChoice = SettingsMenu();

                    if (settignsMenuChoice == 1) // Edit Username
                    {
                        Console.WriteLine("Are you sure you want to change your username?(y/n) ");
                        string confirmation = Console.ReadLine();
                        if (confirmation == "y")
                        {
                            Console.WriteLine("Enter your new username: ");
                            string newusername = Console.ReadLine();
                            activeprofile.ChangeUsername(newusername);
                            Console.WriteLine($"Your username has been changed to \"{newusername}\"");
                        }
                    }
                    else if (settignsMenuChoice == 2) // Toggle Autosave
                    {
                        if (activeprofile.GetAutosave())
                        {
                            Console.WriteLine("Currently autosave is active, would you like to disable it?(y/n) ");
                            string disactivateAutosave = Console.ReadLine();
                            if (disactivateAutosave == "y")
                            {
                                activeprofile.ToggleAutosave();
                                Console.WriteLine("Autosave is now disabled");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Currently autosave is disabled, would you like to activate it?(y/n) ");
                            string disactivateAutosave = Console.ReadLine();
                            if (disactivateAutosave == "y")
                            {
                                activeprofile.ToggleAutosave();
                                Console.WriteLine("Autosave is now activated");
                            }
                        }
                    }
                    else if (settignsMenuChoice == 3) // Save Profile and Goals
                    {
                        Save();
                        Console.WriteLine("Your current profile and goals have been saved");
                    }
                    else if (settignsMenuChoice == 4) // Quit
                    {
                        settingsMenu = false;
                        Console.WriteLine("Returning to main menu");
                    }
                    else // Error
                    {
                        Console.WriteLine("You done messed up A-Aaron");
                    }
                }
            }
            else if (menuchoice == 7) //Quit
            {
                Console.WriteLine("Goodbye, Dont forget your goals!!!");
                Save();
                done = true;
            }
            else //Invalid input
            {
                Console.WriteLine("You done messed up A-Aaron");
            }
        }
    }
    public static int MainMenu()
    {
        //Give Menu options and ask the user for what they want to do, Return number representing user choice
        while (true)
        {

            Console.WriteLine("\t\tMain Menu");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. View Goals");
            Console.WriteLine("3. Report Goal Progress");
            Console.WriteLine("4. View Profile");
            Console.WriteLine("5. Help");
            Console.WriteLine("6. Settings");
            Console.WriteLine("7. Quit");
            Console.WriteLine("\t\t What would you like to do? ");
            string userchoice = Console.ReadLine();
            int intchoice = -1;
            try
            {
                intchoice = int.Parse(userchoice);
            }
            catch
            {
                Console.WriteLine("Make sure to enter your choice as a number");
            }

            if (intchoice > 0 || intchoice < 8)
            {
                return intchoice;
            }
            else
            {
                if (intchoice != -1)
                {
                    Console.WriteLine("Enter your choice as a number 1-7");
                }
            }
        }
    }
    public static int HelpMenu()
    {
        //Give Menu options and ask the user for what they want to do, Return number representing user choice
        while (true)
        {

            Console.WriteLine("\t\tHelp");
            Console.WriteLine("1. How to set goals");
            Console.WriteLine("2. Streak Savers");
            Console.WriteLine("3. Report a problem");
            Console.WriteLine("4. Quit");
            Console.WriteLine("\t\t Select a choice from the menu? ");
            string userchoice = Console.ReadLine();
            int intchoice = -1;
            try
            {
                intchoice = int.Parse(userchoice);
            }
            catch
            {
                Console.WriteLine("Make sure to enter your choice as a number");
            }

            if (intchoice > 0 || intchoice < 5)
            {
                return intchoice;
            }
            else
            {
                if (intchoice != -1)
                {
                    Console.WriteLine("Enter your choice as a number 1-7");
                }
            }
        }
    }
    public static int SettingsMenu()
    {
        //Give Menu options and ask the user for what they want to do, Return number representing user choice
        while (true)
        {
            Console.WriteLine("\t\tHelp");
            Console.WriteLine("1. Edit Username");
            Console.WriteLine("2. Toggle Autosave");
            Console.WriteLine("3. Save Profile and Goals");
            Console.WriteLine("4. Quit");
            Console.WriteLine("\t\t Select a choice from the menu? ");
            string userchoice = Console.ReadLine();
            int intchoice = -1;
            try
            {
                intchoice = int.Parse(userchoice);
            }
            catch
            {
                Console.WriteLine("Make sure to enter your choice as a number");
            }

            if (intchoice > 0 || intchoice < 5)
            {
                return intchoice;
            }
            else
            {
                if (intchoice != -1)
                {
                    Console.WriteLine("Enter your choice as a number 1-7");
                }
            }
        }
    }
    public static void GoalCreation()
    {
        //All code for creating a goal
    }
    public static Profile ProfileLoader()
    {
        //Getting their profile
        Profile redundant = new("null");
        return redundant;
    }
    public static void Save()
    {
        //Save profile and goals to a file indicated by their username
    }
    public static void Load()
    {
        //Use a username to load profile and goals
    }
}