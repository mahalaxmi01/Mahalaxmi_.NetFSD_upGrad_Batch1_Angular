using System;
using System.Collections.Generic;
using System.Text;

namespace C__FileHandling_Assignment
{
    using System;
    using System.IO;

    internal class Assignment_2
    {
        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("\n1. Create Report Card");
                Console.WriteLine("2. Read Report Card");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateReport();
                        break;
                    case 2:
                        ReadReport();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 3);
        }

        static void CreateReport()
        {
            try
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Roll Number: ");
                string rollNo = Console.ReadLine();

                Console.Write("Enter Marks in Subject 1: ");
                int m1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Marks in Subject 2: ");
                int m2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Marks in Subject 3: ");
                int m3 = Convert.ToInt32(Console.ReadLine());

                if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
                {
                    Console.WriteLine("Marks should be between 0 and 100");
                    return;
                }

                int total = m1 + m2 + m3;
                double average = total / 3.0;
                string grade;

                if (average >= 75)
                    grade = "A";
                else if (average >= 60)
                    grade = "B";
                else if (average >= 40)
                    grade = "C";
                else
                    grade = "Fail";

                string content =
                    "Student Name: " + name + Environment.NewLine +
                    "Roll Number: " + rollNo + Environment.NewLine +
                    "Marks: " + m1 + ", " + m2 + ", " + m3 + Environment.NewLine +
                    "Total: " + total + Environment.NewLine +
                    "Average: " + average + Environment.NewLine +
                    "Grade: " + grade;

                File.WriteAllText(rollNo + ".txt", content);

                Console.WriteLine("Report card saved successfully.");
            }
            catch
            {
                Console.WriteLine("Invalid input or error occurred.");
            }
        }

        static void ReadReport()
        {
            try
            {
                Console.Write("Enter Roll Number: ");
                string rollNo = Console.ReadLine();

                string fileName = rollNo + ".txt";

                if (File.Exists(fileName))
                {
                    string data = File.ReadAllText(fileName);
                    Console.WriteLine("\nStudent Report Card");
                    Console.WriteLine(data);
                }
                else
                {
                    Console.WriteLine("Report card file not found.");
                }
            }
            catch
            {
                Console.WriteLine("Error while reading file.");
            }
        }
    }
}
