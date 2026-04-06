using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool breathingIn = true;

        while (DateTime.Now < endTime)
        {
            if (breathingIn)
            {
                Console.WriteLine("Breathe in...");
                PauseWithCountdown(4);
            }
            else
            {
                Console.WriteLine("Breathe out...");
                PauseWithCountdown(4);
            }
            breathingIn = !breathingIn;
        }

        DisplayEndingMessage();
    }
}
