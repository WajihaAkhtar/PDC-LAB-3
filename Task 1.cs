using System;
using System.Threading;

class Fruit
{
    private string name;
    private int sleepTime; // in seconds

    public Fruit(string name, int sleepTime)
    {
        this.name = name;
        this.sleepTime = sleepTime;
    }

    public void Run()
    {
        for (int i = 1; i <= 3; i++)
        {
            Thread.Sleep(sleepTime * 1000); // Convert seconds to milliseconds
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} - {name} - Loop {i}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Fruit apple = new Fruit("Apple", 1);
        Fruit banana = new Fruit("Banana", 2);
        Fruit cherry = new Fruit("Cherry", 3);

        Thread t1 = new Thread(apple.Run);
        Thread t2 = new Thread(banana.Run);
        Thread t3 = new Thread(cherry.Run);

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("All threads finished");
    }
}
