using System;
using System.Threading;

/// <summary>
/// ENHANCEMENT: Automatically logs all activity sessions to track usage history.
/// </summary>
class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static ActivityLog _log = new ActivityLog();

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        PauseWithSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} second session of the {_name}.");
        PauseWithSpinner(3);

        _log.LogActivity(_name, _duration);
    }

    protected void PauseWithSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinnerChars = { "|", "/", "-", "\\" };
        int spinnerIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[spinnerIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            spinnerIndex = (spinnerIndex + 1) % spinnerChars.Length;
        }
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void Run()
    {
        // To be overridden by derived classes
    }
}
