using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Grade Converter!");
        Console.WriteLine("What was your grade? (0-100) ");
        string gradeString = Console.ReadLine();
        int grade = int.Parse(gradeString);
        string gradeLetter;
        if (-1 < grade && grade < 101) {
            //stuff happens
            if (grade > 89){
                gradeLetter = "A";
            }
            else if (grade > 79){
                gradeLetter = "B";
            }
            else if (grade > 69){
                gradeLetter = "C";
            }
            else{
                gradeLetter = "F";
            }

            if (gradeLetter == "A"){
                Console.WriteLine("Congratulations! You got an A");
            }
            else if (gradeLetter == "F"){
                Console.WriteLine("Sorry but you didnt pass. Better luck next time.");
            }
            else {
                Console.WriteLine($"Your grade in the class was {gradeLetter}");
            }
        }

        else {
            Console.WriteLine("Sorry but that is not a valid grade. Enter a grade 0-100.");
        }
    }
}