public class Entry
{
public string Date { get; set; }
public string Prompt { get; set; }
public string Response { get; set; }

public void DisplayEntry()
{
    Console.WriteLine($"{Date} - Prompt: {Prompt}\n{Response}\n");
}
    
}