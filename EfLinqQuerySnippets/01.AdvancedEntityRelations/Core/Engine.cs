using EfLinqQuerySnippets._01.AdvancedEntityRelations.Core.Contracts;
using System;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine()
        {
            this.commandInterpreter = new CommandInterpreter();
        }

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter numbers separate by space or enter nothing to exist: ");
                    string[] inputParams = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
                    {
                        if (inputParams.Length > 0)
                        {
                            string result = this.commandInterpreter.Read(inputParams, context);

                            Console.WriteLine(result);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
