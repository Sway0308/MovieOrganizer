using Category.Standard.Adaptors;
using System;

namespace FilmOrganizer
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Console.WriteLine("Enter Path");
            var command = Console.ReadLine();
            if (string.Equals(command, "exit", StringComparison.InvariantCultureIgnoreCase))
                return;

            Console.WriteLine("Start Process");
            Console.WriteLine("============================================");
            var adaptor = new FilmAdaptor();
            adaptor.Categorize(command);
            Console.WriteLine("============================================");
            Console.WriteLine("End Process");
            Console.WriteLine("");
            Execute();
        }
    }
}
