using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_ExceptionHandling
{
    class TicketBooking
    {
        static int availableTickets = 15;

        public static void BookTickets(int requestedTickets)
        {
            if (requestedTickets > availableTickets)
            {
                throw new TicketException("Tickets not available!");
            }
            else
            {
                availableTickets -= requestedTickets;
                Console.WriteLine("Booking Successful!");
                Console.WriteLine("Tickets Booked: " + requestedTickets);
                Console.WriteLine("Tickets Remaining: " + availableTickets);
            }
        }
    }

    // User-defined Exception
    class TicketException : Exception
    {
        public TicketException(string message) : base(message)
        {
        }
    }
    internal class Assignment_2
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Do you want to book tickets? (yes/no)");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "yes")
                {
                    Console.WriteLine("Enter number of tickets:");
                    int tickets = Convert.ToInt32(Console.ReadLine());

                    TicketBooking.BookTickets(tickets);
                }
                else
                {
                    Console.WriteLine("Thank you!");
                }
            }
            catch (TicketException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input!");
            }

            Console.ReadLine();
        }
    }
}
