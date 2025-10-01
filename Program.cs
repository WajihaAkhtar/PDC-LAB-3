using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int num = rand.Next(1, 101);
            Console.WriteLine("Generated: " + num);

            if (num % 2 == 0)
            {
                CallComputeSquare(num);
            }
            else
            {
                CallComputeCube(num);
            }

            Thread.Sleep(1000);
        }
    }

    static void CallComputeSquare(int num)
    {
        Thread evenThread = new Thread(() => ComputeSquare(num));
        evenThread.Name = "EvenThread";
        evenThread.Start();
        evenThread.Join();
    }

    static void CallComputeCube(int num)
    {
        Thread oddThread = new Thread(() => ComputeCube(num));
        oddThread.Name = "OddThread";
        oddThread.Start();
        oddThread.Join();
    }

    static void ComputeSquare(int num)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} processing number {num}");
        int square = num * num;
        Console.WriteLine($"Square of {num} = {square}");
    }

    static void ComputeCube(int num)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} processing number {num}");
        int cube = num * num * num;
        Console.WriteLine($"Cube of {num} = {cube}");
    }
}