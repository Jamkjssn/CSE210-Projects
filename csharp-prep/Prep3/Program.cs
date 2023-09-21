using System;

class Program
{
    static void Main(string[] args)
    {
        bool playing = true;
        while (playing == true){
            Console.WriteLine("Welcome to the number guessing game!");

            //Get magic number
            // Console.Write("What is the magic number? ");
            // string magicNumberString = Console.ReadLine();
            // int magicNumber = int.Parse(magicNumberString);
            Random randomGenerator = new();
            int magicNumber = randomGenerator.Next(1,100);

            //Get initial guess
            Console.Write("What is your first guess? ");
            string guessString = Console.ReadLine();
            int guess = int.Parse(guessString);
            int guesses = 1;
            
            //Begin while loop until guess is correct
            while (guess != magicNumber) {
                if (guess > magicNumber) {
                    Console.WriteLine("Lower");
                }
                else {
                    Console.WriteLine("Higher");
                }

                Console.Write("What is your next guess? ");
                guessString = Console.ReadLine();
                guess = int.Parse(guessString);
                guesses++;
            }
            Console.WriteLine($"Congratulations! The number was {magicNumber}");
            Console.WriteLine($"It took you {guesses} guesses");

            Console.Write("Would you like to play again? (y/n) ");
            string again = Console.ReadLine();
            if (again != "y" && again != "yes"){
                playing = false;
            }
        }
    }
}