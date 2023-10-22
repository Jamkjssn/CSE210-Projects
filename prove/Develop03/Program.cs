using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to scripture memorization!!!");
        Console.WriteLine("What scripture would you like to memorize today?");

        // string newreference = Console.ReadLine();
        string newreference = "1 Nephi 1:1";
        Reference reference = new();
        reference.SetReference(newreference);

        Console.Write($"{reference.ScriptureBook} Chapter {reference.Chapter} Verse(s):");
        foreach (int verse in reference.Verses)
        {
            Console.Write($"{verse} ");
        }
        Console.WriteLine(' ');
        Verse verse1 = new();
        verse1.GetVerse(reference);
        verse1.ParseVerse();
        verse1.GetWordList();
        foreach(Word word in verse1.shownList)
        {
            Console.Write($"{word.shown} ");
        }
        bool memorized = false;
        bool end = false;
        while (!end)
        {
        while (!memorized)
        {
            Console.WriteLine("Press Enter to hide another word. Otherwise enter \"exit\" to quit or \"back\" to reveal a hidden word.");
            string answer = Console.ReadLine();
            if(answer == "")
            {
                memorized = ToggleHiddenWord(verse1, true);
            }
            else if (answer.ToLower() == "back")
            {
                bool wordshown = ToggleHiddenWord(verse1, false);
                if (wordshown)
                {
                    Console.WriteLine("All words are already shown. Try entering something different");
                }
            }
            else if (answer.ToLower() == "exit")
            {
                break;
            }
        }
        if (memorized)
        {
            Console.WriteLine("Congratulations on memorizing the scripture! Would you like to try a new scripture? (yes/no) ");
            string answer = Console.ReadLine();
            if(answer != "no")
            {
                end = true;
            }
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
            if (word.isHidden != hide)
            {
                word.ToggleHidden();
                return false;
            }
            if (count > 200)
            {
                foreach(Word theword in verse1.shownList)
                {
                    if (word.isHidden != hide)
                    {
                        word.ToggleHidden();
                        wordChanged = true;
                        return false;
                    }
                }
                return true;
            }
            count++;
        }
        return false;
    }
}