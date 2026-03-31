using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collection_Assignment
{
    using System;
    using System.Collections.Generic;

    class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Disease { get; set; }
    }

    internal class Assignment_5
    {
        static void Main()
        {
            //Normal Queue (FIFO)
            Queue<Patient> queue = new Queue<Patient>();

            //VIP Queue (Bonus - Priority Handling)
            Queue<Patient> vipQueue = new Queue<Patient>();

            // Add 5 patients
            queue.Enqueue(new Patient { Id = 1, Name = "Ravi", Disease = "Fever" });
            queue.Enqueue(new Patient { Id = 2, Name = "Anita", Disease = "Cold" });
            queue.Enqueue(new Patient { Id = 3, Name = "Karan", Disease = "Headache" });
            queue.Enqueue(new Patient { Id = 4, Name = "Meena", Disease = "Cough" });
            queue.Enqueue(new Patient { Id = 5, Name = "Sita", Disease = "Flu" });

            // Add VIP patients (Bonus)
            vipQueue.Enqueue(new Patient { Id = 101, Name = "VIP1", Disease = "Emergency" });
            vipQueue.Enqueue(new Patient { Id = 102, Name = "VIP2", Disease = "Critical" });

            Console.WriteLine("All Patients in Queue:");
            DisplayQueue(queue);

            //  Serve 2 patients (FIFO)
            Console.WriteLine("\nServing 2 Patients:");

            for (int i = 0; i < 2; i++)
            {
                if (vipQueue.Count > 0)
                {
                    var vip = vipQueue.Dequeue();
                    Console.WriteLine($"VIP Served: {vip.Name}");
                }
                else if (queue.Count > 0)
                {
                    var p = queue.Dequeue();
                    Console.WriteLine($"Served: {p.Name}");
                }
            }

            // Display next patient
            Console.WriteLine("\nNext Patient:");
            if (vipQueue.Count > 0)
            {
                var nextVip = vipQueue.Peek();
                Console.WriteLine($"VIP Next: {nextVip.Name}");
            }
            else if (queue.Count > 0)
            {
                var next = queue.Peek();
                Console.WriteLine($"Next: {next.Name}");
            }
            else
            {
                Console.WriteLine("No patients in queue.");
            }

            // Display remaining patients
            Console.WriteLine("\nRemaining Patients:");

            Console.WriteLine("\nVIP Queue:");
            DisplayQueue(vipQueue);

            Console.WriteLine("\nNormal Queue:");
            DisplayQueue(queue);
        }

        // Helper method
        static void DisplayQueue(Queue<Patient> q)
        {
            foreach (var p in q)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Disease: {p.Disease}");
            }
        }
    }
    
}
