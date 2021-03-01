using Category.Standard.Adaptors;
using Category.Standard.Handlers;
using Category.Standard.Interfaces;
using Gatchan.Base.Standard.Base;
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
            Console.WriteLine("3. Classify film phrase");
            var choice = Console.ReadLine();

            var path = string.Empty;
            var isadaptor = choice.SameTextOr("1", "2");
            if (isadaptor)
            {
                Console.WriteLine("Enter Path");
                path = Console.ReadLine();
                if (path.SameText("exit"))
                    return;
            }

            Console.WriteLine("Start Process");
            Console.WriteLine("============================================");
            if (isadaptor)
            {
                Execute(choice, path);
            }
            else
            {
                Handle();
            }
            Console.WriteLine("============================================");
            Console.WriteLine("End Process");
            Console.WriteLine();
            Execute();
        }

        private static void Handle()
        {
            var handler = new MoviePhraseHandler();
            handler.Analyze();
        }

        private static void Execute(string param, string path)
        {
            var adaptor = CreateServiceAdaptor(param);
            adaptor.Execute(path);
        }

        private static IServiceAdaptor CreateServiceAdaptor(string param)
        {
            if (param.SameText("1"))
                return new ExtensionAdaptor(); 
            else
                return new FilmAdaptor();
        }
    }
}
