using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Fractions Project - Testing the Fraction Class\n");

        // Test Constructor 1: No parameters (1/1)
        Fraction f1 = new Fraction();
        Console.WriteLine("Test 1 - Constructor with no parameters:");
        Console.WriteLine($"Fraction: {f1.GetFractionString()}");
        Console.WriteLine($"Decimal: {f1.GetDecimalValue()}\n");

        // Test Constructor 2: One parameter (6/1)
        Fraction f2 = new Fraction(6);
        Console.WriteLine("Test 2 - Constructor with one parameter (6):");
        Console.WriteLine($"Fraction: {f2.GetFractionString()}");
        Console.WriteLine($"Decimal: {f2.GetDecimalValue()}\n");

        // Test Constructor 3: Two parameters (6/7)
        Fraction f3 = new Fraction(6, 7);
        Console.WriteLine("Test 3 - Constructor with two parameters (6, 7):");
        Console.WriteLine($"Fraction: {f3.GetFractionString()}");
        Console.WriteLine($"Decimal: {f3.GetDecimalValue()}\n");

        // Test Getters and Setters
        Console.WriteLine("Test 4 - Testing Getters and Setters:");
        Console.WriteLine($"Original fraction f3: {f3.GetFractionString()}");
        Console.WriteLine($"Top value: {f3.GetTop()}");
        Console.WriteLine($"Bottom value: {f3.GetBottom()}");
        
        // Change the values using setters
        f3.SetTop(3);
        f3.SetBottom(4);
        Console.WriteLine($"After setting to 3/4: {f3.GetFractionString()}");
        Console.WriteLine($"Decimal value: {f3.GetDecimalValue()}\n");

        // Test with different fractions
        Console.WriteLine("Test 5 - Testing additional fractions:");
        
        Fraction f4 = new Fraction(1);
        Console.WriteLine($"Fraction (1): {f4.GetFractionString()} = {f4.GetDecimalValue()}");
        
        Fraction f5 = new Fraction(5);
        Console.WriteLine($"Fraction (5): {f5.GetFractionString()} = {f5.GetDecimalValue()}");
        
        Fraction f6 = new Fraction(3, 4);
        Console.WriteLine($"Fraction (3, 4): {f6.GetFractionString()} = {f6.GetDecimalValue()}");
        
        Fraction f7 = new Fraction(1, 3);
        Console.WriteLine($"Fraction (1, 3): {f7.GetFractionString()} = {f7.GetDecimalValue()}");
    }
}