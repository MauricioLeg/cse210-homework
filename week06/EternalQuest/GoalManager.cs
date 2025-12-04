using System.IO;
public class GoalManager
{
    List<Goal> _goals = new List<Goal>();
    List<Goal> _goalsCompleted = new List<Goal>();
    private int _score = 0;

    public GoalManager()
    {
        
    }
    public void Start()
    {
        string answer = "";
        while (answer != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create a New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine("---------------------------------------------------------------------");
                CreateGoal();
                Console.WriteLine("---------------------------------------------------------------------");
            }
            if (answer == "2")
            {
                Console.WriteLine("---------------------------------------------------------------------");
                ListGoalDetails();
                ListGoalNames();
                Console.WriteLine("---------------------------------------------------------------------");
            }
            if (answer == "3")
            {
                Console.WriteLine("---------------------------------------------------------------------");
                SaveGoals();
                Console.WriteLine("---------------------------------------------------------------------");
            }
            if (answer == "4")
            {
                Console.WriteLine("---------------------------------------------------------------------");
                LoadGoals();
                Console.WriteLine("---------------------------------------------------------------------");
            }
            if (answer == "5")
            {
                Console.WriteLine("---------------------------------------------------------------------");
                RecordEvent();
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You score is: {_score}");
        Console.WriteLine();
    }
    public void ListGoalNames()
    {
        int number = 0;                    
        Console.WriteLine("The Goals are:");
        foreach (Goal goal in _goals)
        {
            number ++;
            string goalName = goal.GetName();
            string goalDescription = goal.GetDescription();
            string checkmark = goal.IsComplete() ? "√" : " ";
            if (goal.GetGoalType() == "ChecklistGoal")
            {
                Console.WriteLine($"{number}. [{checkmark}] {goalName} ({goalDescription}) {goal.GetStringRepresentation()}");                                    
            }
            else
            {
            Console.WriteLine($"{number}. [{checkmark}] {goalName} ({goalDescription})");                                
            }                
        }
    }
    public void ListGoalDetails()
    {
        if (_goalsCompleted.Count == 0)
        {
            return;
        }
        else
        {  
            int number = 0;
            Console.WriteLine();
            Console.WriteLine("The Completed Goals are:");
            foreach (Goal goal in _goalsCompleted)
            {
                number ++;
                string goalName = goal.GetName();
                string goalDescription = goal.GetDescription();
                string checkmark = goal.IsComplete() ? "√" : " ";
                if (goal.GetGoalType() == "ChecklistGoal")
                {
                    Console.WriteLine($"{number}. [{checkmark}] {goalName} ({goalDescription}) {goal.GetStringRepresentation()}");
                }
                else
                {
                Console.WriteLine($"{number}. [{checkmark}] {goalName} ({goalDescription})");
                }   
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("What type of goal would you like to create? ");
        string answer = Console.ReadLine();
        if (answer == "1")
        {
            string type = "SimpleGoal";
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            SimpleGoal simpleGoal = new SimpleGoal(type, name, description, points);
            _goals.Add(simpleGoal);
        }
        if (answer == "2")
        {
            string type = "EternalGoal";
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            EternalGoal eternalGoal = new EternalGoal(type, name, description, points);
            _goals.Add(eternalGoal);
        }
        if (answer == "3")
        {
            string type = "ChecklistGoal";
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            ChecklistGoal checklistGoal = new ChecklistGoal(type, name, description, points, target, bonus);
            _goals.Add(checklistGoal);
        }
    }
    public void RecordEvent ()
    {
        ListGoalNames();
        Console.WriteLine("What goal did you accomplished? ");
        string inputChoice = Console.ReadLine();
        if (!int.TryParse(inputChoice, out int choice))
        {
            Console.WriteLine("Invalid input! Please enter a number.");
            return;
        }        
        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine($"Invalid choice! Please select a number between 1 and {_goals.Count}.");
            return;
        }
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals!");
            return;
        }
        Goal selectedGoal = _goals[choice - 1];
        selectedGoal.RecordEvent();
        int points = int.Parse(selectedGoal.GetPoints());
        _score += points;
        if (selectedGoal is ChecklistGoal)
        {
            string[] parts = selectedGoal.GetDetailsString().Split(',');
            int amount = int.Parse(parts[0]);
            int target = int.Parse(parts[1]);
            int bonus = int.Parse(parts[2]);
            if (amount == target)
            {
                _score += bonus;
                Console.WriteLine($"And you earned the bonus of {bonus}!");
            }
        }
        Console.WriteLine($"You have earned {points} points!");
        if (selectedGoal.IsComplete())
        {
            _goalsCompleted.Add(selectedGoal);
            _goals.Remove(selectedGoal);
        }
    }
    public void SaveGoals()
    {
        Console.Write("What will be the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                // format
                // simple: Type:Name, Description, Points, Completed?
                // eternal: Type:Name, Description, Points
                // checklist: Type:Name, Description, Points, Bonus, Target, Current
                // where target is the times it needs to be done to be completed, and current the times it had be done
                string type = goal.GetGoalType();
                string goalName = goal.GetName();
                string goalDescription = goal.GetDescription();
                string goalPoints = goal.GetPoints();
                bool isComplete = goal.IsComplete();

                if (type == "SimpleGoal")
                {
                    outputFile.WriteLine($"{type}, {goalName}, {goalDescription}, {goalPoints}, {isComplete}"); 
                }
                if (type == "EternalGoal")
                {
                    outputFile.WriteLine($"{type}, {goalName}, {goalDescription}, {goalPoints}"); 
                }
                if (type == "ChecklistGoal")
                {
                    ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                    string[] chParts = checklistGoal.GetDetailsString().Split(',');
                    int amount = int.Parse(chParts[0]);
                    int target = int.Parse(chParts[1]);
                    int bonus = int.Parse(chParts[2]);
                    outputFile.WriteLine($"{type}, {goalName}, {goalDescription}, {goalPoints}, {bonus}, {target}, {amount}"); 
                }
            }

            foreach (Goal goal in _goalsCompleted)
            {
                string type = goal.GetGoalType();
                string goalName = goal.GetName();
                string goalDescription = goal.GetDescription();
                string goalPoints = goal.GetPoints();
                bool isComplete = goal.IsComplete();

                if (type == "SimpleGoal")
                {
                    outputFile.WriteLine($"{type}, {goalName}, {goalDescription}, {goalPoints}, {isComplete}"); 
                }
                if (type == "EternalGoal")
                {
                    outputFile.WriteLine($"{type}, {goalName}, {goalDescription}, {goalPoints}"); 
                }
                if (type == "ChecklistGoal")
                {
                    ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                    string[] chParts = checklistGoal.GetDetailsString().Split(',');
                    int amount = int.Parse(chParts[0]);
                    int target = int.Parse(chParts[1]);
                    int bonus = int.Parse(chParts[2]);
                    outputFile.WriteLine($"{type}, {goalName}, {goalDescription}, {goalPoints}, {bonus}, {target}, {amount}"); 
                }
            }
        }
    }
    public void LoadGoals()
    {
        Console.WriteLine("What is the filename fot the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            string type = parts[0].Trim();
            string name = parts[1].Trim();
            string description = parts[2].Trim();
            string point = parts[3].Trim();

            if (type == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4].Trim());
                SimpleGoal simpleGoal = new SimpleGoal(type, name, description, point);
                simpleGoal.SetComplete(isComplete);
                if (simpleGoal.IsComplete() == true)
                {
                    _goalsCompleted.Add(simpleGoal);
                }
                else
                {
                    _goals.Add(simpleGoal);
                }
            }
            else if (type == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(type, name, description, point);
                _goals.Add(eternalGoal);
            }
            if (type == "ChecklistGoal")
            {
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int amount = int.Parse(parts[6]);
                ChecklistGoal checklistGoal = new ChecklistGoal(type, name, description, point, target, bonus);
                checklistGoal.SetAmountCompleted(amount);
                if (checklistGoal.IsComplete() == true)
                {
                    _goalsCompleted.Add(checklistGoal);
                }
                else
                {
                    _goals.Add(checklistGoal);
                }
            }
        }
    }
}