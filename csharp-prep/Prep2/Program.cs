using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string grade = "";

        if (percent >= 90)
        {
            grade = "A";
        }
        else if (percent >= 80)
        {
            grade = "B";
        }
        else if (percent >= 70)
        {
            grade = "C";
        }
        else if (percent >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        int lastDigit = percent % 10;
        string sign = "";

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }



        Console.WriteLine("Grade: " + grade + sign);
        
        if (percent >= 70)
        {
            Console.WriteLine("You passed :)");
        }
        else
        {
            Console.WriteLine("You didn't pass :(");
        }
    }
}