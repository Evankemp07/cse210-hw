using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            if (num == 0)
                break;
            numbers.Add(num);
        }

        int total = numbers.Sum();
        double average = numbers.Average();
        int maximum = numbers.Max();

        Console.WriteLine("The sum is: " + total);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + maximum);
    }
}