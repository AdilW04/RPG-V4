using System;
using System.Threading;
static class Output
{
    public static void Ln(string input)
    {
        foreach(char i in input +"\n")
        {
            Console.Write(i);
            Thread.Sleep(30);
        }
    }
    public static void Ln(string input,int speed)
    {
        foreach (char i in input + "\n")
        {
            Console.Write(i);
            Thread.Sleep(speed);
        }
    }
    public static void Ln(string input, int Speed,int slowDownRate)
    {
        foreach (char i in input + "\n")
        {
            Console.Write(i);
            Thread.Sleep(Speed);
            Speed += slowDownRate;
        }
    }
}