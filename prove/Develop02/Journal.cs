public class Journal
{
public List<Entry> Entries { get; set; }
public string Owner { get; set; }

public Journal()
{
    Entries = new List<Entry>();
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
    
}
public void Load()
{

}

}