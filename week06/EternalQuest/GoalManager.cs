using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine("\n========== Eternal Quest ==========");
            Console.WriteLine($"Current Score: {_score}");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record an event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nCurrent Score: {_score}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("\n========== Goal List ==========");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        DisplayPlayerInfo();
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n========== Create a New Goal ==========");
        Console.Write("What type of goal would you like to create?\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\nEnter choice (1-3): ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (type)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter target number of times to complete: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completing: ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record events for.");
            return;
        }

        ListGoalNames();
        Console.Write("\nSelect which goal you have accomplished (enter number): ");
        
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
        {
            int pointsEarned = _goals[choice - 1].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine());

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    
                    if (parts.Length > 0)
                    {
                        switch (parts[0])
                        {
                            case "SimpleGoal":
                                if (parts.Length == 5)
                                {
                                    SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                                    _goals.Add(goal);
                                }
                                break;
                            case "EternalGoal":
                                if (parts.Length == 4)
                                {
                                    EternalGoal goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                                    _goals.Add(goal);
                                }
                                break;
                            case "ChecklistGoal":
                                if (parts.Length == 7)
                                {
                                    ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), 
                                                                            int.Parse(parts[4]), int.Parse(parts[5]));
                                    _goals.Add(goal);
                                }
                                break;
                        }
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
