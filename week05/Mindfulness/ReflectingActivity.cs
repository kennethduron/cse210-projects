using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you overcame a challenge.",
        "Think of a time you helped someone.",
        "Think of a time you felt proud of yourself."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful?",
        "What did you learn about yourself?",
        "How did you feel afterward?",
        "What made this time different?"
    };

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on moments of strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("\nReflect on the following questions:");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine($"\n{question}");
            ShowSpinner(5);
        }
    }
}
