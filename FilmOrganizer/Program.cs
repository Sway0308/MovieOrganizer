using Category.Standard.Adaptors;
using Category.Standard.Interfaces;
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
            Console.WriteLine("What do you want?");
            Console.WriteLine("1. Find Extensions");
            Console.WriteLine("2. Categorize films");
            var choice = Console.ReadLine();

            Console.WriteLine("Enter Path");
            var path = Console.ReadLine();
            if (string.Equals(path, "exit", StringComparison.InvariantCultureIgnoreCase))
                return;

            Console.WriteLine("Start Process");
            Console.WriteLine("============================================");
            var adaptor = CreateServiceAdaptor(choice);
            adaptor.Execute(path);
            Console.WriteLine("============================================");
            Console.WriteLine("End Process");
            Console.WriteLine("");
            Execute();
        }

        private static IServiceAdaptor CreateServiceAdaptor(string param)
        {
            if (param.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                return new ExtensionAdaptor(); 
            else
                return new FilmAdaptor();
        }
    }
}
