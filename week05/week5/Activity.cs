using System;
using System.Threading;

public class Activity
{
    private string _activityName;
    private string _description;
    private int _duration; // en segundos

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void SetDuration(int seconds)
    {
        _duration = seconds;
    }

    public string GetActivityName()
    {
        return _activityName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    // Métodos compartidos por todas las actividades
    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_activityName}...\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        ShowSpinner(3); // ejemplo de animación inicial
    }

    public void EndActivity()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You have completed {_duration} seconds of {_activityName}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }
}
