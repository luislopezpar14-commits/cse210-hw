using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your grade? ");
        string gradeInput = Console.ReadLine();
        int grade = int.Parse(gradeInput);
        string letterGrade = "";
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // determine if the student passed
        if (grade >= 70)
        {
            Console.WriteLine($"Congratulations! You passed the course with a {letterGrade}.");
        }
        else
        {
            Console.WriteLine($"Sorry, you did not pass. You received a {letterGrade}. Better luck next time!");
        }

    }
}