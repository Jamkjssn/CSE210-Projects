using System;
using System.Runtime;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest!");
        //Figure out if they have a profile already
        Console.WriteLine("Have you already created a profile?(y/n) ");
        string profile = Console.ReadLine();

        Profile activeprofile = new("null"); // Creating this here but it will be replaced in either case.

        if (profile == "y")
        //If they have one call Load() to bring it in
        {
            activeprofile = ProfileLoader();
        }

        else
        //If not then use the constructor of Profile and make one
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
            //Call Menu() to get to the main menu, this will return an int corresponding to their choice
            int menuchoice = MainMenu();
            //Options:        
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

            }
            else if (menuchoice == 4) //View Profile
            {

            }
            else if (menuchoice == 5) //Help
            {

            }
            else if (menuchoice == 6) //Settings
            {

            }
            else if (menuchoice == 7) //Quit
            {
                //Add Goodbye message
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
        return -1;
    }
    public static int HelpMenu()
    {
        //Give Menu options and ask the user for what they want to do, Return number representing user choice
        return -1;
    }
    public static int SettingsMenu()
    {
        //Give Menu options and ask the user for what they want to do, Return number representing user choice
        return -1;
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