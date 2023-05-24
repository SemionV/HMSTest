using System;
using Microsoft.Extensions.DependencyInjection;
using TestCore;
using TestCore.Domain;

namespace TestApp
{
    class Program
    {
        private const string DataFileName = "data.json";
        private const string WrongInputMessage = "Use -help to see possible the commands and their arguments.";

        static void Main(string[] args)
        {
            using (var storage = new MemoryFileDataStorage<PalindromeCalculationItem>(DataFileName))
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IDataStorage<PalindromeCalculationItem>>(storage)
                    .AddSingleton<Transform, Transform>()
                    .AddSingleton<CommandController, CommandController>()
                    .BuildServiceProvider();

                var controller = serviceProvider.GetService<CommandController>();
                if (controller == null)
                {
                    Console.WriteLine("Cannot instantiate the app.");
                }

                ProcessCommand(args, controller);
            }
        }

        private static void ProcessCommand(string[] args, CommandController controller)
        {
            if (args.Length > 0)
            {
                var command = args[0];

                if (!String.IsNullOrEmpty(command))
                {
                    if (command.ToLower() == "-p")
                    {
                        if (args.Length == 2)
                        {
                            var inputSource = args[1];
                            if (int.TryParse(inputSource, out int input))
                            {
                                controller.CalculatePalindrome(input);
                            }
                            else
                            {
                                Console.WriteLine(WrongInputMessage);
                            }
                        }
                        else
                        {
                            Console.WriteLine(WrongInputMessage);
                        }
                    }

                    if (command.ToLower() == "-pw")
                    {
                        if (args.Length == 2)
                        {
                            var inputSource = args[1];
                            if (int.TryParse(inputSource, out int input))
                            {
                                controller.CalculatePalindromeWithoutSave(input);
                            }
                            else
                            {
                                Console.WriteLine(WrongInputMessage);
                            }
                        }
                        else
                        {
                            Console.WriteLine(WrongInputMessage);
                        }
                    }

                    if (command.ToLower() == "-o")
                    {
                        controller.DisplayData();
                    }

                    if (command.ToLower() == "-help")
                    {
                        PrintHelp();
                    }
                }
                else
                {
                    Console.WriteLine(WrongInputMessage);
                }
            }
            else
            {
                Console.WriteLine(WrongInputMessage);
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Program usage:");
            Console.WriteLine("Calculate palindrome number: -pw [int]");
            Console.WriteLine("Calculate AND save palindrome number: -p [int]");
            Console.WriteLine("Show all calculation results: -o");
        }
    }
}
