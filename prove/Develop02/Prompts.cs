using System.IO.Enumeration;

public class Prompts
{
public List<string> AllPrompts { get; set; }
public int DefaultPrompts { get; set; } //This value indicates if the prompts being used are the default or custom
public Prompts()
{
    AllPrompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    DefaultPrompts = 1; //Set to one because initial prompts are default
}

public void SavePrompts(Journal activeJournal)
{
    string fileName = null;
    if (activeJournal.LoadedJournal == 1)
    {
        Console.Write("Would you like to save the prompts at the journal location? (y/n) ");
        string saveAtLoc = Console.ReadLine();
        if(saveAtLoc == "y")
        {
            fileName = $"{activeJournal.JournalFile}";
        }
        else
        {
            Console.Write("What would you like to name your prompts file? ");
            fileName = Console.ReadLine();
        }
    }
    else
    {
        Console.Write("What would you like to name your prompts file? ");
        fileName = Console.ReadLine();
    }
    if(fileName == "null"){Console.WriteLine("An error has occured, please try again.");}//This is theoretically impossible but so are lots of things that happen
    else
    {
        string fullFileName;
        string textToAdd = "Prompts";
        string extension = ".txt";
        int lastIndex = fileName.LastIndexOf('.');
        if (lastIndex == -1)
        {
            // No extension found, append the text at the end
            fullFileName = fileName + textToAdd + extension;
        }
        else
        {
            // Add the text before the extension
            string filenameWithoutExtension = fileName.Substring(0, lastIndex);
            fullFileName =  filenameWithoutExtension + textToAdd + extension;
        }
        
        using (StreamWriter outputFile = new(fullFileName))
        {
            foreach(string prompt in AllPrompts)
            {
            outputFile.WriteLine($"{prompt}");
            }
        }
    }

}
public void LoadPrompts()
{
    string fileName = "null";
    int fileFound = 0;
    while(fileFound == 0)
    {
        Console.Write("Enter the filename of your prompts, if your prompts were saved with a journal enter the journal name with the word prompts at the end. (examplePrompts.txt) ");
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
    string[] lines = System.IO.File.ReadAllLines(fileName);
    List<string> newPrompts = new();
    foreach (string line in lines)
    {
        newPrompts.Add(line);
    }
    AllPrompts = newPrompts;
    DefaultPrompts = 0;
}
public void AddPrompt()
{

    Console.WriteLine("What is the prompt that you would like to add to the list of possible prompts? ");
    string newPrompt = Console.ReadLine();
    AllPrompts.Add(newPrompt);
    Console.WriteLine("Your prompt has been added!\n");
    DefaultPrompts = 0; //Set to zero because the default has been changed
}
public void RemovePrompt()
{
    //Prevent them from removing all the prompts by checking length of AllPrompts first
    if (AllPrompts.Count == 1)
    {
        Console.WriteLine("Sorry, but that's your last prompt. Add another prompt first to be able to remove this one.");
    }
    //Have them select a prompt to remove. If the selection is valid, remove the undesired prompt.
    else{
    int promptRemoveNumber;
    do{
    ViewPrompts();
    Console.Write("\nEnter the number of the prompt you would like to remove or enter 0 if you would no longer like to remove a prompt: ");
    string toBeRemovedStr = Console.ReadLine();
    promptRemoveNumber = int.Parse(toBeRemovedStr);
    //Make sure they entered a valid number
    if (promptRemoveNumber < -1 || promptRemoveNumber > AllPrompts.Count)
    {
        Console.WriteLine("That was not a valid prompt number, try again.");
    }
    }
    while (promptRemoveNumber < -1 || promptRemoveNumber > AllPrompts.Count);
    if (promptRemoveNumber != 0)//If they enter 0 this should be skipped and nothing happens
    {
    AllPrompts.RemoveAt(promptRemoveNumber-1);
    }
    }
    DefaultPrompts = 0;//Set to zero because the default has been changed
}
public string GetPrompt()
{
    Random randomGenerator = new();
    int promptNumber = randomGenerator.Next(0,AllPrompts.Count);
    string randomPrompt = AllPrompts[promptNumber];
    return randomPrompt;
}
public void ViewPrompts()
{
    int count = 1;
    Console.WriteLine("Here is a list of the existing prompts: ");
    foreach(string prompt in AllPrompts)
    {
        Console.WriteLine($"Prompt {count}: {prompt}");
        count ++; 
    }
    Console.WriteLine();
}

}