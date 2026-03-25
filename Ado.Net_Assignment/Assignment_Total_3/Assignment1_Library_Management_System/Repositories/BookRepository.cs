using Assignment1_Library_Management_System.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Library_Management_System.Repository
{
    internal class BookRepository
    {
        string connectionString = "Data Source=DESKTOP-4O1D65I\\SQLEXPRESS;Initial Catalog=NewPracticeDb;Integrated Security=True;Trust Server Certificate=True";

        public void AddBook(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string qry = "INSERT INTO Books (Title, Author, Price) VALUES (@Title, @Author, @Price)";
                    SqlCommand command = new SqlCommand(qry, connection);

                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Price", book.Price);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Book added successfully.");
                    else
                        Console.WriteLine("Book not added.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void ViewBooks()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string qry = "SELECT * FROM Books";
                    SqlCommand command = new SqlCommand(qry, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No books found.");
                        return;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["BookId"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Price: {reader["Price"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void UpdateBook(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string qry = "UPDATE Books SET Title=@Title, Author=@Author, Price=@Price WHERE BookId=@BookId";
                    SqlCommand command = new SqlCommand(qry, connection);

                    command.Parameters.AddWithValue("@BookId", book.BookId);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Price", book.Price);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Book updated successfully.");
                    else
                        Console.WriteLine("Book not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void DeleteBook(int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string qry = "DELETE FROM Books WHERE BookId=@BookId";
                    SqlCommand command = new SqlCommand(qry, connection);

                    command.Parameters.AddWithValue("@BookId", bookId);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Book deleted successfully.");
                    else
                        Console.WriteLine("Book not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void SearchBookByName(string title)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string qry = "SELECT * FROM Books WHERE Title LIKE @Title";
                    SqlCommand command = new SqlCommand(qry, connection);

                    command.Parameters.AddWithValue("@Title", "%" + title + "%");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No matching book found.");
                        return;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["BookId"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Price: {reader["Price"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BookRepository repo = new BookRepository();
            int choice;

            do
            {
                Console.WriteLine("\n===== Library Management System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View Books");
                Console.WriteLine("3. Update Book Details");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Search Book by Name");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Book newBook = new Book();

                        Console.Write("Enter Title: ");
                        newBook.Title = Console.ReadLine();

                        Console.Write("Enter Author: ");
                        newBook.Author = Console.ReadLine();

                        Console.Write("Enter Price: ");
                        newBook.Price = Convert.ToDecimal(Console.ReadLine());

                        repo.AddBook(newBook);
                        break;

                    case 2:
                        repo.ViewBooks();
                        break;

                    case 3:
                        Book updateBook = new Book();

                        Console.Write("Enter Book Id to update: ");
                        updateBook.BookId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Title: ");
                        updateBook.Title = Console.ReadLine();

                        Console.Write("Enter New Author: ");
                        updateBook.Author = Console.ReadLine();

                        Console.Write("Enter New Price: ");
                        updateBook.Price = Convert.ToDecimal(Console.ReadLine());

                        repo.UpdateBook(updateBook);
                        break;

                    case 4:
                        Console.Write("Enter Book Id to delete: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        repo.DeleteBook(deleteId);
                        break;

                    case 5:
                        Console.Write("Enter Book Title to search: ");
                        string title = Console.ReadLine();

                        repo.SearchBookByName(title);
                        break;

                    case 6:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 6);
        }

    }
}
