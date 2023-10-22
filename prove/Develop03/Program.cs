using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to scripture memorization!!!");// Initial Welcome message
        Console.WriteLine("What scripture would you like to memorize today?");

        string newreference = Console.ReadLine();
        // string newreference = "1 Nephi 1:1";//Just for testing
        Reference reference = new();
        reference.SetReference(newreference);

        Console.Write($"{reference.ScriptureBook} Chapter {reference.Chapter} Verse(s):");//Display verse selected, Might delete this later
        foreach (int verse in reference.Verses)
        {
            Console.Write($"{verse} ");
        }
        Console.WriteLine(' ');
        Verse verse1 = new();//All of the setup for the verse
        verse1.GetVerse(reference);
        verse1.ParseVerse();
        verse1.GetWordList();
        bool memorized = false;//Initialize bools for while loops
        bool end = false;
        while (!end){
        while (!memorized){

            PrintVerse(verse1, reference);
            Console.WriteLine("Press Enter to hide another word. Otherwise enter \"exit\" to quit or \"back\" to reveal a hidden word.");
            string continueanswer = Console.ReadLine();
            if(continueanswer == "")
            {
                memorized = ToggleHiddenWord(verse1, true);//This will hide one random non-hidden word
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
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
        if(answer != "no")
        {
            end = true;
        }
        }
    }
    public static bool ToggleHiddenWord(Verse verse1, bool hide)
    {
        int listlen = verse1.shownList.Count;
        bool wordChanged = false;
        int count = 0;
        while (!wordChanged)
        {
            Random random = new();
            int wordToHide = random.Next(0, listlen);
            Word word = verse1.shownList[wordToHide];
            if (word.isHidden != hide)//we want stuff thats hidden when we're showing and shown when we're hiding.
            {
                word.ToggleHidden();
                return false;
            }
            if (count > 200)//If it didn't find it in 200 tries its time to brute force.
            {
                foreach(Word theword in verse1.shownList)
                {
                    if (word.isHidden != hide)
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
        Console.WriteLine($"{reference.fullReference}");
        foreach (Word word in verse.shownList)
        {
            Console.Write($"{word.shown} ");
        }
        Console.WriteLine("");
    }
}