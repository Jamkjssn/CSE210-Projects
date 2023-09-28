public class Resume
{
    public List<Job> Jobs = new();
    
    public string Name { get; set; }   


    public void Display()
    {
        Console.WriteLine($"Name:\n\t{Name}\nJobs:");
        foreach (Job j in Jobs)
        {
            Console.Write("\t");
            j.Display();
        }
    }
}