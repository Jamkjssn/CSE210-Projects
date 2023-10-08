using System.IO;
using System.IO.Enumeration;

public class Journal
{
public List<Entry> Entries { get; set; }

public int LoadedJournal { get; set; }
public string JournalFile { get; set; }

public Journal()
{
    Entries = new List<Entry>();
    LoadedJournal = 0; //This will be changed to 1 if they load in a journal
}
public void WriteNew(Prompts prompts)
{
    Entry entry = new()
    {
        Date = DateTime.Now.ToShortDateString(),
        Prompt = prompts.GetPrompt(),
    };
    Console.WriteLine($"{entry.Prompt}");
    entry.Response = Console.ReadLine();
    
    Entries.Add(entry);
}

public void DisplayEntries()
{
    Console.WriteLine("");
    foreach(Entry e in Entries)
    {
        e.DisplayEntry();
    }
}

public void Save()
{
    int newSave = 0;
    string fileName = "null";
    if (LoadedJournal == 1)
    {
        Console.Write("Would you like to save your new entries to the loaded journal file? (y/n) ");
        string loadAnswer = Console.ReadLine();
        if (loadAnswer == "n")
        {
            newSave = 1;
        }
        else
        {
            try
            {
            fileName = JournalFile;
            }
            catch // Error handling if their file was not found
            {
                Console.WriteLine("An error occured and your filename was not found. In the following questions opt to overwrite.");
                newSave = 1;
            }
        }
    }
    if (LoadedJournal == 0 || newSave == 1)
    {
    //In the case that they didn't load the file initially
    Console.Write("What would you like to name your journal file:(Make sure to add .txt to the end) ");
    fileName = Console.ReadLine();

    if (File.Exists(fileName))//If the filename already exists ask if they want to overwrite
    {
        Console.Write("A file by that name already exists. Would you like to overwrite it? (y/n) ");
        string answer = Console.ReadLine();

        if (answer != "y"){
            Console.Write("In that case what would you like to name the file:(Make sure to add .txt to the end) ");
            fileName = Console.ReadLine();
        }
    }
    }
    // Save here
    if(fileName == "null"){Console.WriteLine("An error has occured, please try again.");}//This is theoretically impossible but so are lots of things that happen
    else
    {
        using (StreamWriter outputFile = new(fileName))
        {
            foreach(Entry e in Entries)
            {
            outputFile.WriteLine($"{e.Date}~{e.Prompt}~{e.Response}");
            }
        }
    }
}
public static Journal Load()
{
    string fileName = "null";
    int fileFound = 0;
    while(fileFound == 0)
    {
        Console.Write("Enter the filename of your journal: ");
        fileName = Console.ReadLine();
        if(File.Exists(fileName))
        {
            fileFound = 1;
        }
        else
        {
            Console.Write("The file you entered wasn't found, would you like to try again? (y/n) ");
            string tryagain = Console.ReadLine();
            if(tryagain == "n")
            {
                fileFound = -1;
            }
        }
    }
    // try
    // {
        List<Entry> newentries = new();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~");
            Entry entry = new()
            {
                Date = parts[0],
                Prompt = parts[1],
                Response = parts[2]
            };
            newentries.Add(entry);
        }
        Journal journal = new()
        {
            Entries = newentries,
            LoadedJournal = 1,
            JournalFile = fileName
        };
        return journal;
    // }
    // catch //Will catch anything wrong with reading the file
    // {
    //     Console.WriteLine("Something went wrong, try again.");
    //     //Because it cant return nothing it will return an empty journal
    //     Journal emptyjournal = new();
    //  return emptyjournal;
    // }
}

}