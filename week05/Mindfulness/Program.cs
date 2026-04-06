using System;



class Program
{
    static void Main(string[] args)
    {
        ActivityLog activityLog = new ActivityLog();
        string choice = "";

        while (choice != "5")
        {
            DisplayMenu();
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activityLog.DisplayActivityLog();
                    continue;
                case "5":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            if (activity != null)
            {
                activity.Run();
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflection activity");
        Console.WriteLine("3. Start listing activity");
        // ENHANCEMENT: Added option to view activity log directly from the menu.
        Console.WriteLine("4. View activity log");
        Console.WriteLine("5. Quit");
        Console.WriteLine();
    }
}