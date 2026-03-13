using System;
using System.Collections.Generic;

namespace Assignment08
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("===== Part 01: Calculator =====");

            Calculator calc = new Calculator();

            Console.WriteLine("Add: " + calc.Add(10, 5));
            Console.WriteLine("Subtract: " + calc.Subtract(10, 5));
            Console.WriteLine("Multiply: " + calc.Multiply(10, 5));
            Console.WriteLine("Divide: " + calc.Divide(10, 5));

            Console.WriteLine("\n===== Part 02: Delegates =====");

            List<Book> books = new List<Book>()
            {
                new Book("111","C# Basics","Ali",new DateTime(2020,1,1),100),
                new Book("222","ASP.NET","Sara",new DateTime(2021,5,10),200)
            };

            Console.WriteLine("\nUser Defined Delegate (Title)");
            Library.ProcessBooks(books, BookFunctions.GetTitle);

            Console.WriteLine("\nBuilt-in Delegate (Author)");
            Func<Book,string> f = BookFunctions.GetAuthor;
            foreach(Book b in books)
                Console.WriteLine(f(b));

            Console.WriteLine("\nAnonymous Method (ISBN)");
            Library.ProcessBooks(books, delegate(Book b)
            {
                return b.ISBN;
            });

            Console.WriteLine("\nLambda Expression (Publication Date)");
            Library.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());


            Console.WriteLine("\n===== Part 03: Test Cases =====");

            Console.WriteLine("Test Add(5,3) Expected 8 -> " + calc.Add(5,3));
            Console.WriteLine("Test Add(2,2) Expected 4 -> " + calc.Add(2,2));

            Console.WriteLine("Test Multiply(3,4) Expected 12 -> " + calc.Multiply(3,4));
            Console.WriteLine("Test Multiply(2,5) Expected 10 -> " + calc.Multiply(2,5));
        }
    }


    // =====================
    // Part 01 Calculator
    // =====================

    class Calculator
    {
        public int Add(int a,int b)
        {
            return a+b;
        }

        public int Subtract(int a,int b)
        {
            return a-b;
        }

        public int Multiply(int a,int b)
        {
            return a*b;
        }

        public double Divide(int a,int b)
        {
            if(b==0)
                throw new DivideByZeroException("Cannot divide by zero");

            return (double)a/b;
        }
    }


    // =====================
    // Part 02 Delegates
    // =====================

    public class Book
    {
        public string ISBN {get;set;}
        public string Title {get;set;}
        public string Author {get;set;}
        public DateTime PublicationDate {get;set;}
        public decimal Price {get;set;}

        public Book(string isbn,string title,string author,DateTime date,decimal price)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            PublicationDate = date;
            Price = price;
        }
    }


    public class BookFunctions
    {
        public static string GetTitle(Book b)
        {
            return b.Title;
        }

        public static string GetAuthor(Book b)
        {
            return b.Author;
        }

        public static string GetPrice(Book b)
        {
            return b.Price.ToString();
        }
    }


    // Custom Delegate
    public delegate string BookDelegate(Book b);


    public class Library
    {
        public static void ProcessBooks(List<Book> books, BookDelegate f)
        {
            foreach(Book b in books)
            {
                Console.WriteLine(f(b));
            }
        }
    }

}