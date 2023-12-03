using System;
using System.Threading;

// int time = 5;
// Console.Write("Countdown ... 5");
// Thread.Sleep(1000);
// for (int number = time-1; number >= 0; number--)
// {
//     Console.Write($"\b{number}");
//     Thread.Sleep(10);
// }
// Console.WriteLine("\nNice!");


// int _totalParts = 3;

// for (int i = 0; i <= _totalParts-1; i++)
// {
//     Console.Write("[]");
// }
// Console.WriteLine("\t ratio?");

// Student student = new();

// List<string> strings = new();

// strings.Add("testing stuff");

// student.GetType1(strings);

// student.Testing();

// string[] textstuff = { "It is working" };
// File.WriteAllLines("TestingFile.txt", textstuff);

Console.WriteLine("enter name");
string filename = Console.ReadLine();

string path = $"{filename}.txt";

// This text is added only once to the file.
if (File.Exists(path))
{
    // Create a file to write to.
    Console.WriteLine("interesting");
}

// // This text is always added, making the file longer over time
// // if it is not deleted.
// string appendText = "This is extra text" + Environment.NewLine;
// File.AppendAllText(path, appendText);

// // Open the file to read from.
// string[] readText = File.ReadAllLines(path);
// foreach (string s in readText)
// {
//     Console.WriteLine(s);
// }