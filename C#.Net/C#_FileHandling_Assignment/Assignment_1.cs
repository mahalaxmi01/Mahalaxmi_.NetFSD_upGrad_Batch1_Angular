using System;
using System.Collections.Generic;
using System.Text;

namespace C__FileHandling_Assignment
{
    internal class Assignment_1
    {
        static string file = "employee_log.txt";

        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("\n1. Add Login");
                Console.WriteLine("2. Update Logout");
                Console.WriteLine("3. Show Records");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddLogin();
                        break;
                    case 2:
                        UpdateLogout();
                        break;
                    case 3:
                        ShowRecords();
                        break;
                }

            } while (choice != 4);
        }

        static void AddLogin()
        {
            try
            {
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                string loginTime = DateTime.Now.ToString();
                string logoutTime = "NA";

                StreamWriter sw = new StreamWriter(file, true);
                sw.WriteLine(id + " | " + name + " | " + loginTime + " | " + logoutTime);
                sw.Close();

                Console.WriteLine("Login added");
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        static void UpdateLogout()
        {
            try
            {
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();

                List<string> lines = new List<string>();
                StreamReader sr = new StreamReader(file);

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('|');

                    if (data[0].Trim() == id && data[3].Trim() == "NA")
                    {
                        data[3] = DateTime.Now.ToString();
                        line = data[0] + "|" + data[1] + "|" + data[2] + "|" + data[3];
                    }

                    lines.Add(line);
                }

                sr.Close();

                StreamWriter sw = new StreamWriter(file);
                foreach (string l in lines)
                {
                    sw.WriteLine(l);
                }
                sw.Close();

                Console.WriteLine("Logout updated");
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        static void ShowRecords()
        {
            try
            {
                if (!File.Exists(file))
                {
                    Console.WriteLine("No file found");
                    return;
                }

                StreamReader sr = new StreamReader(file);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                sr.Close();
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
