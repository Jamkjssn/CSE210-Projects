using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

public class Reference
{
private string _scriptureBook { get; set; }
private int _chapter { get; set; }
private List<int> _verses { get; set; }
private string _fullReference { get; set; }
public void SetReference(string reference)
{
    _fullReference = reference;
    _verses = new List<int>();
    string[] splitbook = reference.Split(' ');
    int referenceLength = splitbook.Length; //This is important for later but has to be done now
    if (splitbook[0].Length < 4) // Check if the beginning two are actually both referencing the book
    {
        splitbook[0] = $"{splitbook[0]} {splitbook[1]}"; // Fixing the chaos that brings.
        splitbook[1] = splitbook[2];// 1 Kings 3:12-13, 16, 18
        referenceLength--;
        if (referenceLength > 2)
        {
            int partindex = 0;
            foreach (string part in splitbook)
            {
                if (partindex > 2)
                {
                    splitbook[1] = $"{splitbook[1]}{part}";//At this point the reference will be formatted as (1 Kings 3:12-13,16,18)
                }
                partindex++;
            }
        }
    }
    string book = splitbook[0];
    _scriptureBook = book;

    string[] splitvalues = splitbook[1].Split(':');
    string chapter = splitvalues[0];
    int chapterint = int.Parse(chapter);
    _chapter = chapterint;
    
    try //If its a single verse put it in the Verse property
    {
        int verse = int.Parse(splitvalues[1]);
        _verses.Add(verse);
    }
    catch // Otherwise it goes in the List.
    {
        if (referenceLength == 2) //This is for if its already just (beginningverse - endverse)
        {
            SetVerses(splitvalues[1]);
        }
        else
        {
            string[] verses1 = splitvalues[1].Split(',');
            foreach (string verseString in verses1)
            {
                try // Same as first try catch essentially. But this time everything goes into Verses List.
                {
                    int verse = int.Parse(verseString);
                    _verses.Add(verse);
                }
                catch
                {
                    SetVerses(verseString);
                }
            }
        }
    }
}
public string GetBook()
{
    return _scriptureBook;
}
public int GetChapter()
{
    return _chapter;
}
public List<int> GetVerses()
{
    return _verses;
}
private void SetVerses(string verseRange)
//Takes the verses in format (versenumber - versenumber) and adds those and all verses between them to the Verses list.
{
    string[] verses = verseRange.Split('-');
    List<int> versesList = new();
    foreach (string verse in verses)
    {
        int verseInt = int.Parse(verse);
        versesList.Add(verseInt);
    }
    for (int i = versesList[0]; i <= versesList[1]; i++) // This will count up starting at the first number until it gets to the second number.
    {
        _verses.Add(i);
    }
}

public void PrintReference()
{
    Console.WriteLine($"{_fullReference}");
}
}