using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think about a time you overcame a challenge:",
        "Reflect on a moment that made you happy recently:",
        "Consider something you learned this week:"
    };

    public ReflectingActivity() : base("Reflecting Activity", "This activity will guide you to reflect on meaningful experiences.")
    {
    }

    public void Run()
    {
        StartActivity();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("Press Enter when you have finished reflecting.");
        Console.ReadLine();
        EndActivity();
    }
}
