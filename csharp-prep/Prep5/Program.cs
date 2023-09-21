using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string username = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);
        DisplayResult(username, squaredNumber);

    }
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName(){
        Console.Write("What is your username? ");
        string username = Console.ReadLine();
        return username;
    }
    static int PromptUserNumber(){
        Console.Write("What is your favorite number? ");
        string numberString = Console.ReadLine();
        int number = int.Parse(numberString);
        return number;
    }
    static int SquareNumber(int number){
        int squaredNumber = number * number;
        return squaredNumber;
    }
    static void DisplayResult(string username, int squaredNumber){
        Console.WriteLine($"Username: {username}");
        Console.WriteLine($"Squared Number: {squaredNumber}");
    }
}