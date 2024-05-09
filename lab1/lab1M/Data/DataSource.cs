using BookStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class DataSource
    {
        private static IEnumerable<Book> _books;
        private static IEnumerable<Author> _authors;
        private static IEnumerable<Publisher> _publishers;

        //private Action[] _actions = new Action[]
        //{
        //    () =>Queries.FindByYear(_books),
        //    () =>Queries.FindByAuthor(_books, _authors),
        //    () =>Queries.SortByYear(_books),
        //    () =>Queries.FindSummaryPrice(_books, _authors),
        //    () =>Queries.FindByInventoryNumber(_books),
        //    () =>Queries.FindWhereInventoryNumbersMoreThan(_books),
        //    () =>Queries.FindAuthorsWhoHasMoreThanBooks(_books, _authors),
        //    () =>Queries.GroupByPublishers(_books, _publishers),
        //    () =>Queries.FindByPublishersCountry(_books, _authors, _publishers),
        //    () =>Queries.FindPublishersWithLetterInName( _publishers),
        //    () =>Queries.GrupByCountry(_books, _publishers),
        //    () =>Queries.FindInventoryByAuthors(_books, _authors),
        //    () =>Queries.FindMaxAndMinPrice(_books, _publishers),
        //    () =>Queries.FindBooksAndQuantity(_books),
        //    () =>Queries.CheckIfExists(_books, _authors)
        //};

        private string[] _queryInfo = new string[]
        {
            "1. Знайти книгу, що видана у 1995 році",
            "2. Знайти всі книги, що написані автором Joanne Rowling",
            "3. Відстортувати книги за роком видання",
            "4. Вивести загальну ціну за всі книги окремого автора",
            "5. Знайти книги, що мають інвентарні номери 1002 і 3113",
            "6. Знайти книги, що мають більше одного інвентарного номера",
            "7. Вивести авторів, авторства яких книг налічується в бібліотеці більше одної",
            "8. Вивести всі книги, згрупувавши за їх видавництвом",
            "9. Вивести авторів, чиї книги були видані видавництвами, що базуються у Іспанії",
            "10. Знайти видавництва, назва яких починається з букви S, відсортувати за алфавітом по назві країни",
            "11. Згрупувати книги за країною видавництва",
            "12. Вивести всі інвентарні номери, що призначені книгам авторів Rowling і Shakespare, відсортувавши їх за спаданням",
            "13. Вивести видавництва, сумарна ціна за книги яких є найбільшою або найменшою",
            "14. Вивести назви і кількість книг, ціна яких знаходиться в діапазоні від 12$ до 16$",
            "15. Оприділити, чи наявна в бібліотеці книга автора Jack Shakespeare"
        };

        public IEnumerable<Book> Books { get => _books; }
        public IEnumerable<Author> Authors { get => _authors; }
        public IEnumerable<Publisher> Publishers { get => _publishers; }

        //public Action[] Actions { get => _actions; }
        public string[] QueryInfo { get => _queryInfo; }

        public DataSource()
        {
            _authors = GenerateAuthors();
            _publishers = GeneratePublishers();
            _books = GenerateBooks(_authors, _publishers);
        }

        public IEnumerable<Author> GenerateAuthors()
        {
            return new List<Author>
            {
                new Author(1, "Jack", "London"),
                new Author(2, "William", "Shakespeare"),
                new Author(3, "Joanne", "Rowling"),
                new Author(4, "Agatha", "Christie"),
            };
        }

        public IEnumerable<Publisher> GeneratePublishers()
        {
            return new List<Publisher>
            {
                new Publisher(1, "Sunset publishing", "USA"),
                new Publisher(2, "Sierra Madre", "Spain"),
                new Publisher(3, "Blue Sky Times", "USA"),
            };
        }

        public IEnumerable<Book> GenerateBooks(IEnumerable<Author> authors_, IEnumerable<Publisher> publishers_)
        {


            List<Author> authors = authors_.ToList();
            List<Publisher> publishers = publishers_.ToList();

            return new List<Book>
            {
                new Book(1, "The Sea-Wolf", authors[0], 20.5M, 1904, publishers[0], new List<int>{1002, 1003}),
                new Book(2, "Burning Daylight", authors[0], 26.5M, 1910, publishers[0], new List<int>{1004, 1005}),
                new Book(3, "Hamlet", authors[1], 15.3M, 1980, publishers[1], new List<int>{2110, 2111}),
                new Book(4, "Harry Potter and the Philosopher's Stone", authors[2], 12.3M, 1995, publishers[2], new List<int>{3110, 3111, 3112}),
                new Book(5, "Harry Potter and the Chamber of Secrets", authors[2], 11.2M, 1998, publishers[2], new List<int>{3113}),
                new Book(6, "Harry Potter and the Deathly Hallows", authors[2], 13.4M, 2007, publishers[2], new List<int>{3114, 3115}),
                new Book(7, "Murder on the Orient Express", authors[3], 15.6M, 1934, publishers[2], new List<int>{4110}),
                new Book(8, "Death on the Nile", authors[3], 16.3M, 1950, publishers[1], new List<int>{4111, 4112}),
            };
        }

    }
}
