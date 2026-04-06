using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

// ENHANCEMENT: Saves all entries and prompts to a log file for future reference.
class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;
    private string _logFilePath = "listing_activity_log.txt";

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _random = new Random();

        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        PauseWithCountdown(5);
        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");

        SaveSessionToFile(prompt, items);

        DisplayEndingMessage();
    }

    private void SaveSessionToFile(string prompt, List<string> items)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine($"\n--- Listing Activity Session ---");
                writer.WriteLine($"Date/Time: {DateTime.Now:G}");
                writer.WriteLine($"Duration: {_duration} seconds");
                writer.WriteLine($"Prompt: {prompt}");
                writer.WriteLine($"Items Entered: {items.Count}");
                writer.WriteLine("Entries:");
                foreach (string item in items)
                {
                    writer.WriteLine($"  - {item}");
                }
                writer.WriteLine("---end---");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving session to file: {ex.Message}");
        }
    }
}
