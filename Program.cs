using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        const string AddBook = "add";
        const string ShowAllBooks = "show";
        const string DeleteBook = "delete";
        const string ShowBooksOptions = "filter";
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
        const string Name = "1";
        const string Author = "2";
        const string Date = "3";
        const string Genre = "4";
        const string Exit = "5";
        bool isExit = false;

        while (isExit == false)
        {
            Console.WriteLine("Выберете параметр по которому хотите отсортировать книги: ");
            Console.WriteLine(Name + ": Название\n" + Author + ": Автор\n" + Date + ": Дата выпуска\n" + Genre +
                ": Жанр\n" + Exit + ": Выход");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case Name:
                    ShowBooksByName();
                    break;

                case Author:
                    ShowBooksByAuthor();
                    break;

                case Date:
                    ShowBooksByYearPublishing();
                    break;

                case Genre:
                    ShowBooksByGenre();
                    break;

                case Exit:
                    isExit = true;
                    break;
            }
        }
    }

    private void ShowBooksByName()
    {
        Console.WriteLine("Напишите название для сортировки");
        ShowBooks();
    }

    private void ShowBooksByAuthor()
    {
        Console.WriteLine("Напишите автора для сортировки");
        ShowBooks();
    }

    private void ShowBooksByYearPublishing()
    {
        Console.WriteLine("Напишите год выпуска для сортировки");
        ShowBooks();
    }

    private void ShowBooksByGenre()
    {
        Console.WriteLine("Напишите жанр для сортировки");
        ShowBooks();
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

    private void ShowBooks()
    {
        string userChoice = Console.ReadLine();

        foreach (Book book in _library)
        {
            if (book.Genre == userChoice)
            {
                Console.WriteLine(book.Name + " " + book.Autor + " " + book.YearPublishing + " " + book.Genre);
            }
        }
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
