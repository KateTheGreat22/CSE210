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
        Console.WriteLine("Welcome to the Eternal Quest Program!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals have been created yet.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals have been created yet.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string choice = Console.ReadLine().ToLower();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1" || choice == "simple")
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int target = int.Parse(Console.ReadLine());
            
            SimpleGoal goal = new SimpleGoal(name, description, points, target);
            _goals.Add(goal);
            Console.WriteLine("Simple goal added successfully!");
        }
        else if (choice == "2" || choice == "eternal")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
            Console.WriteLine("Eternal goal added successfully!");
        }
        else if (choice == "3" || choice == "checklist")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
            Console.WriteLine("Checklist goal added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal type. Please enter 1, 2, 3, or the goal type name.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available to record.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex];
            
            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("This goal is already complete!");
                return;
            }

            selectedGoal.RecordEvent();

            int pointsEarned = selectedGoal.GetPoints();
            
            if (selectedGoal is ChecklistGoal checklistGoal)
            {
                pointsEarned = checklistGoal.GetPointsForEvent();
                if (checklistGoal.IsComplete() && checklistGoal.GetPointsForEvent() > selectedGoal.GetPoints())
                {
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points! (Including a bonus of {checklistGoal.GetBonus()} points)");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                }
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }

            _score += pointsEarned;
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
    
        if (!filename.EndsWith(".txt"))
        {
            filename = $"{filename}.txt";
        }

        using (StreamWriter outputFile = new StreamWriter(filename))
        {

            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        

        if (!filename.EndsWith(".txt"))
        {
            filename = $"{filename}.txt";
        }

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }


            _goals.Clear();


            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                
                if (parts.Length < 2)
                {
                    Console.WriteLine($"Skipping invalid line: {line}");
                    continue;
                }

                string goalType = parts[0];
                string[] data = parts[1].Split('|');

                try
                {
                    if (goalType == "SimpleGoal")
                    {
                        string name = data[0];
                        string description = data[1];
                        int points = int.Parse(data[2]);
                        int target = int.Parse(data[3]);
                        int amountCompleted = int.Parse(data[4]);
                        SimpleGoal goal = new SimpleGoal(name, description, points, target, amountCompleted);
                        _goals.Add(goal);
                    }
                    else if (goalType == "EternalGoal")
                    {
                        string name = data[0];
                        string description = data[1];
                        int points = int.Parse(data[2]);
                        EternalGoal goal = new EternalGoal(name, description, points);
                        _goals.Add(goal);
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        string name = data[0];
                        string description = data[1];
                        int points = int.Parse(data[2]);
                        int bonus = int.Parse(data[3]);
                        int target = int.Parse(data[4]);
                        int amountCompleted = int.Parse(data[5]);
                        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                        _goals.Add(goal);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading goal: {ex.Message}");
                }
            }

            Console.WriteLine("Goals loaded successfully!");
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine($"Loaded {_goals.Count} goal(s).");
            
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}