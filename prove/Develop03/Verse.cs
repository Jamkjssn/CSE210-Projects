using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
public class Verse
{
    public string theVerse { get; set; }
    public List<string> parsedVerse { get; set; }
    public List<Word> wordList { get; set; }
    public List<Word> shownList { get; set; }
    public Verse()
    {
        parsedVerse = new();
        wordList = new();
        shownList = new();
    }
    public void ParseVerse()
    {
        string[] verse = theVerse.Split(" ");
        foreach (string word in verse)
        {
            parsedVerse.Add(word);
        }        
    }
    public void GetWordList()
    {
        foreach(string newWord in parsedVerse)
        {
            wordList.Add(new Word(newWord));
        }
        shownList = wordList;
    }
    public void GetVerse(Reference reference)
    {
        string scriptureFile = "C:\\CSE 210\\CSE210-Projects\\prove\\Develop03\\lds-scriptures-2020.12.08\\csv\\lds-scriptures1.csv";
        string targetBook = reference.ScriptureBook;
        int targetChapter = reference.Chapter;
        List<int> targetVerses = reference.Verses;
        List<bool> found = new List<bool>();
        foreach (int i in targetVerses)
        {
            found.Add(false);
        }
        bool allFound = false;

        try
        {
            using (var reader = new StreamReader(scriptureFile))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                while (csv.Read())
                {
                    var book = csv.GetField<string>(5).Trim();
                    var chapter = csv.GetField<int>(14);
                    var verse = csv.GetField<int>(15);

                    if (book == targetBook && chapter == targetChapter)
                    {
                        int i = 0;
                        foreach (int verseInt in targetVerses)
                        {
                            if (verse == verseInt)
                            {
                                // Match found
                                found[i] = true;
                                theVerse = $"{theVerse}\n" + csv.GetField<string>(16);
                            }
                            i++;
                        }
                    }

                    if (found.Count > 0 && found.Last())
                    {
                        break; // End the loop, the final verse has been found
                    }
                }
            }

            allFound = found.All(value => value);

            if (!allFound)
            {
                Console.WriteLine("One or more of the verses you selected were not found.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }
}


// 1 Nephi 12:
// 