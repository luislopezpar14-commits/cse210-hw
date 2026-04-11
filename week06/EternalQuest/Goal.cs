public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Returns the points earned from recording this event
    public virtual int RecordEvent()
    {
        return 0;
    }

    // Returns true if the goal is complete
    public virtual bool IsComplete()
    {
        return false;
    }

    // Returns the details string with checkbox and goal info
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} -- {_description}";
    }

    // Returns a string representation for saving to file
    public virtual string GetStringRepresentation()
    {
        return "";
    }
}