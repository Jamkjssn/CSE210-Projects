using System;
using System.Reflection.Metadata;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        //Initialize the default empty Journal
        Journal journal1 = new();
        Journal activeJournal = journal1;
        activeJournal.Owner = "Unknown";

        //Initialize prompts
        Prompts prompts = new();

        //Initialize Journal Writing Loop
        int end = 0;
        while (end == 0){

        //Send User to the Menu and get their  choice
        int userChoice = Menu();

        if (userChoice == 1)//Write
        {
            if (activeJournal.Owner == "Unknown")
            {
                Console.WriteLine("Before writing, who's Journal is this? ");
                activeJournal.Owner = Console.ReadLine();
                Console.WriteLine("Thanks! Heres your prompt now: ");
            }
            activeJournal.WriteNew(prompts);
        }

        else if (userChoice == 2)//Display
        {
            activeJournal.DisplayEntries();
        }

        else if (userChoice == 3)//Load
        {
            //Change activeJournal to be the journal found at the file destination
        }

        else if (userChoice == 4)//Save
        {
            // Maybe add a functionality for a saved journal to have an owner
        }

        else if (userChoice == 5)//Prompt Settings
        {
            //Begin Loop for Prompt Settings Menu
            int endPrompt = 0;
            while (endPrompt == 0){
                //This will be where they can edit prompts
            int userChoicePrompt = PromptMenu();

            if (userChoicePrompt == 1)//AddPrompt
            {
                prompts.AddPrompt();
            }

            else if (userChoicePrompt == 2)//Remove Prompt
            {
                prompts.RemovePrompt();
            }

            else if (userChoicePrompt == 3)//View Prompts
            {
                prompts.ViewPrompts();
            }

            else if (userChoicePrompt == 4)//Load Propmts
            {
                
            }

            else if (userChoicePrompt == 5)//Save Prompts
            {
                                
            }

            else if (userChoicePrompt == 6)//Return to main menu
            {
                Console.WriteLine("Returning to main menu");
                endPrompt = 1;
            }

            else //Error
            {
                Console.WriteLine("An error has occured, please restart the program.");
                endPrompt = 1;
            }
            }
        }

        else if (userChoice == 6)//Quit
        {
            Console.WriteLine("Goodbye!");
            end = 1;
        }

        else //Error
        {
            Console.WriteLine("An error has occured, please restart the program.");
            end = 1;
        }
        }
    }

    static int Menu()
    {
        int userChoice;
        do
        {
            Console.WriteLine("\t---| Menu |---\n1. Write \n2. Display \n3. Load \n4. Save \n5. Prompt Settings \n6. Quit\n");
            Console.Write("What would you like to do? ");
            string userChoiceStr = Console.ReadLine();
            userChoice = int.Parse(userChoiceStr);

            if (userChoice <= 0 || userChoice > 6)
            {
                Console.WriteLine("The number you entered is invalid, Please try again.");
            }
        }
        while (userChoice <= 0 || userChoice > 6);

        return userChoice;
    }

    static int PromptMenu()
    {
        int userChoicePrompt;
        do
        {
            Console.WriteLine("\t---| Menu |---\n1. Add Prompt \n2. Remove Prompt \n3. View Prompts \n4. Load Prompts \n5. Save Prompts \n6. Return to main menu\n");
            Console.Write("What would you like to do? ");
            string userChoiceStr = Console.ReadLine();
            userChoicePrompt = int.Parse(userChoiceStr);
            Console.WriteLine("");

            if (userChoicePrompt <= 0 || userChoicePrompt > 6)
            {
                Console.WriteLine("The number you entered is invalid, Please try again.");
            }
        }
        while (userChoicePrompt <= 0 || userChoicePrompt > 6);

        return userChoicePrompt;
    }
}