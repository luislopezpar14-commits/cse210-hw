using System;
using System.IO;
using System.Collections.Generic;

// ENHANCEMENT: Provides session history and statistics on user activities.
class ActivityLog
{
    private string _logFilePath = "activity_session_log.txt";

    public void LogActivity(string activityName, int duration)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:G} | {activityName} | Duration: {duration}s");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error logging activity: {ex.Message}");
        }
    }

    public void DisplayActivityLog()
    {
        Console.Clear();
        Console.WriteLine("=== Activity Session Log ===");
        Console.WriteLine();

        if (!File.Exists(_logFilePath))
        {
            Console.WriteLine("No activity log found. Complete an activity to start logging.");
        }
        else
        {
            try
            {
                string[] lines = File.ReadAllLines(_logFilePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading log file: {ex.Message}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    }
}
