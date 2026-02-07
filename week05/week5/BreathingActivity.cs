using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through deep breaths.")
    {
    }

    public void Run()
    {
        StartActivity();
        for (int i = 0; i < 3; i++) // repetir 3 ciclos
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
        }
        EndActivity();
    }
}
