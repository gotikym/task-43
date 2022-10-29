using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        const string AddBook = "add";
        const string ShowAllBooks = "show";
        const string DeleteBook = "delete";
        const string ShowBooksOptions = "sort";
        const string Exit = "exit";

        Library library = new Library();

        bool isExit = false;

        while (isExit == false)
        {
            Console.WriteLine("Для добавления книги напишите: " + AddBook + "\nДля показа всех книг: " + ShowAllBooks +
            "\nДля удаления книги: " + DeleteBook + "\nДля сортировки книг: " + ShowBooksOptions + "\nДля выхода из программы: " + Exit);
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case AddBook:
                    library.AddBook();
                    break;

                case ShowAllBooks:
                    library.ShowAllBooks();
                    break;

                case DeleteBook:
                    library.DeleteBook();
                    break;

                case ShowBooksOptions:
                    library.ShowBooksOptions();
                    break;

                case Exit:
                    isExit = true;
                    break;
            }
        }
    }
}

class Library
{
    private List<Book> _library = new List<Book>();

    public Library()
    {
        _library = new List<Book>();
    }

    public void AddBook()
    {
        Console.WriteLine("Введите информацию о добавляемой книге.");
        Console.Write("Название: ");
        string name = Console.ReadLine();
        Console.Write("Автор: ");
        string autor = Console.ReadLine();
        Console.Write("Год выпуска: ");
        string yearPublishing = Console.ReadLine();
        Console.Write("Жанр: ");
        string genre = Console.ReadLine();
        _library.Add(new Book(name, autor, yearPublishing, genre));
    }

    public void DeleteBook()
    {
        Console.WriteLine("Укажите номер книги, которую хотите убрать: ");

        _library.RemoveAt(GetNumber());
    }

    public void ShowAllBooks()
    {
        int number = 0;

        foreach (Book book in _library)
        {
            Console.WriteLine(number++ + " " + book.Name + " " + book.Autor + " " + book.YearPublishing + " " + book.Genre);
        }
    }

    public void ShowBooksOptions()
    {
        bool isExit = false;
        const string Name = "1";
        const string Author = "2";
        const string Date = "3";
        const string Genre = "4";
        const string Exit = "5";

        while (isExit == false)
        {
            Console.WriteLine("Выберете параметр по которому хотите отсортировать книги: ");
            Console.WriteLine("1: Название\n2: Автор\n3: Дата выпуска\n4: Жанр\n5: Выход");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case Name:
                    FilterName();
                    break;

                case Author:
                    FilterAuthor();
                    break;

                case Date:
                    FilterYearPublishing();
                    break;

                case Genre:
                    FilterGenre();
                    break;

                case Exit:
                    isExit = true;
                    break;
            }
        }
    }

    private void FilterName()
    {
        Console.WriteLine("Напишите название для сортировки");
        string userChoice = Console.ReadLine();

        foreach (Book book in _library)
        {
            if (book.Name == userChoice)
            {
                Console.WriteLine(book.Name + " " + book.Autor + " " + book.YearPublishing + " " + book.Genre);
            }
        }
    }

    private void FilterAuthor()
    {
        Console.WriteLine("Напишите автора для сортировки");
        string userChoice = Console.ReadLine();

        foreach (Book book in _library)
        {
            if (book.Autor == userChoice)
            {
                Console.WriteLine(book.Name + " " + book.Autor + " " + book.YearPublishing + " " + book.Genre);
            }
        }
    }

    private void FilterYearPublishing()
    {
        Console.WriteLine("Напишите год выпуска для сортировки");
        string userChoice = Console.ReadLine();

        foreach (Book book in _library)
        {
            if (book.YearPublishing == userChoice)
            {
                Console.WriteLine(book.Name + " " + book.Autor + " " + book.YearPublishing + " " + book.Genre);
            }
        }
    }

    private void FilterGenre()
    {
        Console.WriteLine("Напишите жанр для сортировки");
        string userChoice = Console.ReadLine();

        foreach (Book book in _library)
        {
            if (book.Genre == userChoice)
            {
                Console.WriteLine(book.Name + " " + book.Autor + " " + book.YearPublishing + " " + book.Genre);
            }
        }
    }

    private int GetNumber()
    {
        bool isParse = false;
        int numberForReturn = 0;

        while (isParse == false)
        {
            string userNumber = Console.ReadLine();

            if ((isParse = int.TryParse(userNumber, out int number)) == false)
            {
                Console.WriteLine("Вы не корректно ввели число.");
            }

            numberForReturn = number;
        }

        return numberForReturn;
    }
}

class Book
{
    public string Name { get; private set; }
    public string Autor { get; private set; }
    public string YearPublishing { get; private set; }
    public string Genre { get; private set; }

    public Book(string name, string autor, string yearPublishing, string genre)
    {
        Name = name;
        Autor = autor;
        YearPublishing = yearPublishing;
        Genre = genre;
    }
}
