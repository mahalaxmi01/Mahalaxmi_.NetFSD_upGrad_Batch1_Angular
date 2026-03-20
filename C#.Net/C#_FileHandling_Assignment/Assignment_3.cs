using System;
using System.Collections.Generic;
using System.Text;

namespace C__FileHandling_Assignment
{
    using System;
    using System.IO;

    internal class Assignment_3
    {
        static void Main()
        {
            int choice;
            string fileName;

            do
            {
                Console.WriteLine("\n--- Mini Notepad ---");
                Console.WriteLine("1. Create New File");
                Console.WriteLine("2. Write to File");
                Console.WriteLine("3. Read File");
                Console.WriteLine("4. Append Text");
                Console.WriteLine("5. Delete File");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter file name: ");
                        fileName = Console.ReadLine() + ".txt";
                        CreateFile(fileName);
                        break;

                    case 2:
                        Console.Write("Enter file name: ");
                        fileName = Console.ReadLine() + ".txt";
                        WriteFile(fileName);
                        break;

                    case 3:
                        Console.Write("Enter file name: ");
                        fileName = Console.ReadLine() + ".txt";
                        ReadFile(fileName);
                        break;

                    case 4:
                        Console.Write("Enter file name: ");
                        fileName = Console.ReadLine() + ".txt";
                        AppendFile(fileName);
                        break;

                    case 5:
                        Console.Write("Enter file name: ");
                        fileName = Console.ReadLine() + ".txt";
                        DeleteFile(fileName);
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 6);
        }

        static void CreateFile(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                fs.Close();
                Console.WriteLine("File created successfully.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error while creating file.");
            }
        }

        static void WriteFile(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                Console.WriteLine("Enter text line by line.");
                Console.WriteLine("Type END to stop writing.");

                string line;
                while (true)
                {
                    line = Console.ReadLine();
                    if (line == "END")
                        break;

                    sw.WriteLine(line);
                }

                sw.Close();
                fs.Close();

                Console.WriteLine("Data written successfully.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to write to this file.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error while writing file.");
            }
        }

        static void ReadFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                Console.WriteLine("\nFile Content:");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                sr.Close();
                fs.Close();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to read this file.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error while reading file.");
            }
        }

        static void AppendFile(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                Console.WriteLine("Enter text to append.");
                Console.WriteLine("Type END to stop.");

                string line;
                while (true)
                {
                    line = Console.ReadLine();
                    if (line == "END")
                        break;

                    sw.WriteLine(line);
                }

                sw.Close();
                fs.Close();

                Console.WriteLine("Text appended successfully.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to append to this file.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error while appending file.");
            }
        }

        static void DeleteFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    Console.WriteLine("File deleted successfully.");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to delete this file.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error while deleting file.");
            }
        }
    }

}
