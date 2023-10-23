using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
public class Verse
{
    private string _theVerse { get; set; }
    private List<string> _parsedVerse { get; set; }
    private List<Word> _wordList { get; set; }
    private List<Word> _shownList { get; set; }
    public Verse(Reference reference)
    {
        _parsedVerse = new();
        _wordList = new();
        _shownList = new();
        FindVerse(reference);
        ParseVerse();
        SetWordList();
    }
    private void ParseVerse()
    {
        string[] verse = _theVerse.Split(" ");
        foreach (string word in verse)
        {
            _parsedVerse.Add(word);
        }        
    }
    public int GetListLen()
    {
        return _shownList.Count;
    }
    public List<Word> GetShownList()
    {
        return _shownList;
    }
    private void SetWordList()
    {
        foreach(string newWord in _parsedVerse)
        {
            _wordList.Add(new Word(newWord));
        }
        _shownList = _wordList;
    }
    public Word GetWord(int index)
    {
        return _shownList[index];
    }
    public void PrintVerse()
    {
        foreach (Word word in _shownList)
        {
            word.PrintShown();
        }
        Console.WriteLine(" ");
    }
    private void FindVerse(Reference reference)
    {
        string scriptureFile = "C:\\CSE 210\\CSE210-Projects\\prove\\Develop03\\lds-scriptures-2020.12.08\\csv\\lds-scriptures1.csv";
        string targetBook = reference.GetBook();
        int targetChapter = reference.GetChapter();
        List<int> targetVerses = reference.GetVerses();
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
                                _theVerse = $"{_theVerse}\n" + csv.GetField<string>(16);
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