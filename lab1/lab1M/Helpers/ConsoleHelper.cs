using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.GroupedModels;

namespace ConsoleApp
{
    public static class ConsoleHelper
    {
        public static int ReadInt(string message)
        {
            Console.WriteLine();
            Console.Write(message);

            var str = Console.ReadLine();

            try
            {
                return int.Parse(str);
            }
            catch (FormatException)
            {
                return ReadInt("Enter an integer value: ");
            }
        }

        public static void PrintGroup(IEnumerable<GroupedModel> groups)
        {
            foreach (var group in groups)
            {
                
                    Console.WriteLine(group.ToString());
                
                
                foreach (var book in group.Group)
                {
                    Console.WriteLine("\t"+book.ToString());
                }
            }
        }

    }
}
