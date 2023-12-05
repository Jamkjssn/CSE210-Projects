using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest!");
        Console.WriteLine("Have you already created a profile?(y/n) "); //Figure out if they have a profile already
        string profile = Console.ReadLine().ToLower();

        Profile activeprofile = new("null"); // Creating this here but it will be replaced in either case.

        if (profile == "y") //If they have one get the username and attempt to load it
        {
            Console.WriteLine("What was the username of that profile? ");
            string username = Console.ReadLine();
            bool profileFound = false;
            while (!profileFound)
            {
            profileFound = activeprofile.CreateSavedProfile(username);
            if (!profileFound) // This runs if the username doens't bring up a file. 
            {
                Console.WriteLine("Sorry but that username is not associated with a known save file.");
                Console.WriteLine("Would you like to try again?(y/n) ");
                string retry = Console.ReadLine().ToLower();
                if (retry == "y")
                {
                    Console.WriteLine("What is the Username of your profile? ");
                    username = Console.ReadLine();
                }
                else
                {
                    profile = "n"; // By changing this the profile construction will run.
                    profileFound = true;
                }
            }
            }
        }
        if (profile != "y")//If not then use the constructor of Profile and make one
        {
            bool profileCreated = false;
            while (!profileCreated) //Run through this until they settle on a username and the profile is created. 
            {
            Console.WriteLine("Choose a Username to use for your profile. Pick something that you'll remember: ");
            string username = Console.ReadLine();
            Console.WriteLine($"Are you sure that you'd like to use \"{username}\" as your username?\n(y/n)");
            string confirmation = Console.ReadLine();
            if (confirmation == "y")
            {
                Profile profile1 = new(username);
                activeprofile = profile1;
                profileCreated = true;
            }
            }
        }
        bool done = false;
        while (!done)
        {
            int menuchoice = MainMenu(); //Call Menu() to get to the main menu, this will return an int corresponding to their choice
            Console.Clear();
            if (menuchoice == 1) //Create Goal
            {
                GoalCreation(activeprofile);
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
                    Console.Clear();

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
                    Console.Clear();

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
                        activeprofile.SaveProfile();
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
                activeprofile.SaveProfile();
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
            int intchoice = SetInt("\t\t What would you like to do? ", 7, 1);
            return intchoice;
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
            int intchoice = SetInt("\t\t What would you like to do? ", 4, 1);
            return intchoice;
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
            int intchoice = SetInt("\t\t What would you like to do? ", 4, 1);
            return intchoice;
        }
    }
    public static void GoalCreation(Profile activeprofile)
    {
        //All code for creating a goal

        //First ask them if they want to give the goal a name
        Console.WriteLine("Would you like to give this goal a name?(y/n) ");
        string isGoalNamed = Console.ReadLine().ToLower();
        string goalName;
        if (isGoalNamed == "y")
        {
            Console.WriteLine("\nWhat would you like the name of the goal to be? ");
            goalName = Console.ReadLine();
        }
        else
        {
            goalName = "empty";
        }
        //Then have them set the goal.
        Console.WriteLine("\nWhat is your Goal? ");
        string description = Console.ReadLine();

        //Now get importance and difficulty
        double importance = Setdouble("important");
        double difficulty = Setdouble("difficult");
        Console.Clear();

        //Once set they'll pick which type of goal it will be. 
            Console.WriteLine("Goals are seperated into three main types:");
            Console.WriteLine("\t1. Simple Goals: Goals that are done only one time and then are complete");
            Console.WriteLine("\t2. Eternal Goals: Goals that are never complete and must be done repetatively");
            Console.WriteLine("\t3. Checklist Goals: Goals that are split into multiple different parts or pieces to be completed");
        int goalnumber = SetInt("Enter the number corresponding to the type of Goal you'd like to create? ", 3, 1);

        //Then based on that ask them all necessary questions for that goal type. 
        if (goalnumber == 1)// Simple Goal
        {
            SimpleGoal goal = new(goalName);
            goal.Setgoal(description, importance, difficulty);
            activeprofile.AddGoalSet(goal);
            Console.WriteLine("Your new goal has successfully been set! ");
            Console.Clear();
        }
        else if (goalnumber == 2) // Eternal Goal
        {

        }
        else if (goalnumber == 3) // Checklist goal
        {
            ChecklistGoal goal = new(goalName, "checklistgoal");
            goal.Setgoal(description, importance, difficulty);
            Console.Clear();
            int parts = SetInt("How many parts will your checklist goal be split into? ", -1, 1);
            goal.SetParts(parts);
            activeprofile.AddGoalSet(goal);
            Console.WriteLine($"Your checklist goal of {parts} parts has successfully been created!");
            Console.WriteLine("Press \"Enter\" to return to the Menu");
            while (Console.ReadKey().Key != ConsoleKey.Enter){}
            Console.Clear();
        }
    }
    public static double Setdouble(string doubleName)
    {
        bool doubleSet = false;
        double doubleValue = 0;
        while (!doubleSet)
        {
            Console.WriteLine($"\nOn a scale of 1-10, how {doubleName} is this goal?");
            string stringdouble = Console.ReadLine();
            try
            {
                doubleValue = double.Parse(stringdouble);
                if (doubleValue > 0 && doubleValue < 11)
                {
                    doubleSet = true;
                }
                else
                {
                    Console.WriteLine("Make sure to enter a value between 1 and 10");
                }
            }
            catch
            {
                Console.WriteLine("Make sure to only enter a number from 1-10");
            }
        }
        return doubleValue;
    }
    public static int SetInt(string question, int upperBound = -1, int lowerBound = -1)
    {
        int intToReturn = -1;
        bool validInt = false;
        while (!validInt)
        {
            Console.WriteLine($"{question}");
            string useranswer = Console.ReadLine();
            try
            {
                intToReturn = int.Parse(useranswer);
                if (upperBound == -1 && lowerBound == -1)
                {
                    validInt = true;
                }
                else if (upperBound == -1)
                {
                    if (intToReturn >= lowerBound)
                    {
                        validInt = true;
                    }
                    else
                    {
                        Console.WriteLine($"Make sure you enter a whole number greater than {lowerBound}");
                    }
                }
                else if (lowerBound == -1)
                {
                    if (intToReturn >= upperBound)
                    {
                        validInt = true;
                    }
                    else
                    {
                        Console.WriteLine($"Make sure you enter a whole number less than {upperBound}");
                    }
                }
                else
                {
                    if (intToReturn <= upperBound && intToReturn >= lowerBound)
                    {
                        validInt = true;
                    }
                    else
                    {
                        Console.WriteLine($"Make sure you enter a whole number between {lowerBound} and {upperBound}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Make sure to enter your selection as a number");
            }
        }
        return intToReturn;
    }
}