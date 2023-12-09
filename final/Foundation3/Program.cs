using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Foundation 3: Event Planning\n\n");

        Address address1 = new("510 S Center Street", "Rexburg"); // Create random addresses
        Address address2 = new("15 N 4th S", "Rexburg");
        Address address3 = new("2193 N Geneva Rd", "Provo");

        Lecture lecture = new //Lecture
        (
            "How to code",
            "An in depth class about how to write your own code!",
            "12/11/23",
            "2PM-3PM",
            address1,
            "George",
            200
        );
        Reception reception = new //Reception
        (
            "Gregs Reception",
            "You're invited to our reception! Food will be provided.",
            "12/8/23",
            "2AM",
            address2,
            "jamkjssn@gmail.com"
        );
        OutdoorGathering outdoorGathering = new //Outdoor Gathering
        (
            "John's BarbeQue",
            "Free briscut for all that come!!!",
            "12/25",
            "7PM",
            address3,
            "Clear Skies"
        );
        
        List<Event> events = new() //Add them all to a list to iterate through
        {
            lecture,
            reception,
            outdoorGathering
        };
        
        int index = 1;
        foreach(Event _event in events)
        {
            Console.WriteLine($"\t\tEvent #{index}");
            Console.WriteLine("\nShort Details:\n");
            Console.WriteLine(_event.ShortDetails());
            Console.WriteLine("\nStandard Details:\n");
            Console.WriteLine(_event.StandardDetails());
            Console.WriteLine("\nFull Details:\n");
            Console.WriteLine(_event.FullDetails());
            Console.WriteLine();
            index++;
        }

    }
}