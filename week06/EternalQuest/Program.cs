using System;

// EXCEEDS CORE REQUIREMENTS:
// Added clean menu structure and structured architecture ready for extension.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
