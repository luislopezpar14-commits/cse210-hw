using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Magic Number Game!");
        int magicNumber = new Random().Next(1, 11); 
        Console.WriteLine("What is your guess?");
        int guess = int.Parse(Console.ReadLine());
        while (guess != magicNumber)
        {
            if (guess < magicNumber)
            {
                Console.WriteLine("Too low!");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Too high!");
            }
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Congratulations! You guessed the magic number!");


       
    }
}