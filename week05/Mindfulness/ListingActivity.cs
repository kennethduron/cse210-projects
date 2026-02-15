using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List people you appreciate:",
        "List your personal strengths:",
        "List things that make you happy:"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect by listing as many responses as you can.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);

        List<string> responses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
        ShowSpinner(3);
    }
}
