using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace C__MultiThread_Assignment
{
    internal class Assignment1
    {
        static int[] partialSums = new int[5]; // store results of each thread

        static void Main()
        {
            // 1. Create list 1 to 50
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 50; i++)
            {
                numbers.Add(i);
            }

            // 2. Split into 5 parts (each 10 numbers)
            List<int>[] parts = new List<int>[5];
            for (int i = 0; i < 5; i++)
            {
                parts[i] = numbers.GetRange(i * 10, 10);
            }

            Thread[] threads = new Thread[5];

            // 3. Create 5 threads
            for (int i = 0; i < 5; i++)
            {
                int index = i; // avoid closure issue
                threads[i] = new Thread(() => ProcessNumbers(parts[index], index));
                threads[i].Start();
            }

            // Wait for all threads to finish
            for (int i = 0; i < 5; i++)
            {
                threads[i].Join();
            }

            // Final sum
            int finalSum = 0;
            foreach (int sum in partialSums)
            {
                finalSum += sum;
            }

            Console.WriteLine("\nFinal Sum: " + finalSum);
        }

        static void ProcessNumbers(List<int> part, int index)
        {
            int sum = 0;

            Console.WriteLine($"\nThread {index + 1} processing:");

            foreach (int num in part)
            {
                Console.Write(num + " ");
                sum += num;
            }

            partialSums[index] = sum;

            Console.WriteLine($"\nThread {index + 1} Sum: {sum}");
        }
    }
}
