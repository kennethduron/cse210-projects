using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "List things you are grateful for:",
        "List positive experiences you had today:",
        "List people who have helped you recently:"
    };

    public ListingActivity() : base("Listing Activity", "This activity will prompt you to list items to focus your mind.")
    {
    }

    public void Run()
    {
        StartActivity();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("Type as many as you can and press Enter when done:");
        Console.ReadLine();
        EndActivity();
    }
}
