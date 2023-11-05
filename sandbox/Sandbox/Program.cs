using System;
using System.Threading;

int time = 5;
Console.Write("Countdown ... 5");
Thread.Sleep(1000);
for (int number = time-1; number >= 0; number--)
{
    Console.Write($"\b{number}");
    Thread.Sleep(1000);
}
Console.WriteLine("\nNice!");