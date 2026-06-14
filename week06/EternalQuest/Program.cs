using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: This program exceeds the core requirements by adding a
        // level and rank system based on the user's score. When recording an
        // event, the program also celebrates earned points and announces level
        // ups so the goals feel more like a quest.
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
