public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice != "6")
            {
                Console.WriteLine("Please choose a valid menu option.");
            }

            Console.WriteLine();
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {GetLevel()} - {GetRank()}");
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private string GetRank()
    {
        if (_score >= 5000)
        {
            return "Legend";
        }
        else if (_score >= 3000)
        {
            return "Champion";
        }
        else if (_score >= 1500)
        {
            return "Adventurer";
        }
        else if (_score >= 500)
        {
            return "Apprentice";
        }

        return "Beginner";
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string shortName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(shortName, description, points));
        }
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(shortName, description, points));
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("That goal type was not recognized.");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string checkbox = goal.IsComplete() ? "X" : " ";
            Console.WriteLine($"{i + 1}. [{checkbox}] {goal.GetDetailsString()}");
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = CreateGoalFromString(lines[i]);

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    private Goal CreateGoalFromString(string line)
    {
        string[] typeAndData = line.Split(":");
        string goalType = typeAndData[0];
        string[] parts = typeAndData[1].Split(",");

        string shortName = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);

        if (goalType == "SimpleGoal")
        {
            bool isComplete = bool.Parse(parts[3]);
            return new SimpleGoal(shortName, description, points, isComplete);
        }
        else if (goalType == "EternalGoal")
        {
            return new EternalGoal(shortName, description, points);
        }
        else if (goalType == "ChecklistGoal")
        {
            int bonus = int.Parse(parts[3]);
            int target = int.Parse(parts[4]);
            int amountCompleted = int.Parse(parts[5]);
            return new ChecklistGoal(shortName, description, points, target, bonus, amountCompleted);
        }

        return null;
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record yet.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("That goal number is not valid.");
            return;
        }

        int previousLevel = GetLevel();
        int earnedPoints = _goals[goalIndex].RecordEvent();
        _score += earnedPoints;

        if (earnedPoints == 0)
        {
            Console.WriteLine("This goal is already complete. No additional points were earned.");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");

            if (GetLevel() > previousLevel)
            {
                Console.WriteLine($"Level up! You are now Level {GetLevel()} - {GetRank()}.");
            }
        }

        Console.WriteLine($"You now have {_score} points.");
    }
}
