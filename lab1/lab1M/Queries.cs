
using BookStorage.Models;
using BookStorage.GroupedModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Queries
    {

        //1. ������ �����, �� ������ � 1995 ����
        public IEnumerable<Book> FindByYear(IEnumerable<Book> books, int year)
        {
            var result = from book in books
                         where book.Year == 1995
                         select book;

            return result;

        }

        //2. ������ �� �����, �� ������� ������� Joanne Rowling
        public IEnumerable<Book> FindByAuthor(IEnumerable<Book> books, IEnumerable<Author> authors, string authorSurname)
        {
            var result = from book in books
                         join author in authors on book.AuthorId equals author.Id
                         where author.Surname == authorSurname
                         select book;

            return result;
        }

        //3. ³����������� ����� �� ����� �������
        public IEnumerable<Book> SortByYear(IEnumerable<Book> books)
        {
            var result = from book in books
                         orderby book.Year
                         select book;

            return result;
        }

        //4. ������� �������� ���� �� �� ����� �������� ������

        public static IEnumerable<GroupedModel> FindSummaryPrice(IEnumerable<Book> books, IEnumerable<Author> authors)
        {
            var result = from book in books
                         join author in authors
                           on book.AuthorId equals author.Id
                         group book by new { Id = book.AuthorId, Model = author } into g
                         select new GroupedModelAndSum
                         {
                             Group = g,
                             Model = g.Key.Model,
                             PriceValue = g.Sum(x => x.Price * x.Inventory.Count())
                         };
            return result;
        }

        //5. ������ �����, �� ����� ��������� ������ 1002 � 3113
        public static IEnumerable<Book> FindByInventoryNumber(IEnumerable<Book> books, int number)
        {
            var result = from book in books
                         where book.Inventory.Contains(number) 
                         select book;

            return result;
        }

        //6. ������ �����, �� ����� ����� ������ ������������ ������
        public static IEnumerable<Book> FindWhereInventoryNumbersMoreThan(IEnumerable<Book> books, int countOfNumbers)
        {
            var result = from book in books
                         where book.Inventory.Count() > countOfNumbers
                         select book;

            return result;
        }

        //7. ������� ������, ��������� ���� ���� ��������� � �������� ����� ����
        public static IEnumerable<GroupedModel> FindAuthorsWhoHasMoreThanBooks(IEnumerable<Book> books, IEnumerable<Author> authors, int countOfBooks)
        {
            var result = from author in authors
                         join book in books
                           on author.Id equals book.AuthorId
                         group author by new  {IdValue= author.Id, ModelValue = author } into g
                         where g.Count() > countOfBooks
                         select new GroupedModelAndCount{ 
                             Group = g, 
                             Model = g.Key.ModelValue, 
                             CountValue = g.Count() };


            return result;
        }

        //8. ������� �� �����, ����������� �� �� ������������
        public static IEnumerable<GroupedModel> GroupByPublishers(IEnumerable<Book> books, IEnumerable<Publisher> publishers)
        {
            var result = from book in books
                         join publisher in publishers
                           on book.PublisherId equals publisher.Id
                         group book by new {IdValue= book.PublisherId, ModelValue =  publisher } into g
                         select new GroupedModel{ Group = g, Model = g.Key.ModelValue, };
            return result;
        }

        //9. ������� ������, �� ����� ���� ����� �������������, �� ��������� � �����
        public static IEnumerable<Author> FindByPublishersCountry(IEnumerable<Book> books, IEnumerable<Author> authors, IEnumerable<Publisher> publishers, string country)
        {
            var result = (from author in authors
                          join book in books
                            on author.Id equals book.AuthorId
                          join publisher in publishers
                            on book.PublisherId equals publisher.Id
                          where publisher.Country == country
                          select author).Distinct();
            return result;
        }

        //10. ������ �����������, ����� ���� ���������� � ����� S, ����������� �� �������� �� ���� �����
        public static IEnumerable<Publisher> FindPublishersWithLetterInName(IEnumerable<Publisher> publishers, string substring)
        {
            var result = publishers
                .Where(a => a.Name.StartsWith(substring))
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Country);

            return result;
        }

        //11. ���������� ����� �� ������ �����������
        public static IEnumerable<GroupedModelByString> GrupByCountry(IEnumerable<Book> books, IEnumerable<Publisher> publishers)
        {
            var result = books
                .Join(publishers,
                book => book.PublisherId,
                publisher => publisher.Id,
                (book, publisher) => new { book, publisher })
                .GroupBy(x => new { x.publisher.Country })
                .Select(
                x => new GroupedModelByString
                {
                    Group = x.Select(b=>b.book),
                    stringGroupKey = x.Key.Country
                }
                );
            return result;
            
        }
        //12. ������� �� ��������� ������, �� ��������� ������ ������ Rowling � Shakespare, ������������ �� �� ���������
        public static IEnumerable<int> FindInventoryByAuthors(IEnumerable<Book> books, IEnumerable<Author> authors, string authorSurname)
        {
            var result = books
                .Join(authors,
                book => book.AuthorId,
                author => author.Id,
                (book, author) => new { book, author })
                .Where(
                x => x.author.Surname == authorSurname
                )
                .Select(
                x => x.book.Inventory
                )
                .SelectMany(x => x.OrderByDescending(n => n))
                .OrderByDescending(x => x)
                .ToList();

            return result;
        }

        //13. ������� �����������, ������� ���� �� ����� ���� � ��������� ��� ���������
        public static void FindMaxAndMinPrice(IEnumerable<Book> books, IEnumerable<Publisher> publishers)
        {
            var summirsedPrice = publishers
                .Join(books,
                publisher => publisher.Id,
                book => book.PublisherId,
                (publisher, book) => new { publisher, book })
                .GroupBy(x => new { x.book.PublisherId, x.publisher })
                .Select(x => new { Values = x, x.Key.publisher, TotalSum = x.Sum(n => n.book.Price * n.book.Inventory.Count()) })
            ;
            var maxSum = summirsedPrice.Max(x => x.TotalSum);
            var minSum = summirsedPrice.Min(x => x.TotalSum);

            var result = summirsedPrice.Where(x => x.TotalSum == maxSum || x.TotalSum == minSum);

            foreach (var group in result)
            {
                Console.WriteLine(group.Values.Key.publisher.ToString() + " " + group.TotalSum);
            }
        }

        //14. ������� ����� � ������� ����, ���� ���� ����������� � ������� �� 12$ �� 16$
        public static void FindBooksAndQuantity(IEnumerable<Book> books)
        {
            var result = books
                .Where(x => x.Price > 12.0M && x.Price < 16.0M);

            var numberOfBooks = result.Count();

            foreach (var book in result)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine("ʳ������ ����, �� ������� ������ �������: " + numberOfBooks.ToString());
        }

        //15. ���������, �� ������ � �������� ����� ������ Jack Shakespeare
        public static void CheckIfExists(IEnumerable<Book> books, IEnumerable<Author> authors)
        {
            var result = books
                .Join(authors,
                book => book.AuthorId,
                author => author.Id,
                (book, author) => new { book, author })
                .Any(x => x.author.Name == "Jack" && x.author.Surname == "Shakespeare");

            Console.WriteLine("{0}", result == false ? "���� ����� �� ������" : "���� ����� ������");

        }

    }
}