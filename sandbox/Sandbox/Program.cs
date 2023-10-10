using System;
using System.Diagnostics.Contracts;
using System.Transactions;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Testing");
//         string Date = DateTime.Now.ToString("MM-dd-yy");
//         Console.WriteLine($"{Date}");

//     }
// }


// // The shortcut for class creation is prop followed by tabs



// Private stuff can only be used or called within the class. It is unaccessable from the outside.

// public class Account
// {
//     private List<int> _transactions = new();

//     public void Deposit(int amount)
//     {
//         _transactions.Add(amount);
//     }
// }

// public class Account
// {
//     public List<int> _transactions = new();

//     public void Deposit(int amount)
//     {
//         _transactions.Add(amount);
//     }
// }

// public class Account
// {
//     public int _balance = 0;

//     public void Deposit(int amount)
//     {
//         _balance += amount;
//     }
// }



// public class Person
// {
//     private string _title;
//     private string _firstName;
//     private string _lastName;

//     public string GetInformalSignature()
//     {
//         return "Thanks, " + _firstName;
//     }
//     public string GetFormalSignature()
//     {
//         return "Sincerely, " + GetFullName();
//     }

//     private string GetFullName()
//     {
//         return _title + " " + _firstName + " " + _lastName;
//     }

//     }


Student s5402199 = new()
{
    FirstName = "John",
    LastName = "Lopez",
    Major = "Computer Engineering"
};

public class Item //Class for holding Rotmg items
{
    public string itemName { get; set; }
    public string type { get; set; }
    public string tier { get; set; }   
    public string slot { get; set; }
    public List<int> coordinates { get; set; } //Could be changed to coordinate color pairs starting with the top left spot in the slot

}