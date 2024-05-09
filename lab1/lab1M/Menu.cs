using System;

namespace ConsoleApp
{
    class Menu
    {
        private static DataSource _source;
        public string Header { get; set; }
        public string ExitInfo { get; set; }

        public Menu(DataSource source, string header, string exitInfo)
        {
            _source = source;
            Header = header;
            ExitInfo = exitInfo;
        }


        private void InvokeAction(int actionIndex)
        {

            actionIndex--;
            if (actionIndex < 0 || actionIndex > _source.Actions.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            else
            {
                _source.Actions[actionIndex]?.Invoke();
            }
        }

        public void ExecuteQuery(int number)
        {
            try
            {
                InvokeAction(number);
            }
            catch (IndexOutOfRangeException ex)
            {
                PrintInfo();
                number = ConsoleHelper.ReadInt(ex.Message+", enter a valid number: ");
                Console.Clear();
                ExecuteQuery(number);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine(Header);
            foreach(var row in _source.QueryInfo)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine(ExitInfo);
        }

        public void RunMenu()
        {
            PrintInfo();
            int input = ConsoleHelper.ReadInt("Select query to execute:");
            if (input==0)
            {
                Environment.Exit(0);
            }
            Console.Clear();
            ExecuteQuery(input);
            
            input = ConsoleHelper.ReadInt("Enter 0 to exit, enter any other number to continue: ");
            if (input!=0)
            {
                Console.Clear();
                RunMenu();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}

