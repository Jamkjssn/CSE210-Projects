using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("\nWelcome to scripture memorization!!!");// Initial Welcome message
        Console.WriteLine("What scripture would you like to memorize today?");

        string newreference = Console.ReadLine();
        Console.Clear();
        // string newreference = "1 Nephi 1:1";//Just for testing
        Reference reference = new();
        reference.SetReference(newreference);

        Verse verse1 = new(reference);//All of the setup for the verse
        bool memorized = false;//Initialize bools for while loops
        bool end = false;
        while (!end){
        while (!memorized){

            PrintVerse(verse1, reference);
            Console.WriteLine("\nPress Enter to hide another word. Otherwise enter \"exit\" to quit or \"back\" to reveal a hidden word.");
            string continueanswer = Console.ReadLine();
            Console.Clear();
            if(continueanswer == "")
            {
                memorized = ToggleHiddenWord(verse1, true);//This will hide one random non-hidden word
            }
            else if (continueanswer.ToLower() == "back")
            {
                bool wordshown = ToggleHiddenWord(verse1, false);//This will show one random hidden word
                if (wordshown)
                {
                    Console.WriteLine("All words are already shown. Try entering something different");
                }
            }
            else if (continueanswer.ToLower() == "exit")
            {
                break;
        }
        }

        if (memorized)
        {
            Console.WriteLine("Congratulations on memorizing the scripture! Would you like to try a new scripture? (yes/no) ");
        }
        else
        {
            Console.WriteLine("Would you like to try a new scripture? (yes/no) ");
        }
        string answer = Console.ReadLine();//Since the question is the same, this could be moved out of the if else statements. 
        if(answer.ToLower() == "no")
        {
            end = true;
            Console.WriteLine("Goodbye then!");
            Thread.Sleep(3000);
            Console.Clear();
        }
        }
    }
    public static bool ToggleHiddenWord(Verse verse1, bool hide)
    {
        int listlen = verse1.GetListLen();
        bool wordChanged = false;
        int count = 0;
        while (!wordChanged)
        {
            Random random = new();
            int wordToHide = random.Next(0, listlen);
            Word word = verse1.GetWord(wordToHide);
            if (word.IsWordHidden() != hide)//we want stuff thats hidden when we're showing and shown when we're hiding.
            {
                word.ToggleHidden();
                return false;
            }
            if (count > 200)//If it didn't find it in 200 tries its time to brute force.
            {
                foreach(Word theword in verse1.GetShownList())
                {
                    if (word.IsWordHidden() != hide)
                    {
                        word.ToggleHidden();
                        return false;
                    }
                }
                return true;//Brute force didn't find anything so there's nothing to find.
            }
            count++;
        }
        return false;//This should never trigger, its just so the code doesn't yell at me about not always returning something. 
    }
    public static void PrintVerse(Verse verse, Reference reference)
    {
        reference.PrintReference();
        verse.PrintVerse();
    }
}