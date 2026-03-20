using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collection_Assignment
{
    using System;
    using System.Collections.Generic;

    internal class Assignment_3
    {
        static void Main()
        {
            // HashSet 
            HashSet<string> emails = new HashSet<string>();

            //  Add 10 emails (with duplicates)
            emails.Add("a@gmail.com");
            emails.Add("b@gmail.com");
            emails.Add("c@gmail.com");
            emails.Add("d@gmail.com");
            emails.Add("e@gmail.com");
            emails.Add("f@gmail.com");
            emails.Add("a@gmail.com"); 
            emails.Add("b@gmail.com"); 
            emails.Add("g@gmail.com");
            emails.Add("h@gmail.com");

            //  Display unique emails
            Console.WriteLine("Unique Registered Emails:");
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }

            //  Check if email exists
            Console.WriteLine("\nEnter email to check:");
            string searchEmail = Console.ReadLine();

            if (emails.Contains(searchEmail))
                Console.WriteLine("Email is registered.");
            else
                Console.WriteLine("Email not found.");

            // Remove an email
            Console.WriteLine("\nEnter email to remove:");
            string removeEmail = Console.ReadLine();

            if (emails.Remove(removeEmail))
                Console.WriteLine("Email removed successfully.");
            else
                Console.WriteLine("Email not found.");

            // Display updated list
            Console.WriteLine("\nUpdated Email List:");
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }

            // ================= BONUS =================

            //Second event participants
            HashSet<string> event2 = new HashSet<string>()
        {
            "x@gmail.com",
            "y@gmail.com",
            "a@gmail.com",
            "b@gmail.com",
            "z@gmail.com"
        };

            // Find common participants
            HashSet<string> common = new HashSet<string>(emails);
            common.IntersectWith(event2);

            Console.WriteLine("\nCommon Participants in Both Events:");
            foreach (var email in common)
            {
                Console.WriteLine(email);
            }
        }
    }
}
