public class Prompts
{
public List<string> AllPrompts { get; set; }
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
}
public void AddPrompt()
{
    Console.WriteLine("What is the prompt that you would like to add to the list of possible prompts? ");
    string newPrompt = Console.ReadLine();
    AllPrompts.Add(newPrompt);
    Console.WriteLine("Your prompt has been added!\n");
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