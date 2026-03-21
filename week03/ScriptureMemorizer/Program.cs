using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        bool playAgain = true;
        // exceeding requirements by allowing the user to play multiple times and choose to quit at any time
        while (playAgain)
        {
            Reference reference = new Reference("John", 3, 16);
            Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his begotten Son, that whoever believes in him should not perish but have eternal life.");
            
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    playAgain = false;
                    break;
                }
                scripture.HideRandomWords(3); // Hide 3 random words each time
            }

            if (playAgain && scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden!");
                Console.WriteLine("Do you want to play again? (yes/no)");
                string response = Console.ReadLine();
                
                if (response.ToLower() != "yes")
                {
                    playAgain = false;
                }
            }
        }
    }
}