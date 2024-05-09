using BookStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

//namespace lab1
//{
//    class Class1
//    {
//        List<Author> authors = new List<Author>
//            {
//                new Author(1, "Jack", "London"),
//                new Author(2, "William", "Shakespeare"),
//                new Author(3, "Joanne", "Rowling"),
//                new Author(4, "Agatha", "Christie"),
//            };

//        List<Publisher> publishers = new List<Publisher>
//            {
//                new Publisher(1, "Sunset publishing", "USA"),
//                new Publisher(2, "Sierra Madre", "Spain"),
//                new Publisher(3, "Blue Sky Times", "United Kingdom"),
//            };

//        List<Book> books = new List<Book>
//            {
//                new Book(1, "The Sea-Wolf", authors[0], 20.5M, 1904, publishers[0], new List<int>{1002, 1003}),
//                new Book(2, "Burning Daylight", authors[0], 26.5M, 1910, publishers[0], new List<int>{1004, 1005}),
//                new Book(3, "Hamlet", authors[1], 15.3M, 1980, publishers[1], new List<int>{2110, 2111}),
//                new Book(4, "Harry Potter and the Philosopher's Stone", authors[2], 12.3M, 1995, publishers[2], new List<int>{3110, 3111, 3112}),
//                new Book(5, "Harry Potter and the Chamber of Secrets", authors[2], 11.2M, 1998, publishers[2], new List<int>{3113}),
//                new Book(6, "Harry Potter and the Deathly Hallows", authors[2], 13.4M, 2007, publishers[2], new List<int>{3114, 3115}),
//                new Book(7, "Murder on the Orient Express", authors[3], 15.6M, 1934, publishers[2], new List<int>{4110}),
//                new Book(8, "Death on the Nile", authors[3], 16.3M, 1950, publishers[1], new List<int>{4111, 4112}),
//            };



//        //1 Знайти книгу, що видана у 1995 році
//        var result = from book in books
//                     where book.Year == 1995
//                     select book;

//            foreach (var per in result)
//            {
//                Console.WriteLine(per.ToString());
//            }

//    //2 Знайти всі книги, що написані автором Joanne Rowling
//    var result1 = from book in books
//                  join author in authors on book.AuthorId equals author.Id
//                  where author.Surname == "Rowling"
//                  select book;

//            foreach (var per in result1)
//            {
//                Console.WriteLine(per);
//            }

//    //3 Відстортувати книги за роком видання
//    var result2 = from book in books
//                  orderby book.Year
//                  select book;

//    foreach (var per in result2)
//    {
//        Console.WriteLine(per);
//    }

//    //4 Вивести загальну ціну за всі книги окремого автора
//    var result3 = from book in books
//                  join author in authors
//                    on book.AuthorId equals author.Id
//                  group book by new { book.AuthorId, author.Name } into g
//                  select new { Values = g, AuthorName = g.Key.Name, TotalSum = g.Sum(x => x.Price) };
//    foreach (var per in result3)
//    {
//        Console.WriteLine(per.AuthorName + ":");
//        foreach (var book in per.Values)
//        {
//            Console.Write(book.Name + ", ");
//            Console.WriteLine(book.Year);

//        }

//    }

//    //5 Знайти книги, що мають інвентарні номери 1002 і 3113
//    var result4 = from book in books
//                  where book.Inventory.Contains(1002) || book.Inventory.Contains(3113)
//                  select book;

//    foreach (var per in result4)
//    {
//        Console.WriteLine(per.ToString());
//    }

//    //6 Знайти книги, що мають більше одного інвентарного номера
//    var result5 = from book in books
//                  where book.Inventory.Count() > 1
//                  select book;

//    foreach (var per in result5)
//    {
//        Console.WriteLine(per.ToString());
//    }

//    //7 Вивести авторів, авторства яких книг налічується в бібліотеці більше одної
//    var result6 = from author in authors
//                  join book in books
//                    on author.Id equals book.AuthorId
//                  group author by new { author.Id, author.Surname } into g
//                  where g.Count() > 1
//                  select new { Values = g, AuthorName = g.Key.Surname, NumberOfbooks = g.Count() };
//    foreach (var per in result6)
//    {
//        Console.WriteLine(per.AuthorName + ", number of books:" + per.NumberOfbooks);
//    }

//    //8 Вивести всі книги, згрупувавши за їх видавництвом
//    var result7 = from book in books
//                  join publisher in publishers
//                    on book.PublisherId equals publisher.Id
//                  group book by new { book.PublisherId, publisher.Name } into g
//                  select new { Values = g, Publisher = g.Key.Name, };
//    foreach (var per in result7)
//    {
//        Console.WriteLine(per.Publisher);
//        foreach (var book in per.Values)
//        {
//            Console.WriteLine(book.ToString());
//        }
//    }

//    //9 Вивести авторів, чиї книги були виданці видавництвами, що базуються у Іспанії
//    var result8 = (from author in authors
//                   join book in books
//                     on author.Id equals book.AuthorId
//                   join publisher in publishers
//                     on book.PublisherId equals publisher.Id
//                   where publisher.Country == "Spain"
//                   select author).Distinct();
//    foreach (var per in result8)
//    {
//        Console.WriteLine(per.ToString());
//    }

//Console.ReadKey();
//    }
//}
