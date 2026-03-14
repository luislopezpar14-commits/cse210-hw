using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.GetAsString());
                }
            }
            Console.WriteLine($"Journal saved to {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                _entries.Clear();
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    Entry entry = Entry.ParseFromString(line);
                    if (entry != null)
                    {
                        _entries.Add(entry);
                    }
                }
                Console.WriteLine($"Journal loaded from {file}");
            }
            else
            {
                Console.WriteLine($"File {file} not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}
