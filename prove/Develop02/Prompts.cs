public class Prompts
{
public List<string> AllPrompts { get; set; }

public void AddPrompt()
{
    Console.WriteLine("What is the prompt that you would like to add to the list of possible prompts? ");
    string newPropmt = Console.ReadLine();
    AllPrompts.Add(newPropmt);
    Console.WriteLine("Your prompt has been added!");
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
    Console.WriteLine("Here is a list of the existing prompts: ");
    ViewPrompts();
    Console.Write("Enter the number of the prompt you would like to remove or enter 0 if you would no longer like to remove a prompt: ");
    string toBeRemovedStr = Console.ReadLine();
    promptRemoveNumber = int.Parse(toBeRemovedStr);
    //Make sure they entered a valid number
    if (promptRemoveNumber < -1 || promptRemoveNumber > AllPrompts.Count-1)
    {
        Console.WriteLine("That was not a valid prompt number, try again.");
    }
    }
    while (promptRemoveNumber < -1 || promptRemoveNumber > AllPrompts.Count-1);
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
    foreach(string prompt in AllPrompts)
    {
        int count = 1;
        Console.WriteLine($"Prompt {count}: {prompt}");
        count ++; 
    }
}

}