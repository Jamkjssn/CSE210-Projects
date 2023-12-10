using System;
using System.Xml.Serialization;

class Program
{
    static public int _breathingSeconds { get; set; }
    static public int _reflectingSeconds { get; set; }
    static public int _listingSeconds { get; set; }
    public Program()
    {
        _breathingSeconds = 0;
        _reflectingSeconds = 0;
        _listingSeconds = 0;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Mindfullness Program!");
        bool done = false;
        while (!done)
        {
            int userchoice = Menu();
            Console.Clear();
            if (userchoice == 1) //Breathing
            {
                Breathing breathing = new("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                _breathingSeconds += breathing.GetDuration();
            }
            else if (userchoice == 2) //Reflecting
            {

                Reflecting reflecting = new("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                _reflectingSeconds += reflecting.GetDuration();
            }
            else if (userchoice == 3) //Listing
            {
                Listing listing = new("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                _listingSeconds += listing.GetDuration();
            }
            else if (userchoice == 4)
            {
                Console.Clear();
                Console.WriteLine($"You have completed {_breathingSeconds} seconds of the Breathing activity");
                Console.WriteLine($"You have completed {_reflectingSeconds} seconds of the Reflecting activity");
                Console.WriteLine($"You have completed {_listingSeconds} seconds of the Listing activity");
                Console.WriteLine("Press Enter to return to the menu");
                while (Console.ReadKey().Key != ConsoleKey.Enter){}
                Console.Clear();
            }
            else if (userchoice == 5) //Quit
            {
                done = true;
                Console.WriteLine("Goodbye!");
            }
            else //Error
            {
                Console.WriteLine("You done messed up A-Aaron");
            }
        }
    }
    static int Menu()
    {
        while(true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. View Progress ");
            Console.WriteLine("  5. Quit ");
            Console.Write("Select a choice from the menu: ");
            try
            {
                string choice = Console.ReadLine();
                int choiceInt = int.Parse(choice);
                while(choiceInt > 5 || choiceInt < 0)
                {
                    Console.WriteLine("Please enter a number between 1 and 5 ");
                    choice = Console.ReadLine();
                    choiceInt = int.Parse(choice);
                }
                return int.Parse(choice);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Please enter your choice as a number.\n");
            }
        }
    }
}