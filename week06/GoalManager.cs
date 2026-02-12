using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.\n");
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int before = _goals[index].GetPoints();
            _goals[index].RecordEvent();
            _score += before;
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        List<string> lines = new List<string>();
        lines.Add($"Score|{_score}");

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(filename, lines);
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
            return;

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            if (parts[0] == "Score")
            {
                _score = int.Parse(parts[1]);
            }
            else if (parts[0] == "SimpleGoal")
            {
                SimpleGoal g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                _goals.Add(g);
            }
            else if (parts[0] == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                ChecklistGoal g = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[4])
                );
                _goals.Add(g);
            }
        }
    }
}
