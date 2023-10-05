public class Journal
{
public List<Entry> Entries { get; set; }
public string Owner { get; set; }

public void WriteNew(Prompts prompts)
{
    Entry entry = new()
    {
        Date = DateTime.Now.ToString("MM-dd-yy"),
        Prompt = prompts.GetPrompt(),
    };
    Console.WriteLine($"{entry.Prompt}");
    entry.Response = Console.ReadLine();
    
    Entries.Add(entry);
}

public void DisplayEntries()
{
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

    internal void WriteNew()
    {
        throw new NotImplementedException();
    }
}