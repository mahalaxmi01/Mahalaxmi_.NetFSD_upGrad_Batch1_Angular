using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment15
    {
        static void Main(String[] args)
        {
            int[] marks = new int[10];
            int total = 0;

            Console.WriteLine("Enter 10 marks:");

            for (int i = 0; i < 10; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
                total += marks[i];
            }

            double average = total / 10.0;

            int min = marks[0];
            int max = marks[0];

            for (int i = 1; i < 10; i++)
            {
                if (marks[i] < min)
                    min = marks[i];

                if (marks[i] > max)
                    max = marks[i];
            }

            // Sorting (Ascending Order)
            for (int i = 0; i < 10; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    if (marks[i] > marks[j])
                    {
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;
                    }
                }
            }

            Console.WriteLine("Total = " + total);
            Console.WriteLine("Average = " + average);
            Console.WriteLine("Minimum marks = " + min);
            Console.WriteLine("Maximum marks = " + max);

            Console.WriteLine("Ascending Order:");
            for (int i = 0; i < 10; i++)
                Console.Write(marks[i] + " ");

            Console.WriteLine();

            Console.WriteLine("Descending Order:");
            for (int i = 9; i >= 0; i--)
                Console.Write(marks[i] + " ");

        }
    }
}
