public class Resume
{
    public List<Job> Jobs = new();
    
    public string Name { get; set; }   


    public void Display(){
        Console.WriteLine($"Name:\n\t{Name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in Jobs){
            Console.Write("\t");
            job.Display();
        }
    }

}