class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Eternal Quest!");
        Console.WriteLine("\nHave you already created a profile?(y/n) "); //Figure out if they have a profile already
        string profile = Console.ReadLine().ToLower();
        Console.Clear();

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
        Console.Clear();
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
            else if (menuchoice == 3) //Manage Goals
            {
                // Goal Management Menu:
                //      1. Complete/Report Progress on a goal
                            // Display Goals
                            // Ask them to select which goal they'd like to report their progress on
                //      2. Edit a goal
                //      3. Delete a goal
                bool managementMenu = true;
                while (managementMenu)
                {
                    int managementMenuChoice = GoalManagementMenu();
                    Console.Clear();

                    if (managementMenuChoice == 1) //  Report progress / Complete
                    {
                        activeprofile.ReportProgress();
                    }
                    else if(managementMenuChoice == 2) // Edit a Goal
                    {
                        activeprofile.EditGoal();
                    }
                    else if (managementMenuChoice == 3) // Delete a Goal
                    {
                        activeprofile.RemoveGoal();
                    }
                    else if (managementMenuChoice == 4) // Exit
                    {
                        managementMenu = false;
                        Console.WriteLine("Returning to main menu");
                    }
                    else // Error
                    {
                        Console.WriteLine("You done messed up A-Aaron");
                    }
                }

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
                        Console.Clear();
                        Console.WriteLine("Still under development");
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                    else if (helpMenuChoice == 2) // Streak Savers
                    {
                        // Explain Streak Savers program
                        Console.Clear();
                        Console.WriteLine("Still under development");
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                    else if (helpMenuChoice == 3) // Report a Problem
                    {
                        // Give Contact info
                        Console.Clear();
                        Console.WriteLine("Still under development");
                        Thread.Sleep(1500);
                        Console.Clear();
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
                if (activeprofile.GetAutosave())
                {
                    activeprofile.SaveProfile();
                }
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
            Console.WriteLine("3. Manage Goals");
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
    public static int GoalManagementMenu()
    {
        //Give Menu options and ask the user for what they want to do, Return number representing user choice
        while (true)
        {
            Console.WriteLine("\t\tGoal Management");
            Console.WriteLine("1. Report completion / progress on a goal");
            Console.WriteLine("2. Edit Goal");
            Console.WriteLine("3. Delete a goal");
            Console.WriteLine("4. Quit");
            int intchoice = SetInt("\t\t What would you like to do? ", 4, 1);
            return intchoice;
        }
    }
    public static void GoalCreation(Profile activeprofile)
    {
        //All code for creating a goal

        //First ask them if they want to give the goal a name
        Console.Clear();
        Console.WriteLine("Would you like to give this goal a name? (yes/no) ");
        string isGoalNamed = Console.ReadLine().ToLower();
        string goalName;
        if (isGoalNamed == "yes")
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
            Console.Clear();
            Console.WriteLine("Your new goal has successfully been set! ");
        }
        else if (goalnumber == 2) // Eternal Goal
        {
            EternalGoal goal = new(goalName);
            goal.Setgoal(description, importance, difficulty);
            Console.WriteLine("How often should this goal be completed?");
            string timetable = Console.ReadLine();
            goal.SetTimetable(timetable);
            activeprofile.AddGoalSet(goal);
            Console.Clear();
            Console.WriteLine("Your Eternal Goal has successfully been created");
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
        Console.WriteLine("Returning to the menu");
        Thread.Sleep(1500);
        Console.Clear();
    }
    public static double Setdouble(string doubleName)
    {
        bool doubleSet = false;
        double doubleValue = 0;
        while (!doubleSet)
        {
            Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("Make sure to enter a value between 1 and 10");
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Make sure to only enter a number from 1-10");
            }
        }
        Console.Clear();
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