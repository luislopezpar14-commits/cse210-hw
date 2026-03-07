using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when done:");
        string input = Console.ReadLine();
        while (input != "0")
        {
            Console.WriteLine("Enter a number:");
            numbers.Add(int.Parse(input));
            input = Console.ReadLine();
        }
        Console.WriteLine("The sum of the numbers is: " + numbers.Sum());
        Console.WriteLine("The average of the numbers is: " + numbers.Average());
        Console.WriteLine("The largest number is: " + numbers.Max());
        Console.WriteLine("The smallest positive number is: " + numbers.Where(n => n > 0).Min());
        Console.WriteLine("The sorted list of numbers is: " + string.Join(", ", numbers.OrderBy(n => n)));
    }
}